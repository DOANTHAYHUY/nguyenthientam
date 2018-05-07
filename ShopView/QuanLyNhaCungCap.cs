using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopModel;
using ShopController;

namespace ShopView
{
    public partial class QuanLyNhaCungCap : Form
    {
        public QuanLyNhaCungCap()
        {
            InitializeComponent();
        }
        NhacungCapModel nccmodel = new NhacungCapModel();
        NhaCungCapController ncccontroller = new NhaCungCapController();
        bool ThemMoi = true;
        int ids = 0;
        //public void SetButton_Open()
        //{
        //    btnThem.Enabled = true;
        //    btnSua.Enabled = true;
        //    btnXoa.Enabled = true;
        //    btnXem.Enabled = true;
        //    btnHuy.Enabled = false;
        //}
        //public void SetButton_Close()
        //{

        //    btnThem.Enabled = false;
        //    btnSua.Enabled = false;
        //    btnXoa.Enabled = false;
        //    btnXem.Enabled = true;
        //    btnHuy.Enabled = true;
        //}
        public void SetNull()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiachi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtNguoiDaiDien.Text = "";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ThemMoi == true)
            {
                if (txtMaNCC.Text == "" || txtTenNCC.Text == "" || txtDiachi.Text == "" || txtNguoiDaiDien.Text == "" || txtDienThoai.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại");
                }
                else
                {
                    if (ncccontroller.ThemNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiachi.Text, txtNguoiDaiDien.Text, txtDienThoai.Text, txtEmail.Text))
                    {
                        MessageBox.Show("Bạn đã thêm thành công nhà cung cấp");
                        gvNhacungCap.DataSource = nccmodel.LoadData();
                        btnHuy_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi, vui lòng kiểm tra lại");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ThemMoi == false)
            {
                if (txtMaNCC.Text == "" || txtTenNCC.Text == "" || txtDiachi.Text == "" || txtNguoiDaiDien.Text == "" || txtDienThoai.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại");
                }
                else
                {
                    if (ncccontroller.SuaNCC(ids, txtMaNCC.Text, txtTenNCC.Text, txtDiachi.Text, txtNguoiDaiDien.Text, txtDienThoai.Text, txtEmail.Text))
                    {
                        MessageBox.Show("Bạn đã sửa thành công nhà cung cấp");
                        gvNhacungCap.DataSource = nccmodel.LoadData();
                        btnHuy_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi, vui lòng kiểm tra lại");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thông tin cần sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThemMoi == false)
            {
                if (ncccontroller.XoaNCC(ids))
                {
                    MessageBox.Show("Bạn đã xóa thành công nhà cung cấp");
                    gvNhacungCap.DataSource = nccmodel.LoadData();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi, vui lòng kiểm tra lại");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp cần xóa");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            gvNhacungCap.DataSource = nccmodel.LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ThemMoi = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            SetNull();
            ids = 0;
            //gvNhacungCap.DataSource = nccmodel.LoadData();
        }

        private void QuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            gvNhacungCap.DataSource = nccmodel.LoadData();
            btnHuy_Click(sender, e);
        }

        private void gvNhacungCap_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = gvNhacungCap.CurrentRow.Index;
                txtMaNCC.Text = gvNhacungCap.Rows[i].Cells["MaNhaCungCap"].Value.ToString();
                txtTenNCC.Text = gvNhacungCap.Rows[i].Cells["TenNhaCungCap"].Value.ToString();
                txtDiachi.Text = gvNhacungCap.Rows[i].Cells["DiaChi"].Value.ToString();
                txtNguoiDaiDien.Text = gvNhacungCap.Rows[i].Cells["NguoiDaiDien"].Value.ToString();
                txtDienThoai.Text = gvNhacungCap.Rows[i].Cells["DienThoai"].Value.ToString();
                txtEmail.Text = gvNhacungCap.Rows[i].Cells["Email"].Value.ToString();
                ThemMoi = false;
                ids = int.Parse(gvNhacungCap.Rows[i].Cells["ID"].Value.ToString());
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        private void gvNhacungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
