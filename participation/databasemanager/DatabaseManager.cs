using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using Participation.SharedModels;
using Participation.InlogSysteem.Interfaces;

//TODO Fix everything...

namespace Participation
{
    public static class DatabaseManager
    {
        #region Fields

        //Database connection; uses Connectionstring
        private static OracleConnection _Connection = new OracleConnection(_ConnectionString);
        //Temp data for connecting to the database; [Username], [Password], [server-IP]

        private const string _ConnectionId = "dbi330810",
            _ConnectionPassword = "Jm3AQLBVXo",
            _ConnectionAddress = "//fhictora01.fhict.local:1521/fhictora";

        #endregion

        #region Properties

        private static string _ConnectionString
        {
            //Data used to create the database connection
            get
            {
                return string.Format("Data Source={0};Persist Security Info=True;User Id={1};Password={2}",
                    _ConnectionAddress, _ConnectionId, _ConnectionPassword);
            }
        }

        #endregion

        #region Methods - Background Processes

        //Creates the command with sql query and database connection information
        private static OracleCommand CreateOracleCommand(string sql)
        {
            OracleCommand command = new OracleCommand(sql, _Connection);
            command.CommandType = System.Data.CommandType.Text;

            return command;
        }

        //Opens the connection with the database, returns the reader
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
                        Debug.WriteLine("Database connection failed!\n" + exc.Message);
                        throw;
                    }
                }

                OracleDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch(OracleException exc)
            {
                return null;
            }
        }

        //Opens the connection with the database and inserts the given information, returns true if insert worked
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
                        Debug.WriteLine("Database connection failed!\n" + exc.Message);
                        throw;
                    }
                }

                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Converts a string to a gender, returns GenderEnum
        private static GenderEnum ToGender(string value)
        {
            GenderEnum gender;
            if (value == "Male" || value == "M" )
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

        //Adds a new user into the database
        internal static bool AddUser(IUser user)
        {
            try
            {
                OracleCommand command =
                    CreateOracleCommand(
                        "INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password) VALUES(:personID, :personType, :name, :email, :description, :dateOfBirth, :profilePicture, :location, :phone, :gender, :password)");

                command.Parameters.Add(":personID", user.Id);

                #region personType

                if (user.GetType() == typeof(Patient))
                {
                    command.Parameters.Add(":personType", "Patient");
                }
                if (user.GetType() == typeof (Volunteer))
                {
                    command.Parameters.Add(":personType", "Volunteer");
                }
                command.Parameters.Add(":name", user.Name);
                command.Parameters.Add(":email", user.Email);
                command.Parameters.Add(":description", user.Description);
                command.Parameters.Add(":dateOfBirth", user.Birthday); //Dont know if this is formatted right
                command.Parameters.Add(":profilePicture", user.ProfilePicture);
                command.Parameters.Add(":location", user.Location);
                command.Parameters.Add(":phone", user.PhoneNumber);
                command.Parameters.Add(":gender", user.Gender.ToString());
                command.Parameters.Add(":password", user.Password);

                return ExecuteNonQuery(command);
            }
            catch
            {
                throw new Exception("Sometthing went wrong");
            }
            finally
            {
                _Connection.Close();
            }
        }
        internal static bool AddPerk(IUser user, string perk)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Perk(perkID, perktext) VALUES (SEQ_PERKID.NEXTVAL, :perktext)");

                if(ExecuteNonQuery(command))
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

        //Adds a review to the database
        internal static bool AddReview(Volunteer volunteer, Patient patient, Review review)
        {
            try
            {
                OracleCommand command =
                    CreateOracleCommand(
                        "INSERT INTO Review(reviewID, reviewerID, revieweeID, rating, description) VALUES(:reviewID, :reviewerID, :revieweeID, :rating, :description)");
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

        internal static bool AddRequest(IUser Patient, Request request)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO REQUEST(RequestID, personID, title, description, place, placingdate, urgency) VALUES (SEQ_RequestID.NextVal, :personID, :title, :description, :place, :placingdate, :urgency)");
                command.Parameters.Add(":personID", Patient.Id);
                command.Parameters.Add(":title", request.Title);
                command.Parameters.Add(":description", request.Text);
                command.Parameters.Add(":place", request.Location);
                command.Parameters.Add(":placingdate", request.Date);
                command.Parameters.Add(":urgency", request.Urgency);
                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Response

        //Adds a response to the database
        internal static bool AddResponse(Volunteer volunteer, Request request, Response response)
        {
            try
            {
                OracleCommand command =
                    CreateOracleCommand(
                        "INSERT INTO Response(responderID, requestID, placingdate, description) VALUES(:responderID, :requestID, :placingdate, :description)");
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

        //Pulls the accountinformation from the database, and casts it into an user-object
        public static IUser GetUser(string Email)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Person WHERE email = :Email");
                command.Parameters.Add(":Email", Email);
                OracleDataReader reader = ExecuteQuery(command);

                int id = Convert.ToInt32(("personid").ToString());
                string Name = reader["name"].ToString();
                string EmailAdress = reader["email"].ToString();
                string Description = reader["description"].ToString();
                string dateTime = reader["dateOfBirth"].ToString();
                string Picture = reader["ProfilePicture"].ToString();
                DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                string Location = reader["location"].ToString();
                string PhoneNumber = reader["phone"].ToString();
                GenderEnum Gender = ToGender(reader["gender"].ToString());
                string Password = reader["password"].ToString();
                string VOG = reader["VOG"].ToString();

                string PersonType = reader["personType"].ToString();
                if (PersonType == "Volunteer")
                {
                    return new Volunteer(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password, VOG, false);
                }
                if (PersonType == "Patient")
                {
                    return new Patient(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password);
                }
                if (PersonType == "Admin")
                {
                    return new Volunteer(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password, VOG, true);
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

        public static List<IUser> GetUsers(string Email)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Person");
                OracleDataReader reader = ExecuteQuery(command);
                List<IUser> Users = new List<IUser>();
                while(reader.Read())
                {
                    int id = Convert.ToInt32(("personid").ToString());
                    string Name = reader["name"].ToString();
                    string EmailAdress = reader["email"].ToString();
                    string Description = reader["description"].ToString();
                    string dateTime = reader["dateOfBirth"].ToString();
                    string Picture = reader["ProfilePicture"].ToString();
                    DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                    string Location = reader["location"].ToString();
                    string PhoneNumber = reader["phone"].ToString();
                    GenderEnum Gender = ToGender(reader["gender"].ToString());
                    string Password = reader["password"].ToString();
                    string VOG = reader["VOG"].ToString();

                    string PersonType = reader["personType"].ToString();
                    if (PersonType == "Volunteer")
                    {
                        Users.Add(new Volunteer(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password, VOG, false));
                    }
                    if (PersonType == "Patient")
                    {
                        Users.Add(new Patient(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password));
                    }
                    if (PersonType == "Admin")
                    {
                        Users.Add(new Volunteer(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password, VOG, true));
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

        //Returns list of Reviews
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
                foreach (Review R in ReviewList)
                {
                    OracleCommand patientCommand = CreateOracleCommand("SELECT * FROM PERSON WHERE PERSONID = (SELECT REVIEWERID FROM REVIEW WHERE REVIEWID = :reviewID)");
                    patientCommand.Parameters.Add(":reviewID", R.Id);
                    OracleCommand volunteerCommand = CreateOracleCommand("SELECT * FROM PERSON WHERE PERSONID = (SELECT REVIEWEEID FROM REVIEW WHERE REVIEWID = :reviewID)");
                    volunteerCommand.Parameters.Add(":reviewID", R.Id);

                    OracleDataReader patientReader = ExecuteQuery(patientCommand);
                    IUser patient;
                    IUser volunteer;
                    while (patientReader.Read())
                    {
                        int id = Convert.ToInt32(patientReader["PERSONID"].ToString());
                        string Name = patientReader["NAME"].ToString();
                        string EmailAdress = patientReader["email"].ToString();
                        string Description = patientReader["description"].ToString();
                        string dateTime = patientReader["dateOfBirth"].ToString();
                        string Picture = patientReader["ProfilePicture"].ToString();
                        DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                        string Location = patientReader["location"].ToString();
                        string PhoneNumber = patientReader["phone"].ToString();
                        GenderEnum Gender = ToGender(patientReader["gender"].ToString());
                        string Password = patientReader["password"].ToString();

                        patient = new Patient(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password);
                        R.Patient = patient;
                    }
                    OracleDataReader volunteerReader = ExecuteQuery(volunteerCommand);

                    while (volunteerReader.Read())
                    {
                        int id = Convert.ToInt32(volunteerReader["PERSONID"].ToString());
                        string Name = volunteerReader["name"].ToString();
                        string EmailAdress = volunteerReader["email"].ToString();
                        string Description = volunteerReader["description"].ToString();
                        string dateTime = volunteerReader["dateOfBirth"].ToString();
                        DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                        string Picture = volunteerReader["ProfilePicture"].ToString();
                        string Location = volunteerReader["location"].ToString();
                        string PhoneNumber = volunteerReader["phone"].ToString();
                        GenderEnum Gender = ToGender(volunteerReader["gender"].ToString());
                        string Password = volunteerReader["password"].ToString();
                        string VOG = volunteerReader["vog"].ToString();

                        volunteer = new Volunteer(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password, VOG, false);
                        R.Volunteer = volunteer;
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

        internal static List<Review> GetReviews(IUser Volunteer)
        {
            List<Review> ReviewList = new List<Review>();

            try
            {
                if(Volunteer.GetType() == typeof(Volunteer))
                {
                    OracleCommand command = CreateOracleCommand("SELECT * FROM Review WHERE REVIEWEEID = :userid");
                    command.Parameters.Add(":userid", Volunteer.Id);
                    OracleDataReader reader = ExecuteQuery(command);

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["reviewID"].ToString());
                        int rating = Convert.ToInt32(reader["rating"].ToString());
                        string description = reader["description"].ToString();

                            ReviewList.Add(new Review(id, rating, description));
                    }

                    foreach(Review R in ReviewList)
                    {
                        OracleCommand patientCommand = CreateOracleCommand("SELECT * FROM PERSON WHERE PERSONID = (SELECT REVIEWERID FROM REVIEW WHERE REVIEWID = :reviewID)");
                        patientCommand.Parameters.Add(":reviewID", R.Id);
                        OracleCommand volunteerCommand = CreateOracleCommand("SELECT * FROM PERSON WHERE PERSONID = (SELECT REVIEWEEID FROM REVIEW WHERE REVIEWID = :reviewID)");
                        volunteerCommand.Parameters.Add(":reviewID", R.Id);

                        OracleDataReader patientReader = ExecuteQuery(patientCommand);
                        IUser patient;
                        IUser volunteer;
                        while (patientReader.Read())
                        {
                            int id = Convert.ToInt32(patientReader["personid"].ToString());
                            string place = patientReader["place"].ToString();
                            string dateTime = patientReader["placingdate"].ToString();
                            DateTime DateOfMeeting = Convert.ToDateTime(dateTime);
                            int status = Convert.ToInt32(patientReader["status"].ToString());
                            string Name = patientReader["name"].ToString();
                            string EmailAdress = patientReader["email"].ToString();
                            string Picture = patientReader["ProfilePicture"].ToString();
                            string Description = patientReader["description"].ToString();
                            dateTime = patientReader["dateOfBirth"].ToString();
                            DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                            string Location = patientReader["location"].ToString();
                            string PhoneNumber = patientReader["phone"].ToString();
                            GenderEnum Gender = ToGender(patientReader["gender"].ToString());
                            string Password = patientReader["password"].ToString();

                            patient = new Patient(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password);
                            R.Patient = patient;
                        }
                        OracleDataReader volunteerReader = ExecuteQuery(volunteerCommand);

                        while(volunteerReader.Read())
                        {
                            int id = Convert.ToInt32(volunteerReader["personid"].ToString());
                            string place = volunteerReader["place"].ToString();
                            string dateTime = volunteerReader["placingdate"].ToString();
                            DateTime DateOfMeeting = Convert.ToDateTime(dateTime);
                            int status = Convert.ToInt32(volunteerReader["status"].ToString());
                            string Name = volunteerReader["name"].ToString();
                            string EmailAdress = volunteerReader["email"].ToString();
                            string Description = volunteerReader["description"].ToString();
                            string Picture = volunteerReader["ProfilePicture"].ToString();
                            dateTime = volunteerReader["dateOfBirth"].ToString();
                            DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                            string Location = volunteerReader["location"].ToString();
                            string PhoneNumber = volunteerReader["phone"].ToString();
                            GenderEnum Gender = ToGender(volunteerReader["gender"].ToString());
                            string Password = volunteerReader["password"].ToString();
                            string VOG = volunteerReader["vog"].ToString();

                            volunteer = new Volunteer(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password, VOG, false);
                            R.Volunteer = volunteer;
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

        //Creates a list of meetings
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
                        DateTime DateOfMeeting = Convert.ToDateTime(dateTime);
                        int status = Convert.ToInt32(reader["status"].ToString());
                        string Name = reader["name"].ToString();
                        string EmailAdress = reader["email"].ToString();
                        string Description = reader["description"].ToString();
                        string Picture = reader["ProfilePicture"].ToString();
                        dateTime = reader["dateOfBirth"].ToString();
                        DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                        string Location = reader["location"].ToString();
                        string PhoneNumber = reader["phone"].ToString();
                        GenderEnum Gender = ToGender(reader["gender"].ToString());
                        string Password = reader["password"].ToString();

                        int id_other = Convert.ToInt32(reader["personid_1"].ToString());
                        string Name_Other = reader["name_1"].ToString();
                        string EmailAdress_Other = reader["email_1"].ToString();
                        string Description_Other = reader["description_1"].ToString();
                        string Picture_Other = reader["ProfilePicture"].ToString();
                        dateTime = reader["dateOfBirth_1"].ToString();
                        DateTime DateOfBirth_Other = Convert.ToDateTime(dateTime);
                        string Location_Other = reader["location_1"].ToString();
                        string PhoneNumber_Other = reader["phone_1"].ToString();
                        GenderEnum Gender_Other = ToGender(reader["gender_1"].ToString());
                        string Password_Other = reader["password_1"].ToString();
                        string VOG_Other = reader["vog_1"].ToString();

                        IUser Patient = new Patient(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password);
                        IUser Volunteer = new Volunteer(id_other, Name_Other, EmailAdress_Other, Description_Other, DateOfBirth_Other, Picture_Other, Location_Other, PhoneNumber_Other, Gender_Other, Password_Other, VOG_Other, false);

                        MeetingList.Add(new Meeting(Volunteer, Patient, DateOfMeeting, place));
                    }
                }
                if (user.GetType() == typeof(Volunteer))
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["personid"].ToString());
                        string place = reader["place"].ToString();
                        string dateTime = reader["placingdate"].ToString();
                        DateTime DateOfMeeting = Convert.ToDateTime(dateTime);
                        int status = Convert.ToInt32(reader["status"].ToString());
                        string Name = reader["name"].ToString();
                        string EmailAdress = reader["email"].ToString();
                        string Description = reader["description"].ToString();
                        string Picture = reader["ProfilePicture"].ToString();
                        dateTime = reader["dateOfBirth"].ToString();
                        DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                        string Location = reader["location"].ToString();
                        string PhoneNumber = reader["phone"].ToString();
                        GenderEnum Gender = ToGender(reader["gender"].ToString());
                        string Password = reader["password"].ToString();
                        string VOG = reader["vog"].ToString();

                        int id_other = Convert.ToInt32(reader["personid_1"].ToString());
                        string Name_Other = reader["name_1"].ToString();
                        string EmailAdress_Other = reader["email_1"].ToString();
                        string Description_Other = reader["description_1"].ToString();
                        string Picture_Other = reader["ProfilePicture"].ToString();
                        dateTime = reader["dateOfBirth_1"].ToString();
                        DateTime DateOfBirth_Other = Convert.ToDateTime(dateTime);
                        string Location_Other = reader["location_1"].ToString();
                        string PhoneNumber_Other = reader["phone_1"].ToString();
                        GenderEnum Gender_Other = ToGender(reader["gender_1"].ToString());
                        string Password_Other = reader["password_1"].ToString();

                        IUser Volunteer = new Volunteer(id, Name, EmailAdress, Description, DateOfBirth, Picture, Location, PhoneNumber, Gender, Password, VOG, false);
                        IUser Patient = new Patient(id_other, Name_Other, EmailAdress_Other, Description_Other, DateOfBirth_Other, Picture_Other, Location_Other, PhoneNumber_Other, Gender_Other, Password_Other);

                        MeetingList.Add(new Meeting(Volunteer, Patient, DateOfMeeting, place));
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

        //Returns list of Requests
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

                foreach(Request r in RequestList)
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

        internal static List<Request> GetRequest(IUser patient)
        {
            List<Request> RequestList = new List<Request>();
            try
            {
                if(patient.GetType() == typeof(Patient))
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

        #region Response

        #endregion

        #endregion

        #region Update

        #region User

        //Temporarily bans a user from the application
        public static bool BanUserTemp(User user, int unban)
        {
            DateTime unbandate = DateTime.Now.AddDays(unban);
            try
            {
                OracleCommand command =
                    CreateOracleCommand("UPDATE Person SET banned = 1, unban = :Date WHERE email = :Email");
                command.Parameters.Add(":Email", user.Email);
                command.Parameters.Add(":Date", user.Email);
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

        //Permanently bans a user from the application
        public static bool BanUserPerm(User user)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("UPDATE Person SET banned = 2");
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

        #endregion

        #region Review

        //Deletes a review from the database

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

        //Deletes a request from the database
        public static bool DeleteRequest(Request request)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("DELETE FROM Request WHERE requestID = :requestID");
                command.Parameters.Add(":requestID", request.Id);

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


            #endregion

            #region Response

            #endregion

            #endregion

            #endregion

            #endregion
        }
    }
}
