using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
using QLNhaSach.XuLy;
namespace QLNhaSach
{
    public partial class frmDoiMatKhau : Form
    {
        DALPhanQuyenNguoiDung da_phanquyen = new DALPhanQuyenNguoiDung();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public string pQuyen { get; set; }
        public string pTenDangNhap { get; set; }
        bool KiemTraMatKhauMoi()
        {
            if (txtMatKhauMoi.Text == txtNhapLaiMk.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (da_phanquyen.KiemTraMatKhauCu(pTenDangNhap, txtMatKhauCu.Text) == false)
            {
                txtMatKhauCu.Text="";
                txtMatKhauCu.Focus();
                MessageBox.Show("Mật Khẩu cũ Không đúng");
                return;
            }
            if(KiemTraMatKhauMoi() == false)
            {
                MessageBox.Show("Mật Khẩu Nhập Lại Không Khớp");
                txtMatKhauMoi.Text = "";
                txtNhapLaiMk.Text = "";
                txtMatKhauMoi.Focus();
                return;
               

            }
            if (da_phanquyen.DoiMatKhau(pTenDangNhap, txtMatKhauMoi.Text) == 1)
            {
                    MessageBox.Show("Đổi Mật Khẩu Thành Công");
            }
            else
            {
                MessageBox.Show("Đổi Mật Khẩu Thất Bại");
            }

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLaiMk.Text = "";
        }
    }
}
