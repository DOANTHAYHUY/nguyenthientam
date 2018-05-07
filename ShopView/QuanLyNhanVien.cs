using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopController;
using ShopModel;

namespace ShopView
{
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        NhanVienController controller = new NhanVienController();
        NhanVienModel model = new NhanVienModel();
        int ids = 0;
        bool ThemMoi = true;
        public void SetNull()
        {
            cbGioiTinh.SelectedIndex = 1;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiachi.Text = "";
            txtCMND.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            dtNgaySinh.Text = DateTime.Now.ToString();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ThemMoi == true)
            {
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtDiachi.Text == "" || txtCMND.Text == "" || txtDienThoai.Text == "" || txtEmail.Text == "" || cbGioiTinh.SelectedIndex == 0)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại");
                }
                else
                {
                    if (controller.KiemTraTrung(txtMaNV.Text) > 0)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng kiểm tra lại!");
                    }
                    else
                    {
                        if (controller.Them(txtMaNV.Text, txtTenNV.Text, DateTime.Parse(dtNgaySinh.Text), cbGioiTinh.SelectedIndex , txtDiachi.Text, txtCMND.Text, txtDienThoai.Text, txtEmail.Text))
                        {
                            MessageBox.Show("Bạn đã thêm thành công nhân viên");
                            gvNhanVien.DataSource = model.LoadData();
                            btnHuy_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy ra lỗi, vui lòng kiểm tra lại");
                        }
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ThemMoi == false)
            {
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtDiachi.Text == "" || txtCMND.Text == "" || txtDienThoai.Text == "" || txtEmail.Text == "" || cbGioiTinh.SelectedIndex == 0)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại");
                }
                else
                {
                    if (controller.KiemTraTrung_Sua(ids, txtMaNV.Text))
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng kiểm tra lại!");
                    }
                    else
                    {
                        if (controller.Sua(ids,txtMaNV.Text, txtTenNV.Text, DateTime.Parse(dtNgaySinh.Text), cbGioiTinh.SelectedIndex, txtDiachi.Text, txtCMND.Text, txtDienThoai.Text, txtEmail.Text))
                        {
                            MessageBox.Show("Bạn đã sửa thành công nhân viên");
                            gvNhanVien.DataSource = model.LoadData();
                            btnHuy_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy ra lỗi, vui lòng kiểm tra lại");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhân viên");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThemMoi == false)
            {
                if (controller.Xoa(ids))
                {
                    MessageBox.Show("Bạn đã xóa thành công nhân viên");
                    gvNhanVien.DataSource = model.LoadData();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi, vui lòng kiểm tra lại");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhân viên cần xóa");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            gvNhanVien.DataSource = model.LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ThemMoi = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            SetNull();
            ids = 0;
        }

        private void gvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = gvNhanVien.CurrentRow.Index;
                cbGioiTinh.Text = gvNhanVien.Rows[i].Cells["GioiTinh"].Value.ToString();
                txtMaNV.Text = gvNhanVien.Rows[i].Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = gvNhanVien.Rows[i].Cells["HoTen"].Value.ToString();
                dtNgaySinh.Text = gvNhanVien.Rows[i].Cells["NgaySinh"].Value.ToString();
                txtDiachi.Text = gvNhanVien.Rows[i].Cells["DiaChi"].Value.ToString();
                txtCMND.Text = gvNhanVien.Rows[i].Cells["SoCMND"].Value.ToString();
                txtDienThoai.Text = gvNhanVien.Rows[i].Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = gvNhanVien.Rows[i].Cells["Email"].Value.ToString();
                ThemMoi = false;
                ids = int.Parse(gvNhanVien.Rows[i].Cells["ID"].Value.ToString());
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            cbGioiTinh.Items.Add("--Chọn giới tính--");
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedIndex = 0;
            gvNhanVien.DataSource = model.LoadData();
            btnHuy_Click(sender, e);
        }
    }
}
