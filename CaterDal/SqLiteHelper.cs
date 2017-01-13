using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterDal
{
    public static class SqLiteHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["itcastCater"].ConnectionString;

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static DataTable GetDataTable(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.SelectCommand.Parameters.AddRange(ps);
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
