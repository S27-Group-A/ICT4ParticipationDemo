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
        private const string ConnectionId = "dbi330810", ConnectionPassword = " Jm3AQLBVXo", _ConnectionAddress = "//fhictora01.fhict.local/fhictora";
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



        #region Methods - AuthenticationSystem
        
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
        //Creates a list of meetings
        public static List<Meeting> CreateMeetingList(int UserID)
        {
            OracleCommand command = CreateOracleCommand("SELECT * FROM Meeting;");
            OracleDataReader reader = ExecuteQuery(command);

            

            return null;
        }
        #endregion

        #region Methods - AdministrationSystem
        //Returns list of users.
        internal static List<User> GetUsers()
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

        //Returns list of Requests
        internal static List<Request> GetRequests()
        {
            List<Request> RequestList = new List<Request>();
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Request;");
                OracleDataReader reader = ExecuteQuery(command);

                while(reader.Read())
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

        #region Methods - PatientSystem

        #endregion

        #region Methods - VolunteerSystem

        #endregion

        #region Methods - ChatSystem

        #endregion



        #region Shared methods
        //Inserts new userinformation into the database
        internal static bool AddUser(IUser user)
        {
            try
            {
                var testP = new Patient();
                var testV = new Volunteer();
                OracleCommand command = CreateOracleCommand("INSERT INTO Person(personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password) VALUES(:personType, :name, :email, :description, :dateOfBirth, :profilePicture, :location, :phone, :gender, :password)");

                if (user.GetType() == testP.GetType())
                {
                    command.Parameters.Add(":personType", "Patient");
                }
                if (user.GetType() == testV.GetType())
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

        #region Example
        /// <summary>
        /// Example of a database query, casted to a specific return type
        /// </summary>
        /// <param name="sql_Values"></param>
        /// <returns></returns>
        public static object Testquery(string sql_Values)
        {
            try
            {
                OracleCommand command = CreateOracleCommand("QUERY");
                //command.Parameters.Add(":returnvalue in query", Value in parameter method);
                OracleDataReader reader = ExecuteQuery(command);

                if (!reader.HasRows)
                {
                    return null;
                }

                reader.Read();

                object something = new object(); //Not in code
                return something;
                //return parseDatatype(); creates an object (make a method for this)

                
            }
            finally
            {
                _Connection.Close();
            }
        }
        #endregion
    }
}
