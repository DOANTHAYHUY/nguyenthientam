using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ShopModel
{
   public class NhacungCapModel
    {
        public DataTable LoadData()
        {
            DataTable re;
            String lenh = "select * from sbNhaCungCap";
            re = clsXuLy.TaoBang(lenh);
            return re;
        }
        public bool ThemNCC(String MaNCC, String TenNCC, String DiaChi, String NguoiDaiDien, String DienThoai, String Email)
        {
            String lenh = "insert into sbNhaCungCap values('"+MaNCC+"', N'"+TenNCC+"', N'"+DiaChi+"', N'"+NguoiDaiDien+"', '"+DienThoai+"', '"+Email+"')";
            bool kt = false;
            if(clsXuLy.ExecuteNonQuery(lenh) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool XoaNCC(Int32 id)
        {
            String lenhxoa = "Delete from sbNhaCungCap where ID = '"+id+"'";
            bool kt = false;
            if (clsXuLy.ExecuteNonQuery(lenhxoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool SuaNCC(Int32 ID, String MaNCC, String TenNCC, String DiaChi, String NguoiDaiDien, String DienThoai, String Email)
        {
            String lenh = "Update sbNhaCungCap set MaNhaCungCap = '" + MaNCC + "', TenNhaCungCap = N'" + TenNCC + "', DiaChi = N'" + DiaChi + "', NguoiDaiDien = N'" + NguoiDaiDien + "', DienThoai = '" + DienThoai + "', Email = '" + Email + "' where ID = '"+ID+"'";
            bool kt = false;
            if (clsXuLy.ExecuteNonQuery(lenh) > 0)
            {
                kt = true;
            }
            return kt;
        }
    }
}
