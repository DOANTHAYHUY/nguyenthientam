using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopModel;

namespace ShopController
{
   public class NhanVienController
    {
        NhanVienModel model = new NhanVienModel();
        public bool Them(String MaNV, String HoTen, DateTime NgaySinh, Int32 GioiTinh, String DiaChi, String CMND, String DienThoai, String Email)
        {
            return model.Them(MaNV, HoTen, NgaySinh, GioiTinh, DiaChi, CMND, DienThoai, Email);
        }
        public bool Xoa(Int32 id)
        {
            return model.Xoa(id);
        }
        public bool Sua(Int32 ID, String MaNV, String HoTen, DateTime NgaySinh, Int32 GioiTinh, String DiaChi, String CMND, String DienThoai, String Email)
        {
            return model.Sua(ID, MaNV, HoTen, NgaySinh, GioiTinh, DiaChi, CMND, DienThoai, Email);
        }
        public int KiemTraTrung(String username)
        {
            return model.KiemTraTrung(username);
        }
        public bool KiemTraTrung_Sua(Int32 ids, String username)
        {
            return model.KiemTraTrung_Sua(ids, username);
        }
    }
}
