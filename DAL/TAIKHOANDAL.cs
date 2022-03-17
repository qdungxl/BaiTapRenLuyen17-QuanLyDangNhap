using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TAIKHOANDAL
    {
        string sqlconn = @"Data Source=QUOCDUNGSURFACE\SQLEXPRESS01;Initial Catalog=CSDL_QLDangNhap;Integrated Security=True";
        SqlConnection conn = null;
        /// <summary>
        /// Kiểm tra và mở kết nối đến SQL.
        /// </summary>
        public void openconn()
        {
            if (conn == null)
                conn = new SqlConnection(sqlconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        /// <summary>
        /// Kiểm tra và đóng kết nối đến SQL.
        /// </summary>
        public void closeconn()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
        public List<TAIKHOAN> LayToanBoTaiKhoan()
        {
            List<TAIKHOAN> lsTK = new List<TAIKHOAN>();
            openconn();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from TAIKHOAN";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TAIKHOAN taikhoan = new TAIKHOAN();
                taikhoan.TenDangNhap = reader.GetString(0);
                taikhoan.MatKhau = reader.GetString(1);
                lsTK.Add(taikhoan);
            }
            reader.Close();
            return lsTK;
        }
        public bool SuaMatKhauDangNhap(TAIKHOAN taikhoanCu, string MatKhauMoi)
        {
            try
            {
                openconn();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "update TAIKHOAN set MatKhau = @matkhau where TaiKhoan= @taikhoan";
                command.Connection = conn;
                command.Parameters.Add("@matkhau", SqlDbType.NVarChar).Value = MatKhauMoi;
                command.Parameters.Add("@taikhoan", SqlDbType.NVarChar).Value = taikhoanCu.TenDangNhap;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
