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


namespace Participation
{
    public static class DatabaseManager
    {
        #region Fields
        //Database connection; uses Connectionstring
        private static OracleConnection _Connection = new OracleConnection(_ConnectionString);
        //Temp data for connecting to the database; [Username], [Password], [server-IP]
        private const string _ConnectionId = "PTS29", _ConnectionPassword = "PTS29", _ConnectionAddress = "//192.168.20.29:1521/xe";
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
        //Creates a list of meetings and returns it to the user-creation method
        public static List<Meeting> CreateMeetingList(int UserID)
        {
            OracleCommand command = CreateOracleCommand("SELECT * FROM Person");
            OracleDataReader reader = ExecuteQuery(command);

            

            return null;
        }
        #endregion

        #region Methods - AdministrationSystem
        //Returns list of users.
        internal static List<User> GetUsers()
        {
            try
            {
                OracleCommand command = CreateOracleCommand("SELECT * FROM Person");
                OracleDataReader reader = ExecuteQuery(command);

                List<User> UserList = new List<User>();

                while(reader.Read())
                {
                    try 
                    {
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
                            UserList.Add(new Volunteer(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password));
                        }
                        if (PersonType == "Patient")
                        {
                            UserList.Add(new Patient(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password));
                        }
                        if (PersonType == "Admin")
                        {
                            UserList.Add(new Volunteer(Name, EmailAdress, Description, DateOfBirth, Location, PhoneNumber, Gender, Password));
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
            }
            catch
            {
                throw new NotImplementedException();
            }
            finally
            {
                _Connection.Close();
            }

        }

        //Returns list of Requests
        internal static List<Request> GetRequests()
        {
            throw new NotImplementedException();
        }

        //Returns list of Reviews
        internal static List<Review> GetReviews()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Methods - PatientSystem

        #endregion

        #region Methods - VolunteerSystem

        #endregion

        #region Shared methods
        internal static bool AddUser(IUser user)
        {
            if (user.getType() ==)
            OracleCommand command = CreateOracleCommand("INSERT INTO Person VALUES(:naam)");
            command.Parameters.Add(":Email", Email);
            command.Parameters.Add(":Email", user.Email);
            OracleDataReader reader = ExecuteQuery(command);

        }


        internal static 
        #endregion

        #region Methods - ChatSystem

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
