using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using MyFigureCollection.Exceptions;
using Oracle.DataAccess.Client;
using Participation_ASP.Exceptions;


namespace Participation_ASP.Models
{
    public static class DatabaseManager
    {

        public static void TestConnection()
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    con.Open();
                    con.Close();
                }
                catch (Exception e)
                {
                    throw new DatabaseNotConnectedException(e.Message);
                }
            }
        }

        /// <summary>
        /// Gets a new OracleConnection with it's connection string set (using 'OracleConnectionString' from the web config).
        /// </summary>
        private static OracleConnection Connection
        {
            get
            {
                return
                    new OracleConnection(
                        ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString);
            }
        }



        public static bool AddSkill(string skill)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "INSERT INTO Skill (Description) VALUES (:Skill)"
                        );
                    cmd.Parameters.Add("Skill", skill);
                    con.Open();
                    return ExecuteNonQuery(cmd);
                }
                catch (OracleException e)
                {
                    if (Regex.IsMatch("UNIQUE", e.Message))
                    {
                        throw new ExistingSkillException(e.Message);
                    }
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static bool AddAvailability(int accountId, string day, string timeOfDay)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "INSERT INTO \"Availability\" (AccountId, Day, TimeOfDay) VALUES (:AccountId, :Day, :TimeOfDay)");
                    cmd.Parameters.Add("AccountId", accountId);
                    cmd.Parameters.Add("Day", day);
                    cmd.Parameters.Add("TimeOfDay", timeOfDay);
                    con.Open();
                    return ExecuteNonQuery(cmd);
                }
                catch (OracleException e)
                {
                    if (Regex.IsMatch("CHK_AVAILABILITY_DAY", e.Message))
                    {
                        throw new DayException(e.Message);
                    }

                    else if (Regex.IsMatch("CHK_AVAILABILITY_TIMEOFDAY", e.Message))
                    {
                        throw new TimeOfDayException(e.Message);
                    }
                    return false;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Creates an OracleCommand for the given query using the static OracleConnection field, and sets the CommandType to CommandType.Text (used for plain text queries).
        /// Used prior to adding parameters and executing the query.
        /// </summary>
        /// <param name="connection">The connection information, which should be made using the Connection property.</param>
        /// <param name="sql">Query string to run</param>
        /// <returns>OracleCommand with the query and Connection information set</returns>
        private static OracleCommand CreateOracleCommand(OracleConnection connection, string sql)
        {
            OracleCommand command = new OracleCommand(sql, connection);
            command.CommandType = System.Data.CommandType.Text;
            return command;
        }

        /// <summary>
        /// Runs the query of an OracleCommand, and returns an unread OracleDataReader with the results of the query.
        /// </summary>
        /// <param name="command">OracleCommand containing the data for the query</param>
        /// <returns>OracleDataReader with the result of the query</returns>
        private static OracleDataReader ExecuteQuery(OracleCommand command)
        {
            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        command.Connection.Open();
                    }
                    catch (OracleException exc)
                    {
                        Debug.WriteLine("Database Connection failed!\n" + exc.Message);
                        throw exc;
                    }
                }

                OracleDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Runs the command in the given OracleCommand with ExecuteNonQuery; which is used for queries where no data is returned (in an OracleDataReader).
        /// Return value indicates if any rows are updated.
        /// </summary>
        /// <param name="command">OracleCommand containing the data for the query.</param>
        /// <returns>True when at least one row is updated.</returns>
        private static bool ExecuteNonQuery(OracleCommand command)
        {
            if (command.Connection.State == ConnectionState.Closed)
            {
                command.Connection.Open();
            }

            return command.ExecuteNonQuery() != 0;
        }

        private static bool CheckReader(OracleDataReader reader)
        {
            return reader.HasRows;
        }


        #region Get
        public static List<IAccount> GetAccounts()
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con, "SELECT ad.AccountId as \"AdminId\", " +
                                                                 "v.AccountId as \"VolunteerId\", v.Birthdate, v.Photo, v.Vog, v.VogConfirmation, " +
                                                                 "p.Ov, p.AccountId as \"PatientId\", " +
                                                                 "a.AccountId as \"UserId\", a.Username, a.Password, a.Email, " +
                                                                 "u.Name, u.Phone, u.Datederegistration, u.Adress, u.Location, u.Car, u.DriversLicense, u.Rfid, u.Enabled " +
                                                                 "FROM \"User\" u " +
                                                                 "FULL OUTER JOIN \"Account\" a ON u.AccountId = a.AccountId " +
                                                                 "FULL OUTER JOIN \"Admin\" ad ON ad.AccountId = a.AccountId " +
                                                                 "FULL OUTER JOIN Volunteer v ON v.AccountId = a.AccountId " +
                                                                 "FULL OUTER JOIN Patient p ON a.AccountId = p.AccountId ");
                    var accounts = new List<IAccount>();
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        //User- and Account Data
                        int AccountId = new int();
                        if (reader["UserId"] != null)
                            AccountId = Convert.ToInt32(reader["UserId"].ToString());
                        string Username = reader["Username"].ToString();
                        string Password = reader["Password"].ToString();
                        string Email = reader["Email"].ToString();
                        string Name = reader["Name"].ToString();
                        string Phone = reader["Phone"].ToString();
                        DateTime DateDeregistration = new DateTime();
                        if (!string.IsNullOrEmpty(reader["DateDeregistration"].ToString()))
                            DateDeregistration = Convert.ToDateTime(reader["DateDeregistration"].ToString());
                        string Adress = reader["Adress"].ToString();
                        string Location = reader["Location"].ToString();
                        bool Car = false;
                        if (!string.IsNullOrEmpty(reader["Car"].ToString()))
                            Car = Convert.ToBoolean(Convert.ToInt32(reader["Car"].ToString()));
                        bool DriversLicense = false;
                        if (!string.IsNullOrEmpty(reader["DriversLicense"].ToString()))
                            DriversLicense = Convert.ToBoolean(Convert.ToInt32(reader["DriversLicense"].ToString()));
                        string Rfid = reader["Rfid"].ToString();
                        bool Enabled = true;
                        if (!string.IsNullOrEmpty(reader["Enabled"].ToString()))
                            Enabled = Convert.ToBoolean(Convert.ToInt32(reader["Enabled"].ToString()));

                        //Admin Data
                        if (!string.IsNullOrEmpty(reader["AdminId"].ToString()))
                        {
                        }

                        //Patient Data 
                        else if (!string.IsNullOrEmpty(reader["PatientId"].ToString()))
                        {
                            bool Ov = false;
                            if (!string.IsNullOrEmpty(reader["Ov"].ToString()))
                                Ov = Convert.ToBoolean(Convert.ToInt32(reader["Ov"].ToString()));
                            accounts.Add(new Patient(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Enabled, false, Ov));
                        }

                        //Volunteer Data
                        else if (!string.IsNullOrEmpty(reader["VolunteerId"].ToString()))
                        {

                            string Vog = reader["Vog"].ToString();
                            bool VogConfirmation = Convert.ToBoolean(Convert.ToInt32(reader["VogConfirmation"].ToString()));
                            DateTime Birthdate = new DateTime();
                            if (!string.IsNullOrEmpty(reader["Birthdate"].ToString()))
                                Birthdate = Convert.ToDateTime(reader["Birthdate"].ToString());
                            string Photo = reader["Photo"].ToString();
                            List<Review> reviews = GetReviews(AccountId);
                            if (!string.IsNullOrEmpty(reader["AdminId"].ToString()))
                            {
                                accounts.Add(new Volunteer(AccountId, Username, Password, Email, Name, Phone,
                                    DateDeregistration, Adress, Location, Car, DriversLicense, Rfid,
                                    Enabled, true, Birthdate, Photo, Vog, VogConfirmation, reviews));
                            }
                            else
                            {
                                accounts.Add(new Volunteer(AccountId, Username, Password, Email, Name, Phone,
                                    DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Enabled, false, Birthdate, Photo, Vog, VogConfirmation, reviews));
                            }
                        }
                    }
                    return accounts;
                }
                catch (OracleException e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static IAccount GetAccount(string email, string password)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con, "SELECT ad.AccountId as \"AdminId\", " +
                                                                 "v.AccountId as \"VolunteerId\", v.Birthdate, v.Photo, v.Vog, v.VogConfirmation, " +
                                                                 "p.Ov, p.AccountId as \"PatientId\", " +
                                                                 "a.AccountId as \"UserId\", a.Username, a.Password, a.Email, " +
                                                                 "u.Name, u.Phone, u.Datederegistration, u.Adress, u.Location, u.Car, u.DriversLicense, u.Rfid, u.Enabled " +
                                                                 "FROM \"User\" u " +
                                                                 "FULL OUTER JOIN \"Account\" a ON u.AccountId = a.AccountId " +
                                                                 "FULL OUTER JOIN \"Admin\" ad ON ad.AccountId = a.AccountId " +
                                                                 "FULL OUTER JOIN Volunteer v ON v.AccountId = a.AccountId " +
                                                                 "FULL OUTER JOIN Patient p ON a.AccountId = p.AccountId " +
                                                                 "WHERE a.Email = :Email AND a.Password = :Password");


                    cmd.Parameters.Add("Email", email);
                    cmd.Parameters.Add("Password", password);
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        //User- and Account Data
                        int AccountId = new int();
                        if (reader["UserId"] != null)
                            AccountId = Convert.ToInt32(reader["UserId"].ToString());
                        string Username = reader["Username"].ToString();
                        string Password = reader["Password"].ToString();
                        string Email = reader["Email"].ToString();
                        string Name = reader["Name"].ToString();
                        string Phone = reader["Phone"].ToString();
                        DateTime DateDeregistration = new DateTime();
                        if (!string.IsNullOrEmpty(reader["DateDeregistration"].ToString()))
                            DateDeregistration = Convert.ToDateTime(reader["DateDeregistration"].ToString());
                        string Adress = reader["Adress"].ToString();
                        string Location = reader["Location"].ToString();

                        bool Car = false;
                        if (!string.IsNullOrEmpty(reader["Car"].ToString()))
                            Car = Convert.ToBoolean(Convert.ToInt32(reader["Car"].ToString()));

                        bool DriversLicense = false;
                        if (!string.IsNullOrEmpty(reader["DriversLicense"].ToString()))
                            DriversLicense = Convert.ToBoolean(Convert.ToInt32(reader["DriversLicense"].ToString()));

                        string Rfid = reader["Rfid"].ToString();

                        bool Enabled = true;
                        if (!string.IsNullOrEmpty(reader["Enabled"].ToString()))
                            Enabled = Convert.ToBoolean(Convert.ToInt32(reader["Enabled"].ToString()));


                        //Admin Data
                        if (!string.IsNullOrEmpty(reader["AdminId"].ToString()))
                        {
                            bool IsAdmin = true;
                            return new Account(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Enabled, IsAdmin);
                        }

                        //Patient Data 
                        else if (!string.IsNullOrEmpty(reader["PatientId"].ToString()))
                        {
                            bool Ov = false;
                            if (!string.IsNullOrEmpty(reader["Ov"].ToString()))
                                Ov = Convert.ToBoolean(Convert.ToInt32(reader["Ov"].ToString()));
                            return new Patient(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Enabled, false, Ov);
                        }

                        //Volunteer Data
                        else if (!string.IsNullOrEmpty(reader["VolunteerId"].ToString()))
                        {
                            string Vog = reader["Vog"].ToString();
                            bool VogConfirmation = Convert.ToBoolean(Convert.ToInt32(reader["VogConfirmation"].ToString()));
                            DateTime Birthdate = new DateTime();
                            if (!string.IsNullOrEmpty(reader["Birthdate"].ToString()))
                                Birthdate = Convert.ToDateTime(reader["Birthdate"].ToString());
                            string Photo = reader["Photo"].ToString();
                            List<Review> reviews = GetReviews(AccountId);
                            return new Volunteer(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Enabled, false, Birthdate, Photo, Vog, VogConfirmation, reviews);
                        }
                        else
                        {
                            return new Account(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress,
                                Location, Car, DriversLicense, Rfid, Enabled, false);
                        }
                    }
                    return null;
                }
                catch (OracleException e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private static List<Review> GetReviews(int accountId)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT r.ReviewId, r.Requestid, r.Rating, r.\"Comment\" " +
                        "FROM Review r " +
                        "INNER JOIN Volunteer v ON v.AccountId = r.AccountId WHERE v.AccountId = :AccountId");


                    cmd.Parameters.Add("AccountId", accountId);
                    var reviews = new List<Review>();
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        int ReviewId = new int();
                        if (!string.IsNullOrEmpty(reader["ReviewId"].ToString()))
                            ReviewId = Convert.ToInt32(reader["ReviewId"].ToString());
                        int RequestId = new int();
                        if (!string.IsNullOrEmpty(reader["Requestid"].ToString()))
                            RequestId = Convert.ToInt32(reader["Requestid"].ToString());
                        Request request = GetRequest(RequestId);
                        int Rating = new int();
                        if (!string.IsNullOrEmpty(reader["Rating"].ToString()))
                            Rating = Convert.ToInt32(reader["Rating"].ToString());
                        string Comment = reader["Comment"].ToString();
                        reviews.Add(new Review(ReviewId, request, Rating, Comment));
                    }
                    return reviews;
                }
                catch (OracleException e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static Request GetRequest(int requestId)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT r.AccountId, r.RequestId, r.Location, r.TravelTime, r.StartDate, r.EndDate, " +
                        "r.Urgency, r.AmountOfVolunteers, " +
                        "v.VehicleTypeId, v.Description, " +
                        "p.OV, " +
                        "a.Username, a.Email, a.Password, " +
                        "u.Name, u.Phone, u.Datederegistration, u.Adress, u.Location as \"UserLocation\", " +
                        "u.Car, u.DriversLicense, u.RfId, u.Enabled " +
                        "FROM VehicleType v " +
                        "RIGHT JOIN Request r ON r.RequestId = v.RequestId " +
                        "LEFT JOIN Patient p ON p.AccountId = r.AccountId " +
                        "LEFT JOIN \"User\" u ON u.AccountId = p.AccountId " +
                        "LEFT JOIN \"Account\" a ON u.AccountId = a.AccountId " +
                        "WHERE r.RequestId = :RequestId");
                    cmd.Parameters.Add("RequestId", requestId);
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        //User- and Account Data
                        int AccountId = new int();
                        if (reader["AccountId"] != null)
                            AccountId = Convert.ToInt32(reader["AccountId"].ToString());
                        string Username = reader["Username"].ToString();
                        string Password = reader["Password"].ToString();
                        string Email = reader["Email"].ToString();
                        string Name = reader["Name"].ToString();
                        string Phone = reader["Phone"].ToString();
                        DateTime DateDeregistration = new DateTime();
                        if (!string.IsNullOrEmpty(reader["DateDeregistration"].ToString()))
                            DateDeregistration = Convert.ToDateTime(reader["DateDeregistration"].ToString());
                        string Adress = reader["Adress"].ToString();
                        bool Car = Convert.ToBoolean(Convert.ToInt32(reader["Car"].ToString()));
                        bool DriversLicense = Convert.ToBoolean(Convert.ToInt32(reader["DriversLicense"].ToString()));
                        string Rfid = reader["Rfid"].ToString();
                        bool Enabled = Convert.ToBoolean(Convert.ToInt32(reader["Enabled"].ToString()));

                        //Request Data
                        int ReqId = new int();
                        if (!string.IsNullOrEmpty(reader["RequestId"].ToString()))
                            ReqId = Convert.ToInt32(reader["RequestId"].ToString());
                        string Location = reader["Location"].ToString();
                        int TravelTime = new int();
                        if (!string.IsNullOrEmpty(reader["TravelTime"].ToString()))
                            Convert.ToInt32(reader["TravelTime"].ToString());
                        DateTime StartDate = new DateTime();
                        if (!string.IsNullOrEmpty(reader["StartDate"].ToString()))
                            StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                        DateTime EndDate = new DateTime();
                        if (!string.IsNullOrEmpty(reader["EndDate"].ToString()))
                            EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                        int Urgency = new int();
                        if (!string.IsNullOrEmpty(reader["Urgency"].ToString()))
                            Urgency = Convert.ToInt32(reader["Urgency"].ToString());
                        int AmountOfVolunteers = new int();
                        if (!string.IsNullOrEmpty(reader["AmountOfVolunteers"].ToString()))
                            AmountOfVolunteers = Convert.ToInt32(reader["AmountOfVolunteers"].ToString());
                        string Description = reader["Description"].ToString();

                        //Patient Data
                        bool Ov = false;
                        if (!string.IsNullOrEmpty(reader["Ov"].ToString()))
                            Ov = Convert.ToBoolean(Convert.ToInt32(reader["Ov"].ToString()));

                        //Vehicle Data
                        int VehicleTypeId = new int();
                        if (!string.IsNullOrEmpty(reader["VehicleTypeId"].ToString()))
                            VehicleTypeId = Convert.ToInt32(reader["VehicleTypeId"].ToString());
                        string VehicleDescription = reader["Description"].ToString();

                        //Get Skill Data
                        List<Skill> skills = GetSkills(AccountId);

                        //Get Response Data
                        List<Response> responses = GetResponses(ReqId);

                        return new Request(ReqId, Description, Location, TravelTime, StartDate, EndDate, Urgency, AmountOfVolunteers, skills, new VehicleType(VehicleTypeId, VehicleDescription), new Patient(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Enabled, false, Ov), responses);

                    }
                    return null;
                }
                catch (OracleException e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static List<Request> GetRequests()
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT r.AccountId, r.RequestId, r.Location, r.TravelTime, r.StartDate, r.EndDate, " +
                        "r.Urgency, r.AmountOfVolunteers, " +
                        "v.VehicleTypeId, v.Description, " +
                        "p.OV, " +
                        "a.Username, a.Email, a.Password, " +
                        "u.Name, u.Phone, u.Datederegistration, u.Adress, u.Location as \"UserLocation\", " +
                        "u.Car, u.DriversLicense, u.RfId, u.Enabled " +
                        "FROM VehicleType v " +
                        "RIGHT JOIN Request r ON r.RequestId = v.RequestId " +
                        "LEFT JOIN Patient p ON p.AccountId = r.AccountId " +
                        "LEFT JOIN \"User\" u ON u.AccountId = p.AccountId " +
                        "LEFT JOIN \"Account\" a ON u.AccountId = a.AccountId ");

                    var requests = new List<Request>();
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        //User- and Account Data
                        int AccountId = new int();
                        if (reader["AccountId"] != null)
                            AccountId = Convert.ToInt32(reader["AccountId"].ToString());
                        string Username = reader["Username"].ToString();
                        string Password = reader["Password"].ToString();
                        string Email = reader["Email"].ToString();
                        string Name = reader["Name"].ToString();
                        string Phone = reader["Phone"].ToString();
                        DateTime DateDeregistration = new DateTime();
                        if (!string.IsNullOrEmpty(reader["DateDeregistration"].ToString()))
                            DateDeregistration = Convert.ToDateTime(reader["DateDeregistration"].ToString());
                        string Adress = reader["Adress"].ToString();
                        bool Car = Convert.ToBoolean(Convert.ToInt32(reader["Car"].ToString()));
                        bool DriversLicense = Convert.ToBoolean(Convert.ToInt32(reader["DriversLicense"].ToString()));
                        string Rfid = reader["Rfid"].ToString();
                        bool Enabled = Convert.ToBoolean(Convert.ToInt32(reader["Enabled"].ToString()));

                        //Request Data
                        int ReqId = new int();
                        if (!string.IsNullOrEmpty(reader["RequestId"].ToString()))
                            ReqId = Convert.ToInt32(reader["RequestId"].ToString());
                        string Location = reader["Location"].ToString();
                        int TravelTime = new int();
                        if (!string.IsNullOrEmpty(reader["TravelTime"].ToString()))
                            Convert.ToInt32(reader["TravelTime"].ToString());
                        DateTime StartDate = new DateTime();
                        if (!string.IsNullOrEmpty(reader["StartDate"].ToString()))
                            StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                        DateTime EndDate = new DateTime();
                        if (!string.IsNullOrEmpty(reader["EndDate"].ToString()))
                            EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                        int Urgency = new int();
                        if (!string.IsNullOrEmpty(reader["Urgency"].ToString()))
                            Urgency = Convert.ToInt32(reader["Urgency"].ToString());
                        int AmountOfVolunteers = new int();
                        if (!string.IsNullOrEmpty(reader["AmountOfVolunteers"].ToString()))
                            AmountOfVolunteers = Convert.ToInt32(reader["AmountOfVolunteers"].ToString());
                        string Description = reader["Description"].ToString();

                        //Patient Data
                        bool Ov = false;
                        if (!string.IsNullOrEmpty(reader["Ov"].ToString()))
                            Ov = Convert.ToBoolean(Convert.ToInt32(reader["Ov"].ToString()));

                        //Vehicle Data
                        int VehicleTypeId = new int();
                        if (!string.IsNullOrEmpty(reader["VehicleTypeId"].ToString()))
                            VehicleTypeId = Convert.ToInt32(reader["VehicleTypeId"].ToString());
                        string VehicleDescription = reader["Description"].ToString();

                        //Get Skill Data
                        List<Skill> skills = GetSkills(AccountId);

                        //Get Response Data
                        List<Response> responses = GetResponses(ReqId);

                        requests.Add(new Request(ReqId, Description, Location, TravelTime, StartDate, EndDate, Urgency, AmountOfVolunteers, skills, new VehicleType(VehicleTypeId, VehicleDescription), new Patient(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Enabled, false, Ov), responses));

                    }
                    return requests;
                }
                catch (OracleException e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private static List<Skill> GetSkills(int requestId)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT s.SkillId, s.Description FROM Skill s LEFT JOIN RequestSkill rs ON rs.SkillId = s.SkillId RIGHT JOIN Request r ON r.RequestId = rs.RequestId WHERE r.RequestId = :RequestId");
                    cmd.Parameters.Add("RequestId", requestId);
                    var skills = new List<Skill>();
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        int skillId = new int();
                        if (!string.IsNullOrEmpty(reader["SkillId"].ToString()))
                            skillId = Convert.ToInt32(reader["SkillId"].ToString());
                        string Description = reader["Description"].ToString();
                        skills.Add(new Skill(skillId, Description));
                    }
                    return skills;
                }
                catch (OracleException e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private static List<Response> GetResponses(int requestId)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT res.RequestId, res.ResponseDate, res.Description, " +
                        "v.AccountId, v.Vog, v.VogConfirmation, v.Photo, v.Birthdate, " +
                        "u.Name, u.Phone, u.DateDeregistration, u.Adress, u.Location AS UserLocation, " +
                        "u.Car, u.DriversLicense, u.Rfid, u.Enabled, " +
                        "a.Username, a.Password, a.Email " +
                        "FROM Request req " +
                        "RIGHT JOIN Response res ON req.RequestId = res.RequestId " +
                        "LEFT JOIN Volunteer v ON v.AccountId = res.ResponderId " +
                        "LEFT JOIN \"User\" u ON u.AccountId = v.AccountId " +
                        "LEFT JOIN \"Account\" a ON a.AccountId = u.AccountId " +
                        "WHERE res.RequestId = :RequestId");
                    cmd.Parameters.Add("RequestId", requestId);
                    var responses = new List<Response>();
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        //User- and Account Data
                        int AccountId = new int();
                        if (reader["AccountId"] != null)
                            AccountId = Convert.ToInt32(reader["AccountId"].ToString());
                        string Username = reader["Username"].ToString();
                        string Password = reader["Password"].ToString();
                        string Email = reader["Email"].ToString();
                        string Name = reader["Name"].ToString();
                        string Phone = reader["Phone"].ToString();
                        string UserLocation = reader["UserLocation"].ToString();
                        DateTime DateDeregistration = new DateTime();
                        if (!string.IsNullOrEmpty(reader["DateDeregistration"].ToString()))
                            DateDeregistration = Convert.ToDateTime(reader["DateDeregistration"].ToString());
                        string Adress = reader["Adress"].ToString();
                        bool Car = Convert.ToBoolean(Convert.ToInt32(reader["Car"].ToString()));
                        bool DriversLicense = Convert.ToBoolean(Convert.ToInt32(reader["DriversLicense"].ToString()));
                        string Rfid = reader["Rfid"].ToString();
                        bool Enabled = Convert.ToBoolean(Convert.ToInt32(reader["Enabled"].ToString()));

                        //Volunteer Data
                        string Vog = reader["Vog"].ToString();
                        bool VogConfirmation = Convert.ToBoolean(Convert.ToInt32(reader["VogConfirmation"].ToString()));
                        DateTime Birthdate = new DateTime();
                        if (!string.IsNullOrEmpty(reader["Birthdate"].ToString()))
                            Birthdate = Convert.ToDateTime(reader["Birthdate"].ToString());
                        string Photo = reader["Photo"].ToString();

                        //TODO Maybe add List<Review> to this instance of volunteer
                        var volunteer = new Volunteer(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, UserLocation, Car, DriversLicense, Rfid, Enabled, false, Birthdate, Photo, Vog, VogConfirmation);

                        //Response Data
                        //res.RequestId, res.ResponseDate, res.Description
                        //var RequestId = requestId;
                        DateTime ResponseDate = new DateTime();
                        if (!string.IsNullOrEmpty(reader["ResponseDate"].ToString()))
                            ResponseDate = Convert.ToDateTime(reader["ResponseDate"].ToString());
                        string Description = reader["Description"].ToString();

                        responses.Add(new Response(volunteer, Description, ResponseDate));
                    }
                    return responses;
                }
                catch (OracleException e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static List<Skill> GetSkills(Volunteer volunteer)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT s.SkillId, s.Description FROM Skill s RIGHT JOIN VolunteerSkill vs ON vs.SkillId = s.SkillId LEFT JOIN Volunteer v ON v.AccountId = vs.AccountId WHERE v.AccountId = :AccountId");
                    cmd.Parameters.Add("RequestId", volunteer.AccountId);
                    var skills = new List<Skill>();
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        string Description = reader["Description"].ToString();
                        int SkillId = new int();
                        if (!string.IsNullOrEmpty(reader["SkillId"].ToString()))
                            SkillId = Convert.ToInt32(reader["SkillId"].ToString());
                        skills.Add(new Skill(SkillId, Description));
                    }
                    return skills;
                }
                catch (OracleException e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static List<Skill> GetSkills()
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT s.SkillId, s.Description FROM Skill s");
                    var skills = new List<Skill>();
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        string Description = reader["Description"].ToString();
                        int SkillId = new int();
                        if (!string.IsNullOrEmpty(reader["SkillId"].ToString()))
                            SkillId = Convert.ToInt32(reader["SkillId"].ToString());
                        skills.Add(new Skill(SkillId, Description));
                    }
                    return skills;
                }
                catch (OracleException e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static List<Availability> GetAvailabilities(Volunteer volunteer)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT a.Day, a.TimeOfDay " +
                        "FROM \"Availability\" a " +
                        "INNER JOIN Volunteer v ON v.AccountId = a.AccountId " +
                        "WHERE a.AccountId = :AccountId"
                        );
                    cmd.Parameters.Add("AccountId", volunteer.AccountId);
                    var availabilities = new List<Availability>();
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        string Day = reader["Day"].ToString();
                        string TimeOfDay = reader["TimeOfDay"].ToString();
                        availabilities.Add(new Availability(Day, TimeOfDay));
                    }
                    return availabilities;
                }
                catch (OracleException e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static bool AddAccount(IAccount account)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    //Add Account
                    bool succes = false;
                    OracleCommand cmd = CreateOracleCommand(con, "INSERT INTO \"Account\" (Username, Password, Email) VALUES (:Username, :Password, :Email)");
                    cmd.Parameters.Add("Username", account.Username);
                    cmd.Parameters.Add("Password", account.Password);
                    cmd.Parameters.Add(":Email", account.Email);
                    succes = ExecuteNonQuery(cmd);

                    //Add User
                    int AccountId = GetAccount(account.Email, account.Password).AccountId;
                    cmd = CreateOracleCommand(con,
                        "INSERT INTO \"User\"(AccountId, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid) " +
                        "VALUES(:AccountId, :Name, :Phone, :DateDeregistration, :Adress, :Location, :Car, :DriversLicense, :Rfid)");
                    cmd.Parameters.Add("AccountId", AccountId);
                    cmd.Parameters.Add("Name", account.Name);
                    cmd.Parameters.Add("Phone", account.Phone);
                    cmd.Parameters.Add("DateDeregistration", account.DateCancellation);
                    cmd.Parameters.Add("Adress", account.Adress);
                    cmd.Parameters.Add("Location", account.Location);
                    cmd.Parameters.Add("Car", Convert.ToInt32(account.HasCar));
                    cmd.Parameters.Add("DriversLicense", Convert.ToInt32(account.HasDriversLicense));
                    cmd.Parameters.Add("Rfid", account.Rfid);
                    succes = ExecuteNonQuery(cmd);

                    if (account is Volunteer)
                    {
                        var volunteer = (Volunteer)account;
                        cmd = CreateOracleCommand(con,
                            "INSERT INTO Volunteer (AccountId, Vog, Birthdate, Photo) VALUES(:AccountId, :Vog, :Birthdate, :Photo)");
                        cmd.Parameters.Add("AccountId", AccountId);
                        cmd.Parameters.Add("Vog", volunteer.Vog);
                        cmd.Parameters.Add("Birthdate", volunteer.BirthDate);
                        cmd.Parameters.Add("Photo", volunteer.Photo);
                        succes = ExecuteNonQuery(cmd);
                    }
                    if (account is Patient)
                    {
                        var patient = (Patient)account;
                        cmd = CreateOracleCommand(con,
                            "INSERT INTO Patient (AccountId, Ov) VALUES (:AccountId, :Ov)");
                        cmd.Parameters.Add("AccountId", AccountId);
                        cmd.Parameters.Add("Ov", Convert.ToInt32(patient.Ov));
                        succes = ExecuteNonQuery(cmd);
                    }
                    return succes;
                }
                catch (OracleException e)
                {
                    if (Regex.IsMatch("UNIQUE", e.Message))
                        throw new ExistingUserException();
                    return false;
                }
                catch (Exception e)
                {
                    //TODO Needs proper exception handling
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        //Must
        public static bool AlterVolunteerSkills(List<Skill> skills, int accountId)
        {
            using (OracleConnection con = new OracleConnection())
            {
                //    try
                //    {
                //        OracleCommand cmd = CreateOracleCommand(con, 
                //            "UPDATE Skill SET Description ");
                //        cmd.Parameters.Add("Username", account.Username);
                //        cmd.Parameters.Add("Password", account.Password);
                //        cmd.Parameters.Add(":Email", account.Email);
                //    }
                //    catch (OracleException e)
                //    {
                //        throw e;
                //    }
                //    catch (Exception e)
                //    {
                //        throw e;
                //    }
                //    finally
                //    {
                //        con.Close();
                //    }
                //}
                throw new NotImplementedException();
            }
        }

        public static bool AddRequest(Request request)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand insertCommand = CreateOracleCommand(connection,
                        "INSERT INTO REQUEST (AccountID, Description, Location, TravelTime, StartDate, EndDate, Urgency, AmountofVolunteers) VALUES(:patientID, :description, :location, :travelTime, :startDate, :endDate, :urgency, :amountOfVolunteers)");
                    insertCommand.Parameters.Add(":patientID", request.Patient.AccountId);
                    insertCommand.Parameters.Add(":description", request.Description);
                    insertCommand.Parameters.Add(":location", request.Location);
                    insertCommand.Parameters.Add(":travelTime", request.TravelTime);
                    insertCommand.Parameters.Add(":startDate", request.StartDate);
                    insertCommand.Parameters.Add(":endDate", request.EndDate);
                    insertCommand.Parameters.Add(":urgency", request.Urgency);
                    insertCommand.Parameters.Add(":amountOfVolunteers", request.AmountOfVolunteers);


                    if (ExecuteNonQuery(insertCommand))
                    {
                        int requestID = 0;
                        OracleCommand selectCommand = CreateOracleCommand(connection,
                            "SELECT MAX(REQUESTID) FROM REQUEST");
                        OracleDataReader MainReader = ExecuteQuery(selectCommand);

                        while (MainReader.Read())
                        {
                            requestID = Convert.ToInt32(MainReader["MAX(REQUESTID)"].ToString());
                        }
                        int skillcount = request.Skills.Count;
                        int count = 0;

                        OracleCommand vehicleCommand = CreateOracleCommand(connection, "INSERT INTO VEHICLETYPE(RequestID, Description) VALUES(:requestID, :description)");
                        vehicleCommand.Parameters.Add(":requestID", requestID);
                        vehicleCommand.Parameters.Add(":description", request.VehicleType.Description);
                        if (ExecuteNonQuery(vehicleCommand))
                        {
                            foreach (Skill s in request.Skills)
                            {
                                OracleCommand subinsertCommand = CreateOracleCommand(connection, "INSERT INTO REQUESTSKILL (RequestID, SkillID) VALUES (:requestID, :skillID)");
                                subinsertCommand.Parameters.Add(":requestID", requestID);
                                subinsertCommand.Parameters.Add(":skillID", s.Id);
                                if (ExecuteNonQuery(subinsertCommand))
                                {
                                    count++;
                                }
                            }
                            if (count >= skillcount)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        //TODO Sander
        public static bool AddMeeting(Meeting meeting)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand insertCommand = CreateOracleCommand(connection,
                        "INSERT INTO MEETING (VolunteerID, PatientID, Location, MeetingDate, Status) VALUES (:volunteerID, :patientID, :location, :meetingDate, :status");
                    insertCommand.Parameters.Add(":volunteerID", meeting.Volunteer.AccountId);
                    insertCommand.Parameters.Add(":patientID", meeting.Patient.AccountId);
                    insertCommand.Parameters.Add(":location", meeting.Location);
                    insertCommand.Parameters.Add(":meetingDate", meeting.Date);
                    insertCommand.Parameters.Add(":status", meeting.Status);

                    return ExecuteNonQuery(insertCommand);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        //TODO Sander
        public static bool AlterMeeting(Meeting meeting)
        {
            //Voor het accepteren/weigeren van een meeting
            throw new NotImplementedException();
        }

        //TODO Sander
        public static bool AddResponse(Response response, Request request)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand insertCommand = CreateOracleCommand(connection,
                        "INSERT INTO RESPONSE (ResponderID, RequestID, ResponseDate, Description) Values(:responderID, :requestID, :responseDate, :description");
                    insertCommand.Parameters.Add(":responderID", response.Volunteer.AccountId);
                    insertCommand.Parameters.Add(":requestID", request.RequestId);
                    insertCommand.Parameters.Add(":responseDate", response.ResponseDate);
                    insertCommand.Parameters.Add(":description", response.Description);

                    return ExecuteNonQuery(insertCommand);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        //TODO Sven H
        public static bool GetProfile(int ID)
        {
            throw new NotImplementedException();
        }

        //TODO Sven J
        public static bool AlterAdmin(int accountId)
        {
            throw new NotImplementedException();
        }

        //TODO Tom
        public static bool DeleteRequest(int ID)
        {
            throw new NotImplementedException();
        }

        //TODO Tom
        public static bool DeleteReview(int ID)
        {
            using (OracleConnection con = new OracleConnection())
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "DELETE FROM");
                    return ExecuteNonQuery(cmd);
                }
                catch (OracleException e)
                {
                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

        //TODO Tom
        public static bool AddReview(int ID)
        {
            throw new NotImplementedException();
        }

        //TODO Sven J
        public static bool AlterEnabled(int ID)
        {
            throw new NotImplementedException();
        }

        //TODO Sven J
        public static bool AlterVogConfirmation(int ID)
        {
            throw new NotImplementedException();
        }

        //TODO Sander
        public static List<Meeting> GetMeetings()
        {
            throw new NotImplementedException();
        }

        //TODO Tom fix review adressering, request beschrijving bug, fix amount of volunteers/implementeer list<Volunteer> bij een request
        #endregion
    }
}