using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SaI.Helpers
{
    public static class DBHelper
    {
        public static int timeout = ((ConfigurationManager.AppSettings["MinuteCommandTimeout"] == null ? 3 : Convert.ToInt32(ConfigurationManager.AppSettings["MinuteCommandTimeout"])) * 60 * 1000);

        public static IList<string> ToSqlParameterNames<T>(this List<T> values)
        {
            var names = new List<string>();
            for (int i = 0; i < values.Count; i++) {
                names.Add("@P" + i.ToString());
            }
            return names;
        }

        public static string HashMd5(string str)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashByteArray = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes("PW" + str + "PW"));
            string hash = "";
            for (int i = 0; i < hashByteArray.Length; i++) {
                hash += hashByteArray[i];
            }
            return hash;
        }

        public static bool GetBoolean(MySqlDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? false : reader.GetBoolean(index);
        }

        public static double GetDouble(MySqlDataReader reader, int index)
        {
            return GetDouble(reader, index, 0);
        }

        public static double GetDouble(MySqlDataReader reader, int index, double defaultValue)
        {
            return reader.IsDBNull(index) ? defaultValue : reader.GetDouble(index);
        }

        public static decimal GetDecimal(MySqlDataReader reader, int index)
        {
            return GetDecimal(reader, index, 0);
        }

        public static decimal GetDecimal(MySqlDataReader reader, int index, decimal defaultValue)
        {
            return reader.IsDBNull(index) ? defaultValue : reader.GetDecimal(index);
        }

        /// <summary>
        /// Returns a date time from a data reader.
        /// </summary>
        /// <param name="reader">SQL data reader</param>
        /// <param name="index">Index to which the data is referred to from a data reader</param>
        /// <returns>Date time value from a data reader given the index</returns>
        public static DateTime GetDateTime(MySqlDataReader reader, int index)
        {
            return GetDateTime(reader, index, DateTime.MaxValue);
        }

        /// <summary>
        /// Returns a date time from a data reader.
        /// </summary>
        /// <param name="reader">SQL data reader</param>
        /// <param name="index">Index to which the data is referred to from a data reader</param>
        /// <param name="defaultValue">Returns this value if index in the reader is null</param>
        /// <returns>Date time value from a data reader given the index</returns>
        public static DateTime GetDateTime(MySqlDataReader reader, int index, DateTime defaultValue)
        {
            return reader.IsDBNull(index) ? defaultValue : reader.GetDateTime(index);
        }

        /// <summary>
        /// Returns a GUID field in the SQL data reader.
        /// </summary>
        /// <param name="reader">SQL data reader</param>
        /// <param name="index">Index to which the data is referred to from a data reader</param>
        /// <returns>GUID value from a data reader given the index</returns>
        public static Guid GetGuid(MySqlDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? new Guid() : reader.GetGuid(index);
        }

        /// <summary>
        /// Returns a GUID field in the SQL data reader.
        /// </summary>
        /// <param name="reader">SQL data reader</param>
        /// <param name="index">Index to which the data is referred to from a data reader</param>
        /// <param name="defaultValue">Default value to be returned when data reader returns null</param>
        /// <returns>Returns GUID value from a data reader given the index</returns>
        public static Guid? GetGuid(MySqlDataReader reader, int index, Guid defaultValue)
        {
            return reader.IsDBNull(index) ? defaultValue : reader.GetGuid(index);
        }

        /// <summary>
        /// Get the value of an index in sqldatareader and return as string
        /// </summary>
        /// <param name="rs">SQL data reader object</param>
        /// <param name="index">Field index</param>
        /// <returns>String value from data reader given the index</returns>
        public static string GetString(MySqlDataReader rs, int index)
        {
            return GetString(rs, index, null);
        }

        /// <summary>
        /// Get the value of an index in sqldatareader with the default value of (NULL) if field is DBNULL and return as string
        /// </summary>
        /// <param name="rs">SQL data reader object</param>
        /// <param name="index">Field index</param>
        /// <param name="def">Default value</param>
        /// <returns></returns>
        public static string GetString(MySqlDataReader rs, int index, string def)
        {
            return rs.IsDBNull(index) ? def : rs.GetString(index);
        }

        /// <summary>
        /// Get the value of an index in sqldatareader with the default value of (NULL) if field is DBNULL and return as string
        /// </summary>
        /// <param name="reader">SQL data reader object</param>
        /// <param name="index">Field index</param>
        /// <param name="check">Checking value</param>
        /// <param name="def">Default value</param>
        /// <returns></returns>
        public static string GetString(MySqlDataReader reader, int index, string check, string def)
        {
            bool condition = GetString(reader, index, check) == check;
            return condition ? def : reader.GetString(index);
        }

        /// <summary>
        /// Get the value of an index in sqldatareader and return as integer
        /// </summary>
        /// <param name="reader">SQL data reader object</param>
        /// <param name="index">Field index</param>
        /// <returns></returns>
        public static int GetInt32(MySqlDataReader reader, int index)
        {
            return GetInt32(reader, index, 0);
        }

        /// <summary>
        /// Get the value of an index in sqldatareader with the default value of (0) if field is DBNULL and return as integer
        /// </summary>
        /// <param name="reader">SQL data reader object</param>
        /// <param name="index">Field index</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns></returns>
        public static int GetInt32(MySqlDataReader reader, int index, int defaultValue)
        {
            return reader.IsDBNull(index) ? defaultValue : reader.GetInt32(index);
        }

        /// <summary>
        /// Function to execute query string
        /// </summary>
        /// <param name="query">Query String</param>
        /// <param name="parameters">Sql parameters for the query</param>
        /// <returns>Rows affected</returns>
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            return ExecuteNonQuery(query, "ConnectionString", parameters);
        }

        /// <summary>
        /// Function to execute query string
        /// </summary>
        /// <param name="query">Query String</param>
        /// <param name="connectionString">Sql Connection</param>
        /// <param name="parameters">SQL parameters for the query</param>
        /// <returns>Rows affected</returns>
        public static int ExecuteNonQuery(string query, string connectionString, params MySqlParameter[] parameters)
        {
            var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ToString());
            OpenConnection(connection);
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters);
            //cmd.CommandTimeout = 900;
            cmd.CommandTimeout = timeout;
            int rowsAffected = cmd.ExecuteNonQuery();
            CloseConnection(connection);
            return rowsAffected;
        }

        /// <summary>
        /// Function to read SQL data reader and returns a pointer to the reader being executed by the query.
        /// </summary>
        /// <param name="query">Query string</param>
        /// <param name="parameters">SQL parameters</param>
        /// <returns>SQL data reader</returns>
        public static MySqlDataReader ExecuteReader(string query, params MySqlParameter[] parameters)
        {
            return ExecuteReader(query, "ConnectionString", parameters);
        }

        /// <summary>
        /// Function to read SQL data reader and returns a pointer to the reader being executed by the query.
        /// </summary>
        /// <param name="query">Query string</param>
        /// <param name="connectionString">SQL connection string</param>
        /// <param name="parameters">SQL parameters</param>
        /// <returns>SQL data reader</returns>
        public static MySqlDataReader ExecuteReader(string query, string connectionString, params MySqlParameter[] parameters)
        {
            var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ToString());
            OpenConnection(connection);
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters);
            //cmd.CommandTimeout = 900;
            cmd.CommandTimeout = timeout;
            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        
        /// <summary>
        /// Execute query string and return generic value of type T.
        /// </summary>
        /// <param name="query">Query String</param>
        /// <param name="parameters">SQL parameters for the query</param>
        /// <returns>Object of type T from the scalar execution of the data reader</returns>
        public static T ExecuteScalar<T>(string query, params MySqlParameter[] parameters)
        {
            return ExecuteScalar<T>(query, "ConnectionString", parameters);
        }

        /// <summary>
        /// Execute query string and return generic value of type T.
        /// </summary>
        /// <param name="query">Query String</param>
        /// <param name="connectionString">Sql Connection</param>
        /// <param name="parameters">SQL parameters for the query</param>
        /// <returns>Object of type T from the scalar execution of the data reader</returns>
        public static T ExecuteScalar<T>(string query, string connectionString, params MySqlParameter[] parameters)
        {
            return ExecuteScalar<T>(query, connectionString, default(T), parameters);
        }

        /// <summary>
        /// Execute query string and return generic value of type T.
        /// </summary>
        /// <param name="query">Query String</param>
        /// <param name="connectionString">Sql Connection</param>
        /// <param name="parameters">SQL parameters for the query</param>
        /// <param name="defaultValue">Default value to return in case scalar value is null</param>
        /// <returns>Object of type T from the scalar execution of the data reader</returns>
        public static T ExecuteScalar<T>(string query, string connectionString, T defaultValue, params MySqlParameter[] parameters)
        {
            var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ToString());
            OpenConnection(connection);
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters);
            T returnValue = defaultValue;
            var o = cmd.ExecuteScalar();
            if (o != null && o != DBNull.Value) {
                returnValue = (T)Convert.ChangeType(o, typeof(T));
            }
            CloseConnection(connection);
            return returnValue;
        }

        /// <summary>
        /// Function to open the connection for use. Ensures first that the connection is closed before opening.
        /// </summary>
        /// <param name="connection"></param>
        static void OpenConnection(MySqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed) {
                connection.Open();
            }
        }

        /// <summary>
        /// Closes the SQL connection. Close only a connection that is open.
        /// </summary>
        /// <param name="connection"></param>
        static void CloseConnection(MySqlConnection connection)
        {
            if (connection.State == ConnectionState.Open) {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}