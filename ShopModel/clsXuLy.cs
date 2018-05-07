using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace ShopModel
{
   public class clsXuLy
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static DataTable dt;
        public static SqlDataAdapter da;
        public static string lenh = "data source=DESKTOP-NBJO5FI;initial catalog=ShopOfflineBanQuanAo;persist security info=True;user id=sa;password=123456;MultipleActiveResultSets=True;App=EntityFramework";
        public static DataTable TaoBang (String sql)
        {
            conn = new SqlConnection(lenh);
            conn.Open();
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static int ExecuteNonQuery(String sql)
        {
            int re = 0;
            try
            {
                conn = new SqlConnection(lenh);
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                re = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return re;
        }
        public void ExecuteNonQuerry(string proc, SqlParameter[] param)
        {
            conn = new SqlConnection(lenh);
            conn.Open();
            cmd = new SqlCommand(proc, conn);
            cmd.CommandText = proc;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();
        }

        public void ExecuteNonQuerry(string proc)
        {
            conn = new SqlConnection(lenh);
            conn.Open();
            cmd = new SqlCommand(proc, conn);
            cmd.CommandText = proc;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }

        public static DataTable GetData(string proc)
        {
            conn = new SqlConnection(lenh);
            conn.Open();
            cmd = new SqlCommand(proc, conn);
            cmd.CommandText = proc;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetData(string proc, SqlParameter[] param)
        {
            conn = new SqlConnection(lenh);
            conn.Open();
            cmd = new SqlCommand(proc, conn);
            cmd.CommandText = proc;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string ConvertMD5(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }
        public static class LoginInfo
        {
            public static string UserID;
        }
    }
}

