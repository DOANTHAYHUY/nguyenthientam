using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
   public class TaiKhoanModel
    {
        public DataTable LoadData()
        {
            DataTable re;
            String lenh = "select * from sbTaiKhoan";
            re = clsXuLy.GetData("sp_TaiKhoan_LoadGrid");
            return re;
        }
        public bool ThemTaiKhoan(String Username, String Password, Int32 IDnhanVien, String PasswordOld)
        {
            String lenh = "insert into sbTaiKhoan values('" + Username + "', '" + Password + "', '" + IDnhanVien + "', '" + PasswordOld + "')";
            bool kt = false;
            if (clsXuLy.ExecuteNonQuery(lenh) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool XoaTaiKhoan(String id)
        {
            String lenhxoa = "Delete from sbTaiKhoan where Username = '" + id + "'";
            bool kt = false;
            if (clsXuLy.ExecuteNonQuery(lenhxoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool SuaTaiKhoan(String ids, String Username, String Password, Int32 IDNhanVien, String PasswordOld)
        {
            String lenh = "Update sbTaiKhoan set Password = '" + Password + "', IDNhanVien = '" + IDNhanVien + "', PasswordOld = '"+PasswordOld+"' where Username = '" + ids + "'";
            bool kt = false;
            if (clsXuLy.ExecuteNonQuery(lenh) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public DataTable LoadCobobox()
        {
            DataTable re;
            String lenh = "select * from sbNhanVien";
            re = clsXuLy.TaoBang(lenh);
            return re;
        }
        public int KiemTraTrung(String username)
        {
            String lenh = "select * from sbTaiKhoan where Username = '"+username+"'";
            int kt = 0;
            if (clsXuLy.TaoBang(lenh).Rows.Count > 0)
            {
                kt = 1;
            }
            return kt;
        }
    }
}
