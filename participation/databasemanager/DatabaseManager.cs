
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
                
                OracleCommand command = CreateOracleCommand("INSERT INTO Person(personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password) VALUES(:personType, :name, :email, :description, :dateOfBirth, :profilePicture, :location, :phone, :gender, :password)");

                if (user.GetType() == typeof(Patient))
                {
                    command.Parameters.Add(":personType", "Patient");
                }
                if (user.GetType() == typeof(Volunteer))
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
        #endregion

        #region Review
        internal static bool AddReview(Review review)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("INSERT INTO Review(reviewID, reviewerID, revieweeID, rating, description) VALUES(:reviewID, :reviewerID, :revieweeID, :rating, :description)");

                //command.Parameters.Add(":reviewID", review.reviewID);
                //command.Parameters.Add(":reviewerID", review.reviewer.ID); 
                //command.Parameters.Add(":revieweeID", review.Reviewee.ID);
                //command.Parameters.Add(":rating", review.rating);
                //command.Parameters.Add(":description", review.description);

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

        #endregion

        #region Response

        #endregion     
        #endregion

        #region Get
        #region User

        //Pulls the accountinformation from the database, and casts it into an user-object
        public static User CreateUser(string Email)
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
                    //return new Volunteer( );
                }
                if (PersonType == "Patient")
                {
                   //return new Patient(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password);
                }
                if (PersonType == "Admin")
                {
                    //return new Volunteer(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password);
                }
            }
            catch(Exception exception)
            {
                throw new Exception("Something went wrong: " + exception.Message);
            }
            finally
            {
                
               
                _Connection.Close();
                
            }
            return null;
        }

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

                    //ReviewList.Add(new Review(rating, description));
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
            return ReviewList;
        }
        #endregion

        #region Meeting
        //Creates a list of meetings
        public static List<Meeting> CreateMeetingList(int UserID)
        {
            //OracleCommand command = CreateOracleCommand("SELECT * FROM Meeting;");
            //OracleDataReader reader = ExecuteQuery(command);

            return null;
        }
        #endregion

        #region Request
        //Returns list of Requests
        internal static List<Request> GetRequests()
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

                    //RequestList.Add(new Request(title, description, perks, location, date, urgency));
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

        #endregion

        #region Meeting


        #region Example

        #endregion

        #region Request

        #endregion

        #region Response

        #endregion
        #endregion

        #endregion

        #endregion
    }
}
