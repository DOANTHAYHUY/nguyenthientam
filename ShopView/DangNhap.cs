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
using static ShopModel.clsXuLy;

namespace ShopView
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        clsXuLy xuly = new clsXuLy();
        DangNhapController controller = new DangNhapController();
        DangNhapModel model = new DangNhapModel();
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (controller.GetTaiKhoanByUsername(txtUsername.Text, txtMatKhau.Text))
            {
                LoginInfo.UserID = txtUsername.Text;
                MessageBox.Show("Bạn đã đang nhập thành công");
                Form dangnhap = new DangNhap();
                Form main = new FormMain();
                this.Hide();
                main.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công, vui lòng kiểm tra lại");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
