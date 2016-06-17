namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using MyFigureCollection.Exceptions;
    using Oracle.DataAccess.Client;
    using Participation_ASP.Exceptions;

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

        /// <summary>
        /// Adds a skill to the database table
        /// </summary>
        /// <param name="skill">skill description</param>
        /// <returns></returns>
        public static bool AddSkill(string skill)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "INSERT INTO Skill (Description) VALUES (:Skill)");
                    cmd.Parameters.Add("Skill", skill);
                    con.Open();
                    return ExecuteNonQuery(cmd);
                }
                catch (OracleException e)
                {
                    if (e.Message.StartsWith("ORA-00001: unique constraint"))
                    {
                        throw new ExistingSkillException(e.Message);
                    }
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static bool AddVolunteerSkill(Volunteer volunteer, Skill skill)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "INSERT INTO VolunteerSkill (AccountId, SkillId) VALUES (:AccountId, :SkillId)");
                    cmd.Parameters.Add("AccountId", volunteer.AccountId);
                    cmd.Parameters.Add("Skillid", skill.Id);
                    con.Open();
                    return ExecuteNonQuery(cmd);
                }
                catch (OracleException e)
                {
                    if (e.Message.StartsWith("ORA-00001: unique constraint"))
                    {
                        throw new ExistingSkillException(e.Message);
                    }
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Adds a availability to the availability table
        /// </summary>
        /// <param name="accountId">account identifier</param>
        /// <param name="day">day in the format of {Mo, Di, Wo, Do, Vr, Za, Zo}</param>
        /// <param name="timeOfDay">time of day in format of {ochtend, middag, avond}</param>
        /// <returns></returns>
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
                    if (Regex.IsMatch("CHK_AVAILABILITY_DAY", e.Message, RegexOptions.IgnoreCase))
                    {
                        throw new DayException(e.Message);
                    }

                    else if (Regex.IsMatch("CHK_AVAILABILITY_TIMEOFDAY", e.Message, RegexOptions.IgnoreCase))
                    {
                        throw new TimeOfDayException(e.Message);
                    }
                    return false;
                }
                catch (Exception e)
                {

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

        /// <summary>
        /// Checks wether the current reader has any rows
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static bool CheckReader(OracleDataReader reader)
        {
            return reader.HasRows;
        }

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



                        //Patient Data 
                        if (!string.IsNullOrEmpty(reader["PatientId"].ToString()))
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
                            List<Availability> availabilities = GetAvailabilities(AccountId);
                            var temp = new Volunteer();
                            temp.AccountId = AccountId;
                            List<Skill> skills = GetSkills(temp);
                            if (!string.IsNullOrEmpty(reader["AdminId"].ToString()))
                            {
                                var volunteer = new Volunteer(AccountId, Username, Password, Email, Name, Phone,
                                    DateDeregistration, Adress, Location, Car, DriversLicense, Rfid,
                                    Enabled, true, Birthdate, Photo, Vog, VogConfirmation, reviews);
                                volunteer.Availabilities = availabilities;
                                volunteer.Skills = skills;
                                accounts.Add(volunteer);
                            }
                            else
                            {
                                var volunteer = new Volunteer(AccountId, Username, Password, Email, Name, Phone,
                                    DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Enabled, false,
                                    Birthdate, Photo, Vog, VogConfirmation, reviews);
                                volunteer.Availabilities = availabilities;
                                volunteer.Skills = skills;
                                accounts.Add(volunteer);
                            }
                        }
                    }
                    return accounts;
                }
                catch (OracleException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Gets an account based on it's AccountId
        /// </summary>
        /// <param name="id">account identifier</param>
        /// <returns>Patient or Volunteer</returns>
        public static IAccount GetAccount(int id)
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
                                                                 "WHERE a.AccountId = :accountid");
                    cmd.Parameters.Add(":accountid", id);

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

                        //Patient Data 
                        if (!string.IsNullOrEmpty(reader["PatientId"].ToString()))
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
                            List<Availability> availabilities = GetAvailabilities(AccountId);
                            var temp = new Volunteer();
                            temp.AccountId = AccountId;
                            List<Skill> skills = GetSkills(temp);
                            if (!string.IsNullOrEmpty(reader["AdminId"].ToString()))
                            {
                                var volunteer = new Volunteer(AccountId, Username, Password, Email, Name, Phone,
                                    DateDeregistration, Adress, Location, Car, DriversLicense, Rfid,
                                    Enabled, true, Birthdate, Photo, Vog, VogConfirmation, reviews);
                                volunteer.Availabilities = availabilities;
                                volunteer.Skills = skills;
                                return volunteer;
                            }
                            else
                            {
                                var volunteer = new Volunteer(AccountId, Username, Password, Email, Name, Phone,
                                    DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Enabled, false,
                                    Birthdate, Photo, Vog, VogConfirmation, reviews);
                                volunteer.Availabilities = availabilities;
                                volunteer.Skills = skills;
                                return volunteer;
                            }
                        }
                    }
                    return null;
                }
                catch (OracleException e)
                {

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Gets an account based on it's email and password
        /// Mainly used for logging in
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="password">user's password</param>
        /// <returns>Patient or Volunteer</returns>
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



                        //Patient Data 
                        if (!string.IsNullOrEmpty(reader["PatientId"].ToString()))
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
                            List<Availability> availabilities = GetAvailabilities(AccountId);
                            var temp = new Volunteer();
                            temp.AccountId = AccountId;
                            List<Skill> skills = GetSkills(temp);
                            if (!string.IsNullOrEmpty(reader["AdminId"].ToString()))
                            {
                                var volunteer = new Volunteer(AccountId, Username, Password, Email, Name, Phone,
                                    DateDeregistration, Adress, Location, Car, DriversLicense, Rfid,
                                    Enabled, true, Birthdate, Photo, Vog, VogConfirmation, reviews);
                                volunteer.Availabilities = availabilities;
                                volunteer.Skills = skills;
                                return volunteer;
                            }
                            else
                            {
                                var volunteer = new Volunteer(AccountId, Username, Password, Email, Name, Phone,
                                    DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Enabled, false,
                                    Birthdate, Photo, Vog, VogConfirmation, reviews);
                                volunteer.Availabilities = availabilities;
                                volunteer.Skills = skills;
                                return volunteer;
                            }
                        }
                    }
                    return null;
                }
                catch (OracleException e)
                {

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }

        }

        /// <summary>
        /// Returns all availabilities based on a volunteer.
        /// Used for displaying current free schedule of a volunteer.
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns></returns>
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

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static List<Availability> GetAvailabilities(int accountId)
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
                    cmd.Parameters.Add("AccountId", accountId);
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

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Returns a list of reviews based on an account's identifier
        /// </summary>
        /// <param name="accountId">account identifier</param>
        /// <returns>All reviews of specified user</returns>
        public static List<Review> GetReviews(int accountId)

        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT r.ReviewId, r.Requestid, r.Rating, r.Description " +
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
                        string Comment = reader["Description"].ToString();
                        reviews.Add(new Review(ReviewId, request, Rating, Comment));
                    }
                    return reviews;
                }
                catch (OracleException e)
                {

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Returns request based on request's indentifier
        /// </summary>
        /// <param name="requestId">request identifier</param>
        /// <returns></returns>
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

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Gets all requests
        /// </summary>
        /// <returns>all requests</returns>
        public static List<Request> GetRequests()
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT r.AccountId, r.RequestId, r.Location, r.TravelTime, r.StartDate, r.EndDate, r.Description AS \"Description\", " +
                        "r.Urgency, r.AmountOfVolunteers, " +
                        "v.VehicleTypeId, v.Description AS \"VehicleDescription\", " +
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
                        string VehicleDescription = reader["VehicleDescription"].ToString();

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

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        ///TODO SVEN WHYYYYYYYYYYYYYYYYYYYYYYY
        /// <summary>
        /// Returns a list of skills based on request identifier
        /// </summary>
        /// <param name="requestId">request identifier</param>
        /// <returns></returns>
        public static List<Request> GetRequests(int ID)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT r.AccountId, r.RequestId, r.Location, r.TravelTime, r.StartDate, r.EndDate, " +
                        "r.Urgency, r.AmountOfVolunteers, " +
                        "v.VehicleTypeId, v.Description as \"VehicleDescription\", " +
                        "p.OV, " +
                        "a.Username, a.Email, a.Password, " +
                        "u.Name, u.Phone, u.Datederegistration, u.Adress, u.Location as \"UserLocation\", " +
                        "u.Car, u.DriversLicense, u.RfId, u.Enabled " +
                        "FROM VehicleType v " +
                        "RIGHT JOIN Request r ON r.RequestId = v.RequestId " +
                        "LEFT JOIN Patient p ON p.AccountId = r.AccountId " +
                        "LEFT JOIN \"User\" u ON u.AccountId = p.AccountId " +
                        "LEFT JOIN \"Account\" a ON u.AccountId = a.AccountId " +
                        "WHERE r.RequestID = :requestid");

                    cmd.Parameters.Add(":requestid", ID);

                    var requests = new List<Request>();
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
                        string VehicleDescription = reader["VehicleDescription"].ToString();

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

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Returns all skills by request identifier
        /// </summary>
        /// <param name="requestId">request identifier</param>
        /// <returns>skills</returns>
        public static List<Skill> GetSkills(int requestId)
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

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Gets all responses based on a request's identifier
        /// </summary>
        /// <param name="requestId">request identifier</param>
        /// <returns>List of all responses with specified request id</returns>
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

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// List of skills based on a volunteer
        /// </summary>
        /// <param name="volunteer">volunteer</param>
        /// <returns>List of skills based on a volunteer</returns>
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

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Gets all skills from table Skill
        /// </summary>
        /// <returns>list of all skills</returns>
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

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }



        /// <summary>
        /// Makes a volunteer become an admin
        /// </summary>
        /// <param name="AccountId">volunteer identifier</param>
        /// <returns></returns>
        public static bool AlterAdmin(int AccountId)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT AccountID FROM \"Admin\" WHERE AccountID = :accountId"
                        );

                    cmd.Parameters.Add(":accountId", AccountId);

                    string value = null;

                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        value = reader["AccountID"].ToString();
                    }

                    //User is not an admin, add user to admin
                    if (string.IsNullOrEmpty(value))
                    {
                        cmd.CommandText = "INSERT INTO \"Admin\" (AccountID) VALUES (:accountId)";

                    }
                    //User is an admin, remove user from admin
                    else
                    {
                        cmd.CommandText = "DELETE FROM \"Admin\" WHERE AccountID = :accountId";
                    }

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (OracleException e)
                {

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// 'Deletes' and account by disabling the account
        /// </summary>
        /// <param name="accountId">account identifier</param>
        /// <returns></returns>
        public static bool AlterEnabled(int accountId)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT Enabled FROM \"User\" WHERE AccountID = :accountId"
                        );

                    cmd.Parameters.Add(":accountId", accountId);

                    int value = 1;

                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        value = Convert.ToInt32(reader["Enabled"].ToString());
                    }

                    cmd = CreateOracleCommand(con,
                        "UPDATE \"User\" SET Enabled = :value WHERE AccountID = :accountId"
                        );

                    cmd.Parameters.Add(":accountId", accountId);

                    if (value == 0)
                    {
                        cmd.Parameters.Add(":value", '1');
                    }
                    else
                    {
                        cmd.Parameters.Add(":value", '0');
                    }

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (OracleException e)
                {

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Adds an account to the database
        /// </summary>
        /// <param name="account">account to be added</param>
        /// <returns></returns>
        public static bool AlterVogConfirmation(int accountId)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "UPDATE Volunteer SET VogConfirmation = 1 WHERE AccountID = :accountId"
                        );

                    cmd.Parameters.Add(":accountId", accountId);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (OracleException)
                {
                    return false;

                }
                catch (Exception)
                {
                    return false;
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
                    int AccountId = new int();
                    cmd = CreateOracleCommand(con, "SELECT MAX(AccountId) AS AccountId FROM \"Account\"");
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        AccountId = Convert.ToInt32(reader["AccountId"].ToString());
                    }


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
                    else if (account is Patient)
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
                    if (e.Message.StartsWith("ORA-00001: unique constraint"))
                        throw new ExistingUserException(e.Message);
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Changes the current skills of a volunteer
        /// </summary>
        /// <param name="skills">list of skills to changed to</param>
        /// <param name="accountId">volunteer identifier</param>
        /// <returns></returns>
        public static bool AlterVolunteerSkills(List<Skill> skills, int accountId)
        {
            using (OracleConnection con = new OracleConnection())
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Adds a request to the request table
        /// </summary>
        /// <param name="request">request to be added</param>
        /// <returns></returns>
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

                        if (request.VehicleType != null)
                        {
                            OracleCommand vehicleCommand = CreateOracleCommand(connection, "INSERT INTO VEHICLETYPE(RequestID, Description) VALUES(:requestID, :description)");
                            vehicleCommand.Parameters.Add(":requestID", requestID);
                            vehicleCommand.Parameters.Add(":description", request.VehicleType.Description);
                            ExecuteNonQuery(vehicleCommand);
                        }
                        if (request.Skills != null)
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

        /// <summary>
        /// Adds a meeting to the meeting table
        /// </summary>
        /// <param name="meeting">meeting to be added</param>
        /// <returns></returns>
        public static bool AddMeeting(Meeting meeting)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {

                    OracleCommand insertCommand = CreateOracleCommand(connection,
                        "INSERT INTO MEETING (VolunteerID, PatientID, Location, MeetingDate, Status) VALUES (:volunteerID, :patientID, :location, :meetingDate, :status)");
                    insertCommand.Parameters.Add(":volunteerID", meeting.Volunteer.AccountId);
                    insertCommand.Parameters.Add(":patientID", meeting.Patient.AccountId);
                    insertCommand.Parameters.Add(":location", meeting.Location);
                    insertCommand.Parameters.Add(":meetingDate", meeting.Date);
                    int intStatus = 0;
                    if (meeting.Status)
                    {
                        intStatus = 1;
                    }
                    insertCommand.Parameters.Add(":status", intStatus);

                    return ExecuteNonQuery(insertCommand);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Alters the meeting, this used so users will be able to accept meetings
        /// </summary>
        /// <param name="meeting">meeting to be altered</param>
        /// <returns></returns>
        public static bool AlterMeeting(Meeting meeting)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    int status = 0;
                    if (meeting.Status)
                    {
                        status = 1;
                    }
                    OracleCommand updateCommand = CreateOracleCommand(connection,
                        "UPDATE MEETING SET VOLUNTEERID = :volunteerID, PATIENTID = :patientID, LOCATION = :location, MEETINGDATE = :meetingDate, STATUS = :status");
                    updateCommand.Parameters.Add(":volunteerID", meeting.Volunteer.AccountId);
                    updateCommand.Parameters.Add(":patientID", meeting.Patient.AccountId);
                    updateCommand.Parameters.Add(":location", meeting.Location);
                    updateCommand.Parameters.Add(":meetingDate", meeting.Date);
                    updateCommand.Parameters.Add(":status", status);

                    return ExecuteNonQuery(updateCommand);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Adds a response to a request
        /// </summary>
        /// <param name="response">response to be added</param>
        /// <param name="request">request to which the response is pointed</param>
        /// <returns></returns>
        public static bool AddResponse(Response response, Request request)
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    OracleCommand insertCommand = CreateOracleCommand(connection,
                        "INSERT INTO RESPONSE (ResponderID, RequestID, ResponseDate, Description) Values(:responderID, :requestID, :responseDate, :description)");
                    insertCommand.Parameters.Add(":responderID", response.Volunteer.AccountId);
                    insertCommand.Parameters.Add(":requestID", request.RequestId);
                    insertCommand.Parameters.Add(":responseDate", response.ResponseDate);
                    insertCommand.Parameters.Add(":description", response.Description);

                    return ExecuteNonQuery(insertCommand);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Deletes a request by it's id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public static bool DeleteRequest(int requestId)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "DELETE FROM Request WHERE RequestID = :requestid"
                        );

                    cmd.Parameters.Add(":requestid", requestId);

                    ExecuteNonQuery(cmd);

                    cmd.CommandText = "DELETE FROM Response WHERE RequestID = :requestid";

                    ExecuteNonQuery(cmd);

                    return true;
                }
                catch (OracleException e)
                {
                    throw new ExistingUserException(e.Message);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Deletes a review by it's id
        /// </summary>
        /// <param name="reviewId">review to be removed</param>
        /// <returns></returns>
        public static bool DeleteReview(int reviewId)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "DELETE FROM Review WHERE ReviewId = :ReviewId");
                    cmd.Parameters.Add("ReviewId", reviewId);
                    con.Open();
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
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Adds a review to a volunteer
        /// </summary>
        /// <param name="review">review to be added</param>
        /// <param name="volunteerId">volunteer to which the review is adressed</param>
        /// <returns></returns>
        public static bool AddReview(Review review, int volunteerId)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "INSERT INTO Review (AccountId, RequestId, Rating, Description) " +
                        "VALUES (:accountId, :requestId, :rating, :description)"
                    );
                    cmd.Parameters.Add("accountId", volunteerId);
                    cmd.Parameters.Add("requestId", review.Request.RequestId);
                    cmd.Parameters.Add("rating", review.Rating);
                    cmd.Parameters.Add("description", review.Comment);

                    con.Open();
                    return ExecuteNonQuery(cmd);
                }
                catch (OracleException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static List<Meeting> GetMeetings()
        {
            using (OracleConnection connection = Connection)
            {
                try
                {
                    List<Meeting> returnMeetings = new List<Meeting>();
                    int volunteerID = 0;
                    int patientID = 0;
                    OracleCommand selectCommand = CreateOracleCommand(connection, "SELECT m.VolunteerID as VolunteerID, m.PatientID as PatientID, m.Location as mLocation, m.MeetingDate, m.status, p.AccountID, p.OV, u1.Name as pName, u1.Phone as pPhone, u1.DATEDEREGISTRATION as pDATEDEREG, u1.ADRESS as pAdress, u1.location as pLocation, u1.car as pCar, u1.driverslicense as pDrivers, u1.rfid as pRFID, u1.enabled as pEnabled, a1.username as pUsername, a1.password as pPassword, a1.email as pEmail, v.VOG, v.BirthDate, v.PHOTO, v.VOGCONFIRMATION, u2.Name as vName, u2.Phone as vPhone, u2.DATEDEREGISTRATION as vDATEDEREG, u2.ADRESS as vAdress, u2.location as vLocation, u2.car as vCar, u2.driverslicense as vDrivers, u2.rfid as vRFID, u2.enabled as vEnabled, a2.username as vUsername, a2.password as vPassword, a2.email as vEmail FROM MEETING m LEFT JOIN PATIENT p ON m.PATIENTID = p.ACCOUNTID LEFT JOIN \"User\" u1 ON p.ACCOUNTID = u1.ACCOUNTID  LEFT JOIN \"Account\" a1 on u1.ACCOUNTID = a1.ACCOUNTID LEFT JOIN VOLUNTEER v on m.VOLUNTEERID = v.ACCOUNTID  LEFT JOIN \"User\" u2 ON v.ACCOUNTID = u2.ACCOUNTID LEFT JOIN \"Account\" a2 ON u2.ACCOUNTID = a2.ACCOUNTID");

                    OracleDataReader MainReader = ExecuteQuery(selectCommand);

                    while (MainReader.Read())
                    {
                        volunteerID = Convert.ToInt32(MainReader["VOLUNTEERID"].ToString());
                        patientID = Convert.ToInt32(MainReader["PATIENTID"].ToString());
                        string location = MainReader["MLOCATION"].ToString();
                        DateTime MeetingDate = Convert.ToDateTime(MainReader["MeetingDate"].ToString());
                        bool status = Convert.ToBoolean(Convert.ToInt32(MainReader["Status"].ToString()));
                        bool pOV = Convert.ToBoolean(Convert.ToInt32(MainReader["OV"].ToString()));
                        string pname = MainReader["pname"].ToString();
                        string pphone = MainReader["pphone"].ToString();
                        DateTime pDateReg = new DateTime();
                        if (!string.IsNullOrEmpty(MainReader["PDATEDEREG"].ToString()))
                        {
                            pDateReg = Convert.ToDateTime(MainReader["PDATEDEREG"].ToString());
                        }
                        string padress = MainReader["padress"].ToString();
                        string plocation = MainReader["plocation"].ToString();
                        bool pcar = Convert.ToBoolean(Convert.ToInt32(MainReader["pcar"].ToString()));
                        bool pdrivers = Convert.ToBoolean(Convert.ToInt32(MainReader["pdrivers"].ToString()));
                        string prfid = MainReader["PRFID"].ToString();
                        bool penabled = Convert.ToBoolean(Convert.ToInt32(MainReader["penabled"].ToString()));
                        string pusername = MainReader["PUSERNAME"].ToString();
                        string ppassword = MainReader["PPASSWORD"].ToString();
                        string pemail = MainReader["PEMAIL"].ToString();
                        string vog = MainReader["vog"].ToString();
                        DateTime vbd = new DateTime();
                        if (!string.IsNullOrEmpty(MainReader["BIRTHDATE"].ToString()))
                        {
                            vbd = Convert.ToDateTime(MainReader["BIRTHDATE"].ToString());
                        }
                        string photo = MainReader["PHOTO"].ToString();
                        bool vogCon = Convert.ToBoolean(Convert.ToInt32(MainReader["VOGCONFIRMATION"].ToString()));
                        string vname = MainReader["VNAME"].ToString();
                        string vphone = MainReader["vphone"].ToString();
                        DateTime vDateReg = new DateTime();
                        if (!string.IsNullOrEmpty(MainReader["vDATEDEREG"].ToString()))
                        {
                            vDateReg = Convert.ToDateTime(MainReader["vDATEDEREG"].ToString());
                        }
                        string vadress = MainReader["vadress"].ToString();
                        string vlocation = MainReader["vlocation"].ToString();
                        bool vcar = Convert.ToBoolean(Convert.ToInt32(MainReader["vcar"].ToString()));
                        bool vdrivers = Convert.ToBoolean(Convert.ToInt32(MainReader["vdrivers"].ToString()));
                        string vrfid = MainReader["VRFID"].ToString();
                        bool venabled = Convert.ToBoolean(Convert.ToInt32(MainReader["venabled"].ToString()));
                        string vusername = MainReader["VUSERNAME"].ToString();
                        string vpassword = MainReader["VPASSWORD"].ToString();
                        string vemail = MainReader["VEMAIL"].ToString();
                        Volunteer volunteer = new Volunteer(volunteerID, vusername, vpassword, vemail, vname, vphone, vDateReg, vadress, vlocation, vcar, vdrivers, vrfid, false, venabled, vbd, photo, vog, vogCon);
                        Patient patient = new Patient(patientID, pusername, ppassword, pemail, pname, pphone, pDateReg, padress, plocation, pcar, pdrivers, prfid, false, penabled, pOV);
                        returnMeetings.Add(new Meeting(patient, volunteer, location, MeetingDate, status));
                    }
                    return returnMeetings;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

    }
}