using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
   public class DangNhapModel
    {
        clsXuLy xuly = new clsXuLy();
        public bool GetTaiKhoanByUsername(string Username, string password)
        {
            string lenh = "select * from sbTaiKhoan where Username = '"+Username+"' and Password = '"+xuly.ConvertMD5(password)+"'";
            bool kt = false;
            if(clsXuLy.TaoBang(lenh).Rows.Count > 0)
            {
                kt = true;
            }
            return
                kt;
        }

    }
}
