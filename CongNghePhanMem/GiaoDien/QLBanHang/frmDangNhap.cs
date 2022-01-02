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
    public partial class frmDangNhap : Form
    {
        DALPhanQuyenNguoiDung dal_quyen = new DALPhanQuyenNguoiDung();
        public frmDangNhap()
        {
            InitializeComponent();
        }
        //============load du lieu quyen =======//
        void load_DL()
        {
           
            
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            btnDangNhap.Focus();
           
        }
        //-------------dang nhap vao he thong ========//
        void DangNhapHeThong()
        {
            if (dal_quyen.DangNhapHeThong(txtTenDangNhap.Text, txtMatKhau.Text) == true)
            {
                this.Hide();
                frmChinh show = new frmChinh();
                show.pTenDagNhap = txtTenDangNhap.Text;
                frmDoiMatKhau dn = new frmDoiMatKhau();
                dn.pTenDangNhap = txtTenDangNhap.Text;
                show.Show();
               
            }
            else
            {
                MessageBox.Show("Tài Khoản Không Đúng Vui Lòng Kiểm Tra Lại Thông Tin");
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhapHeThong();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMatKhau.Clear();
            txtTenDangNhap.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn Thật Sự Muốn Đóng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.TextLength == txtMatKhau.MaxLength)
            {
                btnDangNhap.Focus();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
