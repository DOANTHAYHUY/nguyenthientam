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
    public partial class QuanLyTaiKKhoan : Form
    {
        public QuanLyTaiKKhoan()
        {
            InitializeComponent();
        }
        TaiKhoanController controller = new TaiKhoanController();
        TaiKhoanModel model = new TaiKhoanModel();
        bool ThemMoi = true;
        string ids = "";
        clsXuLy xuly = new clsXuLy();
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ThemMoi == true)
            {
                if (txtUsername.Text == "" || txtMatKhau.Text == "" || txtNhapLaiMatKhau.Text == "" || cbNhanVien.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại");
                }
                else
                {
                    if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)
                    {
                        MessageBox.Show("Mật khẩu không khớp. Vui lòng kiểm tra lại");
                    }
                    else if (controller.KiemTraTrung(txtUsername.Text) > 0)
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng kiểm tra lại!");
                    }
                    else
                    {
                        if (controller.ThemTaiKhoan(txtUsername.Text, xuly.ConvertMD5(txtMatKhau.Text), int.Parse(cbNhanVien.SelectedValue.ToString()), txtMatKhau.Text))
                        {
                            MessageBox.Show("Bạn đã thêm thành công tài khoản");
                            gvTaiKhoan.DataSource = model.LoadData();
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
        public void SetNull()
        {
            cbNhanVien.SelectedIndex = 1;
            txtUsername.Text = "";
            txtMatKhau.Text = "";
            txtNhapLaiMatKhau.Text = "";
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ThemMoi == false)
            {
                if (txtUsername.Text == "" || txtMatKhau.Text == "" || txtNhapLaiMatKhau.Text == "" || cbNhanVien.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại");
                }
                else
                {
                    if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)
                    {
                        MessageBox.Show("Mật khẩu không khớp. Vui lòng kiểm tra lại");
                    }
                    if (controller.SuaTaiKhoan(ids,txtUsername.Text, xuly.ConvertMD5(txtMatKhau.Text), int.Parse(cbNhanVien.SelectedValue.ToString()), txtMatKhau.Text))
                    {
                        MessageBox.Show("Bạn đã sửa thành công tài khoản");
                        gvTaiKhoan.DataSource = model.LoadData();
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
                if (controller.XoaTaiKhoan(ids))
                {
                    MessageBox.Show("Bạn đã xóa thành công tài khoản");
                    gvTaiKhoan.DataSource = model.LoadData();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi, vui lòng kiểm tra lại");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản cần xóa");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ThemMoi = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            SetNull();
            ids = "";
            txtUsername.Enabled = true;
            cbNhanVien.Enabled = true;
        }

        private void QuanLyTaiKKhoan_Load(object sender, EventArgs e)
        {
            cbNhanVien.DataSource = model.LoadCobobox();
            cbNhanVien.ValueMember = "ID";
            cbNhanVien.DisplayMember = "HoTen";
            Search();
            btnHuy_Click(sender, e);
        }
        private void Search()
        {
            gvTaiKhoan.DataSource = model.LoadData();
        }

        private void gvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = gvTaiKhoan.CurrentRow.Index;
                cbNhanVien.Text = gvTaiKhoan.Rows[i].Cells["HoTen"].Value.ToString();
                txtUsername.Text = gvTaiKhoan.Rows[i].Cells["Username"].Value.ToString();
                txtMatKhau.Text = gvTaiKhoan.Rows[i].Cells["PasswordOld"].Value.ToString();
                txtNhapLaiMatKhau.Text = gvTaiKhoan.Rows[i].Cells["PasswordOld"].Value.ToString();
                ThemMoi = false;
                ids = gvTaiKhoan.Rows[i].Cells["Username"].Value.ToString();
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtUsername.Enabled = false;
                cbNhanVien.Enabled = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
