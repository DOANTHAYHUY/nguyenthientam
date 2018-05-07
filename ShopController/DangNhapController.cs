using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModel;

namespace ShopController
{
    public class DangNhapController
    {
        clsXuLy xuly = new clsXuLy();
        DangNhapModel model = new DangNhapModel();
        public bool GetTaiKhoanByUsername(string Username, string password)
        {
            return model.GetTaiKhoanByUsername(Username, password);
        }
    }
}
