using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModel;

namespace ShopController
{
   public class NhaCungCapController
    {
        NhacungCapModel nccModel = new NhacungCapModel();
        public bool ThemNCC(String MaNCC, String TenNCC, String DiaChi, String NguoiDaiDien, String DienThoai, String Email)
        {
            return nccModel.ThemNCC(MaNCC, TenNCC, DiaChi, NguoiDaiDien, DienThoai, Email);
        }
        public bool XoaNCC(Int32 id)
        {
            return nccModel.XoaNCC(id);
        }
        public bool SuaNCC(Int32 ID, String MaNCC, String TenNCC, String DiaChi, String NguoiDaiDien, String DienThoai, String Email)
        {
            return nccModel.SuaNCC(ID, MaNCC, TenNCC, DiaChi, NguoiDaiDien, DienThoai, Email);
        }
    }
}
