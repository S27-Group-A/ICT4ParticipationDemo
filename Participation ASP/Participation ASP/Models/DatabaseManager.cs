﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI.WebControls;
using MyFigureCollection.Exceptions;
using Oracle.DataAccess.Client;


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
                                                                 "u.Name, u.Phone, u.Datederegistration, u.Adress, u.Location, u.Car, u.DriversLicense, u.Rfid, u.Banned, u.Unban, u.Enabled " +
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
                        bool Banned = false;
                        if (!string.IsNullOrEmpty(reader["Banned"].ToString()))
                            Banned = Convert.ToBoolean(Convert.ToInt32(reader["Banned"].ToString()));
                        bool Enabled = true;
                        if (!string.IsNullOrEmpty(reader["Enabled"].ToString()))
                            Enabled = Convert.ToBoolean(Convert.ToInt32(reader["Enabled"].ToString()));
                        DateTime Unban = new DateTime();
                        if (!string.IsNullOrEmpty(reader["Unban"].ToString()))
                            Unban = Convert.ToDateTime(reader["Banned"].ToString());

                        //Admin Data
                        if (!string.IsNullOrEmpty(reader["AdminId"].ToString()))
                        {
                            bool IsAdmin = true;
                            accounts.Add(new Account(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, IsAdmin));
                        }

                        //Patient Data 
                        else if (!string.IsNullOrEmpty(reader["PatientId"].ToString()))
                        {
                            //TODO Fix Ov
                            bool Ov = true;
                            accounts.Add(new Patient(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, false, Ov));
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
                            accounts.Add(new Volunteer(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, false, Birthdate, Photo, Vog, VogConfirmation));
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

        public static IAccount GetAccount(IAccount account)
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con, "SELECT ad.AccountId as \"AdminId\", " +
                                                                 "v.AccountId as \"VolunteerId\", v.Birthdate, v.Photo, v.Vog, v.VogConfirmation, " +
                                                                 "p.Ov, p.AccountId as \"PatientId\", " +
                                                                 "a.AccountId as \"UserId\", a.Username, a.Password, a.Email, " +
                                                                 "u.Name, u.Phone, u.Datederegistration, u.Adress, u.Location, u.Car, u.DriversLicense, u.Rfid, u.Banned, u.Unban, u.Enabled " +
                                                                 "FROM \"User\" u " +
                                                                 "FULL OUTER JOIN \"Account\" a ON u.AccountId = a.AccountId " +
                                                                 "FULL OUTER JOIN \"Admin\" ad ON ad.AccountId = a.AccountId " +
                                                                 "FULL OUTER JOIN Volunteer v ON v.AccountId = a.AccountId " +
                                                                 "FULL OUTER JOIN Patient p ON a.AccountId = p.AccountId " +
                                                                 "WHERE a.Email = :Email AND a.Password = :Password");


                    cmd.Parameters.Add("Email", account.Email);
                    cmd.Parameters.Add("Password", account.Password);
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
                        bool Car = Convert.ToBoolean(Convert.ToInt32(reader["Car"].ToString()));
                        bool DriversLicense = Convert.ToBoolean(Convert.ToInt32(reader["DriversLicense"].ToString()));
                        string Rfid = reader["Rfid"].ToString();
                        bool Banned = Convert.ToBoolean(Convert.ToInt32(reader["Banned"].ToString()));
                        bool Enabled = Convert.ToBoolean(Convert.ToInt32(reader["Enabled"].ToString()));
                        DateTime Unban = new DateTime();
                        if (!string.IsNullOrEmpty(reader["Unban"].ToString()))
                            Unban = Convert.ToDateTime(reader["Banned"].ToString());

                        //Admin Data
                        if (!string.IsNullOrEmpty(reader["AdminId"].ToString()))
                        {
                            bool IsAdmin = true;
                            return new Account(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, IsAdmin);
                        }

                        //Patient Data 
                        else if (!string.IsNullOrEmpty(reader["PatientId"].ToString()))
                        {
                            //TODO Fix ov
                            bool Ov = true;
                            return new Patient(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, false, Ov);
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
                            return new Volunteer(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, false, Birthdate, Photo, Vog, VogConfirmation);
                        }
                        else
                        {
                            return new Account(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress,
                                Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, false);
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

        public static List<Request> GetRequests()
        {
            using (OracleConnection con = Connection)
            {
                try
                {
                    OracleCommand cmd = CreateOracleCommand(con,
                        "SELECT r.AccountId, r.RequestId, r.Location, r.TravelTime, r.StartDate, r.EndDate, r.Urgency, r.AmountOfVolunteers, v.VehicleTypeId, v.Description, p.OV, a.Username, a.Email, a.Password, u.Name, u.Phone, u.Datederegistration, u.Adress, u.Location as \"UserLocation\", u.Car, u.DriversLicense, u.RfId, u.Banned, u.Unban, u.Enabled FROM VehicleType v RIGHT JOIN Request r ON r.RequestId = v.RequestId LEFT JOIN Patient p ON p.AccountId = r.AccountId LEFT JOIN \"User\" u ON u.AccountId = p.AccountId LEFT JOIN \"Account\" a ON u.AccountId = a.AccountId "/*"SELECT r.AccountId, r.RequestId, r.Location, r.TravelTime, r.StartDate, r.EndDate, r.Urgency, r.AmountOfVolunteers, " +
                        "v.VehicleTypeId, v.Description, " +
                        "p.OV, a.Username, a.Email, a.Password, " +
                        "u.Name, u.Phone, u.Datederegistration, u.Adress, u.Location as \"UserLocation\", u.Car, u.DriversLicense, u.RfId, u.Banned, u.Unban, u.Enabled " +
                        "FROM VehicleType v " +
                        "RIGHT JOIN Request r ON r.RequestId = v.RequestId " +
                        "LEFT JOIN Patient p ON p.AccountId = r.AccountId " +
                        "LEFT JOIN \"User\" u ON u.AccountId = p.AccountId " +
                        "LEFT JOIN \"Account\" a ON u.AccountId = a.AccountId "*/);

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
                        bool Banned = Convert.ToBoolean(Convert.ToInt32(reader["Banned"].ToString()));
                        bool Enabled = Convert.ToBoolean(Convert.ToInt32(reader["Enabled"].ToString()));
                        DateTime Unban = new DateTime();
                        if (!string.IsNullOrEmpty(reader["Unban"].ToString()))
                            Unban = Convert.ToDateTime(reader["Banned"].ToString());

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
                        Patient Patient = new Patient(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, false, Ov);

                        //Vehicle Data
                        int VehicleTypeId = new int();
                        if (!string.IsNullOrEmpty(reader["VehicleTypeId"].ToString()))
                            VehicleTypeId = Convert.ToInt32(reader["VehicleTypeId"].ToString());
                        string VehicleDescription = reader["Description"].ToString();

                        //Get Skill Data
                        List<Skill> Skills = GetSkills(AccountId);

                        //Get Response Data
                        List<Response> Responses = GetResponses(ReqId);

                        requests.Add(new Request(ReqId, Description, Location, TravelTime, StartDate, EndDate, Urgency, AmountOfVolunteers, Skills, new VehicleType(VehicleTypeId, VehicleDescription), new Account(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, false), Responses));

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
                        "u.Car, u.DriversLicense, u.Rfid, u.Banned, u.Unban, u.Enabled, " +
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
                        bool Banned = Convert.ToBoolean(Convert.ToInt32(reader["Banned"].ToString()));
                        bool Enabled = Convert.ToBoolean(Convert.ToInt32(reader["Enabled"].ToString()));
                        DateTime Unban = new DateTime();
                        if (!string.IsNullOrEmpty(reader["Unban"].ToString()))
                            Unban = Convert.ToDateTime(reader["Banned"].ToString());

                        //Volunteer Data
                        string Vog = reader["Vog"].ToString();
                        bool VogConfirmation = Convert.ToBoolean(Convert.ToInt32(reader["VogConfirmation"].ToString()));
                        DateTime Birthdate = new DateTime();
                        if (!string.IsNullOrEmpty(reader["Birthdate"].ToString()))
                            Birthdate = Convert.ToDateTime(reader["Birthdate"].ToString());
                        string Photo = reader["Photo"].ToString();
                        var volunteer = new Volunteer(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, UserLocation, Car, DriversLicense, Rfid, Banned, Unban, Enabled, false, Birthdate, Photo, Vog, VogConfirmation);

                        //Response Data
                        //res.RequestId, res.ResponseDate, res.Description
                        var RequestId = requestId;
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

        public static List<Response> GetResponses()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}