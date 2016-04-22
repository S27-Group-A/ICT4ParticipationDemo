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


namespace Participation
{
    public static class DatabaseManager
    {
        #region Fields
        //Database connection; uses Connectionstring
        private static OracleConnection _Connection = new OracleConnection(_ConnectionString);
        //Temp data for connecting to the database; [Username], [Password], [server-IP]
        private const string _ConnectionId = "dbi330810", _ConnectionPassword = " Jm3AQLBVXo", _ConnectionAddress = "//fhictora01.fhict.local/fhictora";
        #endregion

        #region Properties
        private static string _ConnectionString
        {
            //Data used to create the database connection
            get
            {
                return string.Format("Data Source={0};Persist Security Info=True;User Id={1};Password={2}", _ConnectionAddress, _ConnectionId, _ConnectionPassword);

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
            catch
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
            if (value == "M")
            {
                gender = GenderEnum.Male;
            }
            if (value == "V")
            {
                gender = GenderEnum.Female;
            }
            else
            {
                throw new Exception("No gender assigned");
            }

            return gender;
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
                var testP = new Patient();
                var testV = new Volunteer();
                OracleCommand command = CreateOracleCommand("INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password) VALUES(:personID, :personType, :name, :email, :description, :dateOfBirth, :profilePicture, :location, :phone, :gender, :password)");

                command.Parameters.Add(":personID", user.ID);
                #region personType
                if (user.GetType() == testP.GetType())
                {
                    command.Parameters.Add(":personType", "Patient");
                }
                if (user.GetType() == testV.GetType())
                {
                    command.Parameters.Add(":personType", "Volunteer");
                }
                #endregion
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
                throw new Exception("Something went wrong");
            }
            finally
            {
                _Connection.Close();
            }
        }
        #endregion

        #region Perk
        //Adds a perk to the database
        internal static bool AddPerk(Volunteer volunteer, string perk)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Perk(perkID, personID, perktext) VALUES(:perkID, :personID, :perktext)");
                command.Parameters.Add(":perkID", 1);
                command.Parameters.Add(":personID", volunteer.ID);
                command.Parameters.Add(":perktext", perk);

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

