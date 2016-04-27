using SharedModels.Debug;

namespace Participation
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using Participation.InlogSysteem.Interfaces;
    using Participation.SharedModels;

    public static class DatabaseManager
    {
        #region Fields
        /// <summary>
        /// Database connection; uses Connectionstring
        /// </summary>
        private static OracleConnection _Connection = new OracleConnection(_ConnectionString);
        /// <summary>
        /// Temp data for connecting to the database; [Username], [Password], [server-IP]
        /// </summary>
        private const string _ConnectionId = "dbi330810",

            _ConnectionPassword = "Jm3AQLBVXo",

            _ConnectionAddress = "//fhictora01.fhict.local:1521/fhictora";
        #endregion

        #region Properties
        private static string _ConnectionString
        {
            /// <summary>
            /// Data used to create the database connection 
            /// </summary>
            get
            {
                return string.Format("Data Source={0};Persist Security Info=True;User Id={1};Password={2}", _ConnectionAddress, _ConnectionId, _ConnectionPassword);
            }
        }

        #endregion

        #region Methods - Background Processes
        /// <summary>
        /// Creates the command with sql query and database connection information
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static OracleCommand CreateOracleCommand(string sql)
        {
            OracleCommand command = new OracleCommand(sql, _Connection);
            command.CommandType = System.Data.CommandType.Text;

            return command;
        }

        /// <summary>
        ///  Opens the connection with the database, returns the reader
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static OracleDataReader ExecuteQuery(OracleCommand command)
        {
            try
            {
                if (_Connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        _Connection.Open();
                    }
                    catch (OracleException exc)
                    {
                        Logger.Write(exc.Message);
                        Debug.WriteLine("Database connection failed!\n" + exc.Message);
                        throw;
                    }
                }

                OracleDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch (OracleException e)
            {
                Logger.Write(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Opens the connection with the database and inserts the given information, returns true if insert worked
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static bool ExecuteNonQuery(OracleCommand command)
        {
            try
            {
                if (_Connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        _Connection.Open();
                    }
                    catch (OracleException exc)
                    {
                        Logger.Write(exc.Message);
                        Debug.WriteLine("Database connection failed!\n" + exc.Message);
                        throw;
                    }
                }

                command.ExecuteNonQuery();
                return true;
            }
            catch (OracleException e)
            {
                Logger.Write(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Converts a string to a gender, returns GenderEnum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static GenderEnum ToGender(string value)
        {
            GenderEnum gender;
            if (value == "Male" || value == "M")
            {
                gender = GenderEnum.Male;
                return gender;
            }

            if (value == "Female" || value == "V")
            {
                gender = GenderEnum.Female;
                return gender;
            }

            else
            {
                throw new Exception("No gender assigned");
            }
        }

        #endregion

        #region Queries

        #region Insert

        #region User
        /// <summary>
        /// Adds a new user into the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal static bool AddUser(IUser user)
        {
            try
            {
                OracleCommand command =
                    CreateOracleCommand(
                        "INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password) VALUES(seq_PersonID.NextVal, :personType, :name, :email, :description, :dateOfBirth, :profilePicture, :location, :phone, :gender, :password)");

                if (user.GetType() == typeof(Patient))
                {
                    command.Parameters.Add(":personType", "Patient");
                }
                if (user.GetType() == typeof(Volunteer))
                {
                    command.Parameters.Add(":personType", "Volunteer");
                }

                switch (user.Gender)
                {
                    case GenderEnum.Male:
                        {
                            command.Parameters.Add(":gender", "M");
                            break;
                        }
                    case GenderEnum.Female:
                        {
                            command.Parameters.Add(":gender", "V");
                            break;
                        }
                }

                OracleDate oDate = (OracleDate)user.Birthday;
                command.Parameters.Add(":name", user.Name);
                command.Parameters.Add(":email", user.Email);
                command.Parameters.Add(":description", user.Description);
                command.Parameters.Add(":dateOfBirth", user.Birthday);
                command.Parameters.Add(":profilePicture", user.ProfilePicture);
                command.Parameters.Add(":location", user.Location);
                command.Parameters.Add(":phone", user.PhoneNumber);
                command.Parameters.Add(":password", user.Password);
                command.BindByName = true;

                if (ExecuteNonQuery(command))
                {
                    command = CreateOracleCommand("SELECT MAX(PERSONID) FROM PERSON");
                    OracleDataReader reader = ExecuteQuery(command);
                    while (reader.Read())
                    {
                        user.Id = Convert.ToInt32(reader["MAX(PERSONID)"].ToString());
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// Adds a perk to the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="perk"></param>
        /// <returns></returns>
        internal static bool AddPerk(IUser user, string perk)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Perk(perkID, perktext) VALUES (SEQ_PERKID, :perktext)");

                if (ExecuteNonQuery(command))
                {
                    command = CreateOracleCommand("SELECT max(perkID) FROM perk");
                    OracleDataReader reader = ExecuteQuery(command);

                    command = CreateOracleCommand("INSERT INTO PERK_PERSON(perkID, PersonID) VALUES (:perkID, :PersonID)");
                    command.Parameters.Add(":perkID", Convert.ToInt32(reader["perkid"].ToString()));
                    command.Parameters.Add(":userID", user.Id);

                    return ExecuteNonQuery(command);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Review
        /// <summary>
        /// Adds a review to the database
        /// </summary>
        /// <param name="volunteer"></param>
        /// <param name="patient"></param>
        /// <param name="review"></param>
        /// <returns></returns>
        internal static bool AddReview(Volunteer volunteer, Patient patient, Review review)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Review(reviewID, reviewerID, revieweeID, rating, description) VALUES(:reviewID, :reviewerID, :revieweeID, :rating, :description)");
                command.Parameters.Add(":reviewID", review.Id);
                command.Parameters.Add(":reviewerID", patient.Id);
                command.Parameters.Add(":revieweeID", volunteer.Id);
                command.Parameters.Add(":rating", review.Rating);
                command.Parameters.Add(":description", review.Text);

                return ExecuteNonQuery(command);
            }
            catch
            {
                throw new Exception("Something went wrong");
            }
            finally
            {
                _Connection.Close();
            }
        }

        #endregion

        #region Meeting

        #endregion

        #region Request
        /// <summary>
        /// Adds a request to te database
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static bool AddRequest(IUser patient, Request request)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO REQUEST(RequestID, personID, title, description, place, placingdate, urgency) VALUES (SEQ_RequestID.NextVal , :personID, :title, :description, :place, :placingdate, :urgency)");
                command.Parameters.Add(":personID", patient.Id);
                command.Parameters.Add(":title", request.Title);
                command.Parameters.Add(":description", request.Text);
                command.Parameters.Add(":place", request.Location);
                command.Parameters.Add(":placingdate", request.Date);
                command.Parameters.Add(":urgency", request.Urgency);
                command.BindByName = true;
                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Response
        /// <summary>
        /// Adds a response to the database
        /// </summary>
        /// <param name="volunteer"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static bool AddResponse(Volunteer volunteer, Request request, Response response)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Response(responderID, requestID, placingdate, description) VALUES(:responderID, :requestID, :placingdate, :description)");
                command.Parameters.Add(":responderID", volunteer.Id);
                command.Parameters.Add(":requestID", request.Id);
                command.Parameters.Add(":placingdate", response.Date);
                command.Parameters.Add(":description", response.Text);

                return ExecuteNonQuery(command);
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong: " + exception.Message);
            }
            finally
            {
                _Connection.Close();
            }
        }

        #endregion

        #endregion

        #region Get

        #region User
        /// <summary>
        /// Pulls the accountinformation from the database, and casts it into an user-object
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        internal static IUser GetUser(string email)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Person WHERE email = :Email and enabled = 1");
                command.Parameters.Add(":Email", email);
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["personid"].ToString());
                    string name = reader["name"].ToString();
                    string emailAdress = reader["email"].ToString();
                    string description = reader["description"].ToString();
                    string dateTime = reader["dateOfBirth"].ToString();
                    string picture = reader["ProfilePicture"].ToString();
                    DateTime dateOfBirth = Convert.ToDateTime(dateTime);
                    string location = reader["location"].ToString();
                    string phoneNumber = reader["phone"].ToString();
                    GenderEnum gender = ToGender(reader["gender"].ToString());
                    string password = reader["password"].ToString();
                    string vog = reader["VOG"].ToString();

                    string personType = reader["personType"].ToString();
                    if (personType == "Volunteer")
                    {
                        return new Volunteer(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password, vog, false);
                    }
                    if (personType == "Patient")
                    {
                        return new Patient(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password);
                    }
                    if (personType == "Admin")
                    {
                        return new Volunteer(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password, vog, true);
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong: " + exception.Message);
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// Gets a list of all users from the database
        /// </summary>
        /// <returns></returns>
        public static List<IUser> GetUsers()
        {
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Person WHERE enabled = 1");
                OracleDataReader reader = ExecuteQuery(command);
                List<IUser> Users = new List<IUser>();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["personid"].ToString());
                    string name = reader["name"].ToString();
                    string emailAdress = reader["email"].ToString();
                    string description = reader["description"].ToString();
                    string dateTime = reader["dateOfBirth"].ToString();
                    DateTime dateOfBirth = Convert.ToDateTime(dateTime);
                    string picture = reader["ProfilePicture"].ToString();
                    string location = reader["location"].ToString();
                    string phoneNumber = reader["phone"].ToString();
                    GenderEnum gender = ToGender(reader["gender"].ToString());
                    string password = reader["password"].ToString();
                    string vog = reader["VOG"].ToString();

                    string personType = reader["personType"].ToString();
                    if (personType == "Volunteer")
                    {
                        Users.Add(new Volunteer(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password, vog, false));
                    }
                    if (personType == "Patient")
                    {
                        Users.Add(new Patient(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password));
                    }
                    if (personType == "Admin")
                    {
                        Users.Add(new Volunteer(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password, vog, true));
                    }
                }
                return Users;
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong: " + exception.Message);
            }
            finally
            {
                _Connection.Close();
            }
        }
        #endregion

        #region Review
        /// <summary>
        /// Returns list of Reviews
        /// </summary>
        /// <returns></returns>
        internal static List<Review> GetReviews()
        {
            List<Review> ReviewList = new List<Review>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Review");
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["reviewID"].ToString());
                    int rating = Convert.ToInt32(reader["rating"].ToString());
                    string description = reader["description"].ToString();

                    ReviewList.Add(new Review(id, rating, description));
                }
                foreach (Review i in ReviewList)
                {
                    OracleCommand patientCommand = CreateOracleCommand("SELECT * FROM PERSON WHERE PERSONID = (SELECT REVIEWERID FROM REVIEW WHERE REVIEWID = :reviewID)");
                    patientCommand.Parameters.Add(":reviewID", i.Id);
                    OracleCommand volunteerCommand = CreateOracleCommand("SELECT * FROM PERSON WHERE PERSONID = (SELECT REVIEWEEID FROM REVIEW WHERE REVIEWID = :reviewID)");
                    volunteerCommand.Parameters.Add(":reviewID", i.Id);

                    OracleDataReader patientReader = ExecuteQuery(patientCommand);
                    IUser patient;
                    IUser volunteer;
                    while (patientReader.Read())
                    {
                        int id = Convert.ToInt32(patientReader["PERSONID"].ToString());
                        string name = patientReader["NAME"].ToString();
                        string emailAdress = patientReader["email"].ToString();
                        string description = patientReader["description"].ToString();
                        string dateTime = patientReader["dateOfBirth"].ToString();
                        DateTime dateOfBirth = Convert.ToDateTime(dateTime);
                        string picture = patientReader["ProfilePicture"].ToString();
                        string location = patientReader["location"].ToString();
                        string phoneNumber = patientReader["phone"].ToString();
                        GenderEnum gender = ToGender(patientReader["gender"].ToString());
                        string password = patientReader["password"].ToString();

                        patient = new Patient(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password);
                        i.Patient = patient;
                    }
                    OracleDataReader volunteerReader = ExecuteQuery(volunteerCommand);

                    while (volunteerReader.Read())
                    {
                        int id = Convert.ToInt32(volunteerReader["PERSONID"].ToString());
                        string name = volunteerReader["name"].ToString();
                        string emailAdress = volunteerReader["email"].ToString();
                        string description = volunteerReader["description"].ToString();
                        string dateTime = volunteerReader["dateOfBirth"].ToString();
                        DateTime dateOfBirth = Convert.ToDateTime(dateTime);
                        string picture = volunteerReader["ProfilePicture"].ToString();
                        string location = volunteerReader["location"].ToString();
                        string phoneNumber = volunteerReader["phone"].ToString();
                        GenderEnum gender = ToGender(volunteerReader["gender"].ToString());
                        string password = volunteerReader["password"].ToString();
                        string vog = volunteerReader["vog"].ToString();

                        volunteer = new Volunteer(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password, vog, false);
                        i.Volunteer = volunteer;
                    }
                }

                return ReviewList;
            }
            catch
            {
                throw new Exception("Something went wrong in the database!");
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// Gets a list of al reviews of a specific volunteer from the database
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        internal static List<Review> GetReviews(IUser volunteer)
        {
            List<Review> ReviewList = new List<Review>();
            try
            {
                if (volunteer.GetType() == typeof(Volunteer))
                {
                    OracleCommand command = CreateOracleCommand("SELECT * FROM Review WHERE REVIEWEEID = :userid");
                    command.Parameters.Add(":userid", volunteer.Id);
                    OracleDataReader reader = ExecuteQuery(command);

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["reviewID"].ToString());
                        int rating = Convert.ToInt32(reader["rating"].ToString());
                        string description = reader["description"].ToString();

                        ReviewList.Add(new Review(id, rating, description));
                    }

                    foreach (Review i in ReviewList)
                    {
                        OracleCommand patientCommand = CreateOracleCommand("SELECT * FROM PERSON WHERE PERSONID = (SELECT REVIEWERID FROM REVIEW WHERE REVIEWID = :reviewID)");
                        patientCommand.Parameters.Add(":reviewID", i.Id);
                        OracleCommand volunteerCommand = CreateOracleCommand("SELECT * FROM PERSON WHERE PERSONID = (SELECT REVIEWEEID FROM REVIEW WHERE REVIEWID = :reviewID)");
                        volunteerCommand.Parameters.Add(":reviewID", i.Id);

                        OracleDataReader patientReader = ExecuteQuery(patientCommand);
                        IUser castpatient;
                        IUser castvolunteer;
                        while (patientReader.Read())
                        {
                            int id = Convert.ToInt32(patientReader["personid"].ToString());
                            string place = patientReader["place"].ToString();
                            string dateTime = patientReader["placingdate"].ToString();
                            DateTime dateOfMeeting = Convert.ToDateTime(dateTime);
                            int status = Convert.ToInt32(patientReader["status"].ToString());
                            string name = patientReader["name"].ToString();
                            string emailAdress = patientReader["email"].ToString();
                            string picture = patientReader["ProfilePicture"].ToString();
                            string description = patientReader["description"].ToString();
                            dateTime = patientReader["dateOfBirth"].ToString();
                            DateTime dateOfBirth = Convert.ToDateTime(dateTime);
                            string location = patientReader["location"].ToString();
                            string phoneNumber = patientReader["phone"].ToString();
                            GenderEnum gender = ToGender(patientReader["gender"].ToString());
                            string password = patientReader["password"].ToString();

                            castpatient = new Patient(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password);
                            i.Patient = castpatient;
                        }
                        OracleDataReader volunteerReader = ExecuteQuery(volunteerCommand);

                        while (volunteerReader.Read())
                        {
                            int id = Convert.ToInt32(volunteerReader["personid"].ToString());
                            string place = volunteerReader["place"].ToString();
                            string dateTime = volunteerReader["placingdate"].ToString();
                            DateTime dateOfMeeting = Convert.ToDateTime(dateTime);
                            int status = Convert.ToInt32(volunteerReader["status"].ToString());
                            string name = volunteerReader["name"].ToString();
                            string emailAdress = volunteerReader["email"].ToString();
                            string description = volunteerReader["description"].ToString();
                            string picture = volunteerReader["ProfilePicture"].ToString();
                            dateTime = volunteerReader["dateOfBirth"].ToString();
                            DateTime dateOfBirth = Convert.ToDateTime(dateTime);
                            string location = volunteerReader["location"].ToString();
                            string phoneNumber = volunteerReader["phone"].ToString();
                            GenderEnum gender = ToGender(volunteerReader["gender"].ToString());
                            string password = volunteerReader["password"].ToString();
                            string vog = volunteerReader["vog"].ToString();

                            castvolunteer = new Volunteer(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password, vog, false);
                            i.Volunteer = castvolunteer;
                        }
                    }
                }
                return ReviewList;
            }
            catch
            {
                throw new Exception("Something went wrong in the database!");
            }
            finally
            {
                _Connection.Close();
            }
        }
        #endregion

        #region Meeting
        /// <summary>
        /// Creates a list of Meetings
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<Meeting> GetMeetingList(IUser user)
        {
            List<Meeting> MeetingList = new List<Meeting>();
            try
            {
                OracleCommand command = new OracleCommand();
                if (user.GetType() == typeof(Patient))
                {
                    command =
                    CreateOracleCommand("SELECT * FROM Meeting m  LEFT JOIN  Person p1 ON p1.personID = m.PatientID LEFT JOIN Person p2 On p2.PersonID = m.VolunteerID WHERE m.PatientID = :userID");
                }
                if (user.GetType() == typeof(Volunteer))
                {
                    command =
                    CreateOracleCommand("SELECT * FROM Meeting m  LEFT JOIN  Person p1 ON p1.personID = m.VolunteerID LEFT JOIN Person p2 On p2.PersonID = m.PatientID WHERE m.VolunteerID = :userID");
                }

                command.Parameters.Add(":userID", user.Id);

                OracleDataReader reader = ExecuteQuery(command);

                if (user.GetType() == typeof(Patient))
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["personid"].ToString());
                        string place = reader["place"].ToString();
                        string dateTime = reader["placingdate"].ToString();
                        DateTime dateOfMeeting = Convert.ToDateTime(dateTime);
                        int status = Convert.ToInt32(reader["status"].ToString());
                        string name = reader["name"].ToString();
                        string emailAdress = reader["email"].ToString();
                        string description = reader["description"].ToString();
                        string picture = reader["ProfilePicture"].ToString();
                        dateTime = reader["dateOfBirth"].ToString();
                        DateTime dateOfBirth = Convert.ToDateTime(dateTime);
                        string location = reader["location"].ToString();
                        string phoneNumber = reader["phone"].ToString();
                        GenderEnum gender = ToGender(reader["gender"].ToString());
                        string password = reader["password"].ToString();

                        int id_other = Convert.ToInt32(reader["personid_1"].ToString());
                        string name_Other = reader["name_1"].ToString();
                        string emailAdress_Other = reader["email_1"].ToString();
                        string description_Other = reader["description_1"].ToString();
                        string picture_Other = reader["ProfilePicture"].ToString();
                        dateTime = reader["dateOfBirth_1"].ToString();
                        DateTime dateOfBirth_Other = Convert.ToDateTime(dateTime);
                        string location_Other = reader["location_1"].ToString();
                        string phoneNumber_Other = reader["phone_1"].ToString();
                        GenderEnum gender_Other = ToGender(reader["gender_1"].ToString());
                        string password_Other = reader["password_1"].ToString();
                        string vog_Other = reader["vog_1"].ToString();

                        IUser patient = new Patient(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password);
                        IUser volunteer = new Volunteer(id_other, name_Other, emailAdress_Other, description_Other, dateOfBirth_Other, picture_Other, location_Other, phoneNumber_Other, gender_Other, password_Other, vog_Other, false);

                        MeetingList.Add(new Meeting(volunteer, patient, dateOfMeeting, place));
                    }
                }
                if (user.GetType() == typeof(Volunteer))
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["personid"].ToString());
                        string place = reader["place"].ToString();
                        string dateTime = reader["placingdate"].ToString();
                        DateTime dateOfMeeting = Convert.ToDateTime(dateTime);
                        int status = Convert.ToInt32(reader["status"].ToString());
                        string name = reader["name"].ToString();
                        string emailAdress = reader["email"].ToString();
                        string description = reader["description"].ToString();
                        string picture = reader["ProfilePicture"].ToString();
                        dateTime = reader["dateOfBirth"].ToString();
                        DateTime dateOfBirth = Convert.ToDateTime(dateTime);
                        string location = reader["location"].ToString();
                        string phoneNumber = reader["phone"].ToString();
                        GenderEnum gender = ToGender(reader["gender"].ToString());
                        string password = reader["password"].ToString();
                        string vog = reader["vog"].ToString();

                        int id_other = Convert.ToInt32(reader["personid_1"].ToString());
                        string name_Other = reader["name_1"].ToString();
                        string emailAdress_Other = reader["email_1"].ToString();
                        string description_Other = reader["description_1"].ToString();
                        string picture_Other = reader["ProfilePicture"].ToString();
                        dateTime = reader["dateOfBirth_1"].ToString();
                        DateTime dateOfBirth_Other = Convert.ToDateTime(dateTime);
                        string location_Other = reader["location_1"].ToString();
                        string phoneNumber_Other = reader["phone_1"].ToString();
                        GenderEnum gender_Other = ToGender(reader["gender_1"].ToString());
                        string password_Other = reader["password_1"].ToString();

                        IUser volunteer = new Volunteer(id, name, emailAdress, description, dateOfBirth, picture, location, phoneNumber, gender, password, vog, false);
                        IUser patient = new Patient(id_other, name_Other, emailAdress_Other, description_Other, dateOfBirth_Other, picture_Other, location_Other, phoneNumber_Other, gender_Other, password_Other);

                        MeetingList.Add(new Meeting(volunteer, patient, dateOfMeeting, place));
                    }
                }
                return MeetingList;
            }
            catch
            {
                throw new Exception("Something went wrong in the database!");
            }
            finally
            {
                _Connection.Close();
            }
        }

        #endregion

        #region Request
        /// <summary>
        /// Returns list of Requests
        /// </summary>
        /// <returns></returns>
        internal static List<Request> GetRequests()
        {
            List<Request> RequestList = new List<Request>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM REQUEST");
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["RequestID"].ToString());
                    string title = reader["title"].ToString();
                    string description = reader["description"].ToString();
                    string location = reader["place"].ToString();
                    DateTime date = Convert.ToDateTime(reader["placingdate"].ToString());
                    int urgency = Convert.ToInt32(reader["urgency"].ToString());

                    RequestList.Add(new Request(id, title, description, null, location, date, urgency));
                }

                foreach (Request r in RequestList)
                {
                    List<string> perks = new List<string>();
                    OracleCommand perkcommand = CreateOracleCommand("Select * from Perk Where PERKID IN (Select PERKID from PERK_REQUEST WHERE REQUESTID = :RequestID)");
                    perkcommand.Parameters.Add(":RequestID", r.Id);

                    OracleDataReader perkReader = ExecuteQuery(perkcommand);

                    while (perkReader.Read())
                    {
                        perks.Add(perkReader["perktext"].ToString());
                    }
                    r.Perks = perks;
                }
            }
            catch
            {
                throw new Exception("Something went wrong in the database!");
            }
            finally
            {
                _Connection.Close();
            }
            return RequestList;
        }

        /// <summary>
        /// Gets a list of all requests from a specific patient from the database
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        internal static List<Request> GetRequests(IUser patient)
        {
            List<Request> RequestList = new List<Request>();
            try
            {
                if (patient.GetType() == typeof(Patient))
                {
                    OracleCommand command = CreateOracleCommand("SELECT * FROM REQUEST WHERE PERSONID = :userid");
                    command.Parameters.Add(":userID", patient.Id);
                    OracleDataReader reader = ExecuteQuery(command);

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["RequestID"].ToString());
                        string title = reader["title"].ToString();
                        string description = reader["description"].ToString();
                        string location = reader["place"].ToString();
                        DateTime date = Convert.ToDateTime(reader["placingdate"].ToString());
                        int urgency = Convert.ToInt32(reader["urgency"].ToString());

                        RequestList.Add(new Request(id, title, description, null, location, date, urgency));
                    }

                    foreach (Request r in RequestList)
                    {
                        List<string> perks = new List<string>();
                        OracleCommand perkcommand = CreateOracleCommand("Select * from Perk Where PERKID IN (Select PERKID from PERK_REQUEST WHERE REQUESTID = :RequestID)");
                        perkcommand.Parameters.Add(":RequestID", r.Id);

                        OracleDataReader perkReader = ExecuteQuery(perkcommand);

                        while (perkReader.Read())
                        {
                            perks.Add(perkReader["perktext"].ToString());
                        }
                        r.Perks = perks;
                    }
                }
            }
            catch
            {
                throw new Exception("Something went wrong in the database!");
            }
            finally
            {
                _Connection.Close();
            }
            return RequestList;
        }

        #endregion

        #region Perk

        public static List<string> GetPerks()
        {
            try
            {
                List<string> perks = new List<string>();
                OracleCommand command = CreateOracleCommand("Select * from Perk");
                OracleDataReader reader = ExecuteQuery(command);
                while (reader.Read())
                {
                    perks.Add(reader["perktext"].ToString());
                }
                return perks;
            }
            catch
            {
                throw new Exception("Could not get perks from the database.");
            }
            finally
            {
                _Connection.Close();
            }
        }
        #endregion

        #region Response

        #endregion

        #endregion

        #region Update

        #region User
        /// <summary>
        /// Temporarily bans a user from the application
        /// </summary>
        /// <param name="user"></param>
        /// <param name="unban"></param>
        /// <returns></returns>
        public static bool BanUser(IUser user)
        {
            if (user.GetType() == typeof(Volunteer))
            {
                Volunteer v = user as Volunteer;
                if (v.isAdmin == true)
                {
                    throw new Exception("You can not ban another Administrator.");
                }
            }
            try
            {
                user.Ban = 2; //Set user ban to 2 for perma ban
                OracleCommand command =
                    CreateOracleCommand("UPDATE Person SET banned = :ban WHERE personID = :personID");
                command.Parameters.Add(":ban", user.Ban);
                command.Parameters.Add(":personID", user.Id);
                return ExecuteNonQuery(command);
            }
            catch
            {
                throw new Exception("Something went wrong in the database!");
            }
            finally
            {
                _Connection.Close();
            }
        }

        public static bool BanUser(IUser user, DateTime unbanDate)
        {
            if (user.GetType() == typeof(Volunteer))
            {
                Volunteer v = user as Volunteer;
                if (v.isAdmin == true)
                {
                    throw new Exception("You can not ban another Administrator.");
                }
            }
            try
            {
                user.Ban = 1; //Set user ban to 1 for temp ban
                user.Unban = unbanDate; //Set user unban to the unbanDate
                OracleDate oDate = (OracleDate)user.Unban;
                OracleCommand command =
                    CreateOracleCommand("UPDATE Person SET banned = :banned, unban = :unban WHERE personID = :personID");
                command.Parameters.Add(":banned", user.Ban);
                command.Parameters.Add(":unban", user.Unban);
                command.Parameters.Add(":personID", user.Id);
                command.BindByName = true;
                return ExecuteNonQuery(command);
            }
            catch
            {
                throw new Exception("Something went wrong in the database!");
            }
            finally
            {
                _Connection.Close();
            }
        }

        public static bool ChangePermission(IUser user)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("UPDATE PERSON SET PERSONTYPE = :persontype WHERE PersonID = :personID");
                command.Parameters.Add(":personID", user.Id);

                Volunteer v = user as Volunteer;
                switch (v.isAdmin)
                {
                    case true:
                        {
                            command.Parameters.Add(":persontype", "Admin");
                            break;
                        }
                    case false:
                        {
                            command.Parameters.Add(":persontype", "Volunteer");
                            break;
                        }

                }
                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                _Connection.Close();
            }
        }

        #endregion

        #region Review

        #endregion

        #region Meeting

        #endregion

        #region Request

        #endregion

        #region Response

        #endregion

        #endregion

        #region Delete

        #region User
        public static bool RemoveUser(IUser user)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("Update PERSON SET enabled = 0 Where personid = :personid");
                command.Parameters.Add(":personid", user.Id);
                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                _Connection.Close();
            }
        }

        #endregion

        #region Review
        /// <summary>
        /// Deletes a review from the database
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        public static bool DeleteReview(Review review)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("DELETE FROM Review WHERE reviewID = :reviewID");
                command.Parameters.Add(":reviewID", review.Id);

                return ExecuteNonQuery(command);
            }
            catch
            {
                throw new Exception("Something went wrong in the database!");
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// Deletes a request from the database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool DeleteRequest(Request request)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("DELETE FROM PERK_REQUEST Where requestid = :requestID");
                command.Parameters.Add(":requestID", request.Id);
                if (ExecuteNonQuery(command))
                {
                    command = CreateOracleCommand("DELETE FROM RESPONSE WHERE requestid = :requestID");
                    command.Parameters.Add(":requestID", request.Id);
                    if (ExecuteNonQuery(command))
                    {
                        command = CreateOracleCommand("DELETE FROM Request WHERE requestID = :requestID");
                        command.Parameters.Add(":requestID", request.Id);

                        return ExecuteNonQuery(command);

                    }
                    return false;

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception("Something went wrong in the database!");
            }
            finally
            {
                _Connection.Close();
            }

            #endregion

            #region Response

            #endregion

            #endregion

            #endregion

        }
    }
}
