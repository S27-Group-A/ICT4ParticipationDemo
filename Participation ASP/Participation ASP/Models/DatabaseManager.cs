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
            catch
            {
                return null;
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

        #region User
        public static IAccount GetUser(IAccount account)
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
                                                                 "FULL OUTER JOIN Patient p ON v.AccountId = p.AccountId " +
                                                                 "WHERE a.Username = :Username AND a.Password = :Password");


                    cmd.Parameters.Add("Username", account.Username);
                    cmd.Parameters.Add("Password", account.Password);
                    con.Open();
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        //User- and Account Data
                        int AccountId = new int();
                        if (reader["UserId"] != null)
                            Convert.ToInt32(reader["UserId"].ToString());
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
                            return new Account(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, isAdmin:);
                        }

                        //Patient Data 
                        else if (!string.IsNullOrEmpty(reader["PatientId"].ToString()))
                        {
                            bool Ov = true;
                            return new Patient(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, Ov);
                        }

                        //Volunteer Data
                        else if (!string.IsNullOrEmpty(reader["VolunteerId"].ToString()))
                        {
                            string Vog = reader["Vog"].ToString();
                            bool VogConfirmation = Convert.ToBoolean(Convert.ToInt32(reader["VogCofirmation"]));
                            DateTime Birthdate = new DateTime();
                            if (!string.IsNullOrEmpty(reader["Birthdate"].ToString()))
                                Birthdate = Convert.ToDateTime(reader["Birthdate"].ToString());
                            string Photo = reader["Photo"].ToString();
                            return new Volunteer(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress, Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, Birthdate, Photo, Vog, VogConfirmation);
                        }
                        else
                        {
                            return new Account(AccountId, Username, Password, Email, Name, Phone, DateDeregistration, Adress,
                                Location, Car, DriversLicense, Rfid, Banned, Unban, Enabled, false);
                        }
                    }
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

        #endregion


    }
}