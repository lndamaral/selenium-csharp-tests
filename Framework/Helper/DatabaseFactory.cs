using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Framework.Helper
{
    public class DatabaseFactory
    {
        private static SqlConnection GetDBConnection()
        {
            string connectionString = "Server=" + ConfigurationManager.AppSettings["DatabaseServer"] + ",1433;" +
                                      "Initial Catalog=" + ConfigurationManager.AppSettings["DatabaseName"] + ";" +
                                      "User ID=" + ConfigurationManager.AppSettings["DBUser"] + "; " +
                                      "Password=" + ConfigurationManager.AppSettings["DBPassword"] + ";";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public static void DBRunQuery(string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, GetDBConnection()))
            {
                try
                {
                    cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        public static List<string> DBGetQueryResults(String query)
        {

            DataSet ds = new DataSet();
            List<string> list = new List<string>();

            using (SqlCommand cmd = new SqlCommand(query, GetDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);
                cmd.Connection.Open();
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);
                cmd.Connection.Close();
            }

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    list.Add(ds.Tables[0].Rows[0][i].ToString());
                }
            }
            catch (Exception)
            {
                return null;
            }
            return list;
        }
    }
}
