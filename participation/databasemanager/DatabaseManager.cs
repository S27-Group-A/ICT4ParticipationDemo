using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;


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
        #endregion


        #region Methods - AuthenticationSystem

        #endregion

        #region Methods - AdministrationSystem

        #endregion

        #region Methods - PatientSystem

        #endregion

        #region Methods - VolunteerSystem

        #endregion

        #region Methods - ChatSystem

        #endregion

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
    }
}
