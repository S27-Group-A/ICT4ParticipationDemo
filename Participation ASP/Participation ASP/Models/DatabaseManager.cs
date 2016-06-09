using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
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
        public static Account GetUser(string username, string password)
        {
            try
            {
                using (OracleConnection con = Connection)
                {
                    string sql = "SELECT * FROM ACCOUNT WHERE Username = :Username AND Password = :Password";
                    using (OracleCommand cmd = new OracleCommand(sql, con))
                    {
                        cmd.Parameters.Add("Username", username);
                        cmd.Parameters.Add("Password", password);
                        con.Open();
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = Convert.ToInt32(reader["AccountId"].ToString());
                            string Username = reader["Username"].ToString();
                            string Email = reader["Email"].ToString();
                            string Password = reader["Password"].ToString();
                            bool IsAdmin = Convert.ToBoolean(Convert.ToInt32(reader["IsAdmin"].ToString()));
                            return new User(Id, Email, Password, Username, Signature, AvatarUrl, IsAdmin);
                        }
                        reader.Close();
                    }
                    //TODO Close connection maybe?
                    return null;
                }
            }
            catch (OracleException oracleExc)
            {
                //TODO Needs proper exception handling
                //Logger.Write(exc.Message);
                return null;
            }
            catch (Exception exc)
            {
                return null;
            }

            #endregion


        }
}