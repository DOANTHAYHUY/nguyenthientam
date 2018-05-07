using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModel;

namespace ShopController
{
   public class TaiKhoanController
    {
        TaiKhoanModel model = new TaiKhoanModel();
        public bool ThemTaiKhoan(String Username, String Password, Int32 IDnhanVien, String PasswordOld)
        {
            return model.ThemTaiKhoan(Username, Password, IDnhanVien, PasswordOld);
        }
        public bool XoaTaiKhoan(String id)
        {
            return model.XoaTaiKhoan(id);
        }
        public bool SuaTaiKhoan(String ids, String Username, String Password, Int32 IDNhanVien, String PasswordOld)
        {
            return model.SuaTaiKhoan(ids, Username, Password, IDNhanVien, PasswordOld);
        }
        public int KiemTraTrung(String username)
        {
            return model.KiemTraTrung(username);
        }
    }
}
