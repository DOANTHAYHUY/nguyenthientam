using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
   public class NhanVienModel
    {
        public DataTable LoadData()
        {
            DataTable re;
            re = clsXuLy.GetData("sp_NhanVien_LoadGrid");
            return re;
        }
        public bool Them(String MaNV, String HoTen, DateTime NgaySinh, Int32 GioiTinh, String DiaChi, String CMND, String DienThoai, String Email)
        {
            String lenh = "insert into sbNhanVien values('" + MaNV + "', N'" + HoTen + "', '"+ NgaySinh + "', '"+GioiTinh+"', N'" + DiaChi + "', N'" + CMND + "', '" + DienThoai + "', '" + Email + "')";
            bool kt = false;
            if (clsXuLy.ExecuteNonQuery(lenh) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool Xoa(Int32 id)
        {
            String lenhxoa = "Delete from sbNhanVien where ID = '" + id + "'";
            bool kt = false;
            if (clsXuLy.ExecuteNonQuery(lenhxoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool Sua(Int32 ID, String MaNV, String HoTen, DateTime NgaySinh, Int32 GioiTinh, String DiaChi, String CMND, String DienThoai, String Email)
        {
            String lenh = "Update sbNhanVien set MaNhanVien = '" + MaNV + "', HoTen =  N'" + HoTen + "', NgaySinh = '" + NgaySinh + "', GioiTinh = '" + GioiTinh + "', DiaChi = N'" + DiaChi + "', SoCMND =  N'" + CMND + "', SoDienThoai = '" + DienThoai + "', Email = '" + Email + "' where ID = '"+ID+"'";
            bool kt = false;
            if (clsXuLy.ExecuteNonQuery(lenh) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public int KiemTraTrung(String Ma)
        {
            String lenh = "select * from sbNhanVien where MaNhanVien = '" + Ma + "'";
            int kt = 0;
            if (clsXuLy.TaoBang(lenh).Rows.Count > 0)
            {
                kt = 1;
            }
            return kt;
        }
        public bool KiemTraTrung_Sua(Int32 ids, String Ma)
        {
            String lenh = "select * from sbNhanVien where MaNhanVien = '" + Ma + "' and ID != '"+ids+"'";
            bool kt = false;
            if (clsXuLy.TaoBang(lenh).Rows.Count > 0)
            {
                kt = true;
            }
            return kt;
        }
    }
}
