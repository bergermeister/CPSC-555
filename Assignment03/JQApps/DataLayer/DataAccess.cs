using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JQApps.DataLayer
{
    public class DataAccess
    {
        static string connStr = ConfigurationManager.ConnectionStrings["NWDB"].ConnectionString;
        public static DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            catch(Exception ex)
            {
                Console.WriteLine( ex.Message );
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}