        //Adds a list of perk to the database
        internal static bool AddPerks(Volunteer volunteer, List<string> perks)
        {
            OracleCommand command = CreateOracleCommand("INSERT INTO Perk(perkID, personID, perktext) VALUES(:perkID, :personID, :perktext)");
            try
            {

                foreach (string i in perks)
                {
                    command.Parameters.Add(":perkID", 1);
                    command.Parameters.Add(":personID", volunteer.ID);
                    command.Parameters.Add(":perktext", i);

                    ExecuteNonQuery(command);
                }
                return true;
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

        #region Review
        //Adds a review to the database
        internal static bool AddReview(Volunteer volunteer, Patient patient, Review review)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Review(reviewID, reviewerID, revieweeID, rating, description) VALUES(:reviewID, :reviewerID, :revieweeID, :rating, :description)");

                command.Parameters.Add(":reviewID", review.ID);
                command.Parameters.Add(":reviewerID", patient.ID);
                command.Parameters.Add(":revieweeID", volunteer.ID);
                command.Parameters.Add(":rating", review.rating);
                command.Parameters.Add(":description", review.description);

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
        //Adds a meeting to the database
        internal static bool AddMeeting(Volunteer volunteer, Patient patient, Meeting meeting)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Meeting(volunteerID, patientID, place, placingdate, status) VALUES(:volunteerID, :patientID, :place, :placingdate, :status)");

                command.Parameters.Add(":volunteerID", volunteer.ID);
                command.Parameters.Add(":patientID", patient.ID);
                command.Parameters.Add(":place", meeting.location);
                command.Parameters.Add(":volunteerID", meeting.Date);
                command.Parameters.Add(":volunteerID", meeting.status);

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

        #region Request
        //Adds a request to the database
        internal static bool AddRequest(Request request, Patient patient)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Request(requestID, personID, title, description, place, placingdate, urgency) VALUES(:requestID, :personID, :title, :description, :place, :placingdate, :urgency)");
                command.Parameters.Add(":requestID", request.ID);
                command.Parameters.Add(":personID", patient.ID);
                command.Parameters.Add(":title", request.Title);
                command.Parameters.Add(":description", request.Text);
                command.Parameters.Add(":place", request.Location);
                command.Parameters.Add(":placingdate", request.Date);
                command.Parameters.Add(":urgency", request.Urgency);

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

        #region Response
        //Adds a response to the database
        internal static bool AddResponse(Volunteer volunteer, Request request, Response response)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Response(responderID, requestID, placingdate, description) VALUES(:responderID, :requestID, :placingdate, :description)");
                command.Parameters.Add(":responderID", volunteer.ID);
                command.Parameters.Add(":requestID", request.ID);
                command.Parameters.Add(":placingdate", response.Date);
                command.Parameters.Add(":description", response.Text);

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
        #endregion

        #region Get
        #region User
        //Returns list of all users.
        internal static List<IUser> GetUsersAll()
        {
            List<User> UserList = new List<User>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Person;");
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    string Name = reader["name"].ToString();
                    string EmailAdress = reader["email"].ToString();
                    string Description = reader["description"].ToString();
                    DateTime DateOfBirth = Convert.ToDateTime(reader["dateOfBirth"].ToString());
                    string Location = reader["location"].ToString();
                    string PhoneNumber = reader["phone"].ToString();
                    GenderEnum Gender = ToGender(reader["gender"].ToString());
                    string Password = reader["password"].ToString();
                    string PersonType = reader["personType"].ToString(); //Needs to be added in the constructor

                    if (PersonType == "Volunteer")
                    {
                        //UserList.Add(new Volunteer(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password));
                    }
                    if (PersonType == "Patient")
                    {
                        //UserList.Add(new Patient(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password));
                    }
                    if (PersonType == "Admin")
                    {
                        //UserList.Add(new Volunteer(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password));
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
            return UserList;
        }

        //Returns a user from the database, and creates a user, based on email
        internal static IUser GetUserByEmail(string Email)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Person WHERE email = :Email");
                command.Parameters.Add(":Email", Email);
                OracleDataReader reader = ExecuteQuery(command);

                string Name = reader["name"].ToString();
                string EmailAdress = reader["email"].ToString();
                string Description = reader["description"].ToString();
                string dateTime = reader["dateOfBirth"].ToString();
                    DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                string Location = reader["location"].ToString();
                string PhoneNumber = reader["phone"].ToString();
                GenderEnum Gender = ToGender(reader["gender"].ToString());
                string Password = reader["password"].ToString();

                string PersonType = reader["personType"].ToString();
                if (PersonType == "Volunteer")
                {
                    return new Volunteer(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password);
                }
                if (PersonType == "Patient")
                {
                    return new Patient(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password);
                }
                if (PersonType == "Admin")
                {
                    return new Volunteer(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password);
                }
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

        //Returns a patient, based on request
        //internal static Patient GetPatientByRequest(Request request)
        //{
        //    try
        //    {
        //        //OracleCommand command = CreateOracleCommand("SELECT * FROM Person INNER JOIN Request ON Person.personID = Request.personID WHERE ");
        //    }
        //    catch
        //    {
        //        throw new Exception("Something went wrong");
        //    }
        //    finally
        //    {
        //        _Connection.Close();
        //    }
        //}

        #endregion

        #region Perk

        #endregion

        #region Review
        //Returns list of Reviews
        internal static List<Review> GetReviews()
        {
            List<Review> ReviewList = new List<Review>();

            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Review;");
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    int rating = Convert.ToInt32(reader["rating"].ToString());
                    string description = reader["description"].ToString();

                    ReviewList.Add(new Review(rating, description));
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

        //Returns a list of all review from a volunteer
        internal static List<Review> GetReviews(Volunteer volunteer)
        {
            List<Review> ReviewList = new List<Review>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Review WHERE revieweeID = :revieweeID;");
                command.Parameters.Add(":revieweeID", volunteer.ID);
                OracleDataReader reader = ExecuteQuery(command);

                while(reader.Read())
                {
                    int Rating = Convert.ToInt32(reader["rating"].ToString());
                    string Text = reader["description"].ToString();

                    ReviewList.Add(new Review(Rating, Text));
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
        //Creates a a meeting
        internal static Meeting GetMeeting(Volunteer volunteer, Patient patient)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Meeting WHERE volunteerID = :volunteerID AND patientID = :patientID;");
                command.Parameters.Add(":volunteerID", volunteer.ID);
                command.Parameters.Add(":patientID", patient.ID);

                OracleDataReader reader = ExecuteQuery(command);

                List<Meeting> MeetingList = new List<Meeting>();
                while (reader.Read())
                {
                    string place = reader["place"].ToString();
                    string dateTime = reader["placingdate"].ToString();
                    DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                    int status = Convert.ToInt32(reader["status"].ToString());

                    return new Meeting(place, dateTime, status);
                }
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

        //Creates a list of meetings
        internal static List<Meeting> GetMeetings(IUser user)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Meeting WHERE volunteerID = :userID OR patientID = :userID;");
                command.Parameters.Add(":userID", user.ID);

                OracleDataReader reader = ExecuteQuery(command);

                List<Meeting> MeetingList = new List<Meeting>();
                while(reader.Read())
                {
                    string place = reader["place"].ToString();
                    string dateTime = reader["placingdate"].ToString();
                    DateTime DateOfBirth = Convert.ToDateTime(dateTime);
                    int status = Convert.ToInt32(reader["status"].ToString());

                    MeetingList.Add(new Meeting(place, dateTime, status));
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
        //Returns list of all requests
        internal static List<Request> GetRequestsAll()
        {
            List<Request> RequestList = new List<Request>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Request;");
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    string title = reader["title"].ToString();
                    string description = reader["description"].ToString(); ;
                    string perks = reader["perks"].ToString();
                    string location = reader["location"].ToString();
                    DateTime date = Convert.ToDateTime(reader["date"].ToString());
                    int urgency = Convert.ToInt32(reader["name"].ToString());

                    RequestList.Add(new Request(title, description, perks, location, date, urgency));
                }

                return RequestList;
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

        //Returns a list all request by a patient
        internal static List<Request> GetRequestsByPatient(Patient patient)
        {
            List<Request> RequestList = new List<Request>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Request WHERE personID = :personID;");
                command.Parameters.Add(":personID", patient.ID);
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    string title = reader["title"].ToString();
                    string description = reader["description"].ToString(); ;
                    string perks = reader["perks"].ToString();
                    string location = reader["location"].ToString();
                    DateTime date = Convert.ToDateTime(reader["date"].ToString());
                    int urgency = Convert.ToInt32(reader["name"].ToString());

                    RequestList.Add(new Request(title, description, perks, location, date, urgency));
                }
                return RequestList;
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

        #region Response
        internal static List<Response> GetResponse(Request request, Volunteer volunteer)
        {
            List<Response> ResponseList = new List<Response>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Response WHERE responderID = :responderID AND requestID = :requestID;");
                command.Parameters.Add(":responderID", volunteer.ID);
                command.Parameters.Add(":responderID", request.ID);
                OracleDataReader reader = ExecuteQuery(command);

                while (reader.Read())
                {
                    DateTime Date = Convert.ToDateTime(reader["placingdate"].ToString());
                    string Description = reader["description"].ToString();

                    ResponseList.Add(new Response(Date, Description));
                }
                return ResponseList;
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
        #endregion

        #region Update
        #region User
        //Temporarily bans a user from the application
        internal static bool BanUserTemp(User user, int unban)
        {
            DateTime unbandate = DateTime.Now.AddDays(unban);
            try
            {
                OracleCommand command = CreateOracleCommand("UPDATE Person SET banned = 1, unban = :Date WHERE email = :Email");
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
        internal static bool BanUserPerm(User user)
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

        //Changes the usertype
        internal static bool ChangePermissions(IUser user, string rights)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("UPDATE Person SET banned = :permission");
                command.Parameters.Add(":permission", rights);

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

        #region Perk

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
        //Deletes a user from the database
        internal static bool DeleteUser(IUser user)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("DELETE FROM Person WHERE personID = :personID");
                command.Parameters.Add(":personID", user.ID);

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

        #region Perk
        internal static bool DeletePerkFromVolunteer(string perk, Volunteer volunteer)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("DELETE FROM Perk WHERE perktext = :perktext AND personID = :personID");
                command.Parameters.Add(":perktext", perk);
                command.Parameters.Add(":personID", volunteer.ID);

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
        //Deletes a review from the database
        public static bool DeleteReview(Review review)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("DELETE FROM Review WHERE reviewID = :reviewID");
                command.Parameters.Add(":reviewID", review.ID);

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
        
        #region Meeting

        #endregion

        #region Request
        //Deletes a request from the database
        public static bool DeleteRequest(Request request)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("DELETE FROM Request WHERE requestID = :requestID");
                command.Parameters.Add(":requestID", request.ID);

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

        #region Response

        #endregion
        #endregion

        #endregion
    }
}
