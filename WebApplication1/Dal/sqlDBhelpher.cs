using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace WebApplication1
{
    public static class DBHelper
    {
        static string strconn = "Data Source=10.3.152.22;Initial Catalog=WL;User ID=sa;Password=123456";
        public static DataTable GetTable(string strsql)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                var dt = new DataTable();
                SqlDataAdapter msda = new SqlDataAdapter(strsql, conn);
                msda.Fill(dt);
                return dt;
            }
        }

        public static int CUD(string strsql)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(strsql, conn);
                return comm.ExecuteNonQuery();
            }
        }

        public static DataTable GetTable_Proc(string pname, SqlParameter[] paras = null)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                var dt = new DataTable();
                SqlCommand comm = new SqlCommand(pname, conn);
                comm.CommandType = CommandType.StoredProcedure;
                if (paras != null)
                {
                    comm.Parameters.AddRange(paras);
                }
                SqlDataAdapter msda = new SqlDataAdapter(comm);
                msda.Fill(dt);
                return dt;
            }
        }

        public static int CUD_Proc(string pname, SqlParameter[] paras = null)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                SqlCommand comm = new SqlCommand(pname, conn);
                comm.CommandType = CommandType.StoredProcedure;
                if (paras != null)
                {
                    comm.Parameters.AddRange(paras);
                }
                return comm.ExecuteNonQuery();
            }
        }


    }
}
