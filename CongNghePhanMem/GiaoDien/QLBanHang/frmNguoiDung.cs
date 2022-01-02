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
    public partial class frmNguoiDung : Form
    {
        DALNhanVien dal_nhanvien = new DALNhanVien();
        DALPhanQuyenNguoiDung dal_phanquyen = new DALPhanQuyenNguoiDung();
        public frmNguoiDung()
        {
            InitializeComponent();
        }
        void Load_NhanVien()
        {
            cbNhanVien.DataSource = dal_nhanvien.LoadData().Tables["NhanVien"];
            cbNhanVien.DisplayMember = "TenNhanVien";
            cbNhanVien.ValueMember = "MaNhanVien";
        }
        void load_NhomNguoiDung()
        {
            cbNhomNguoiDung.DataSource = dal_phanquyen.Load_Data_NhomNguoiDung().Tables["NhomNguoiDung"];
            cbNhomNguoiDung.DisplayMember = "TenNhom";//hien thi len cb nha cung cap
            cbNhomNguoiDung.ValueMember = "MaNhom";
        }
        void Load_data()
        {
            dgvNguoiDung.DataSource = dal_phanquyen.Load_Data_NguoiDung().Tables["NguoiDung"];
            Load_NhanVien();
            load_NhomNguoiDung();
            for (int i = 0; i < dgvNguoiDung.Rows.Count; i++)
            {
                dgvNguoiDung.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void frmNguoiDung_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn Thật Sự Muốn Đóng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Tên Đăng Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Mật Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtMatKhau.Focus();
                return;
            }
            NguoiDung them_data = new NguoiDung();
            them_data.TenDangNhap = txtTenDangNhap.Text;
            them_data.MatKhau = txtMatKhau.Text;
            them_data.MaNhanVien = cbNhanVien.SelectedValue.ToString();
            them_data.MaNhom = cbNhomNguoiDung.SelectedValue.ToString();
            if (dal_phanquyen.Them_NguoiDung(them_data) == 1)
            {
                MessageBox.Show("Thêm Thành công");
                Load_data();
            }
            else
            {
                MessageBox.Show("Nhân Viên Đã Được Cấp Quyền");
            }
        }

        private void dgvNguoiDung_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvNguoiDung.CurrentRow != null)
            {


                txtTenDangNhap.Text = dgvNguoiDung.CurrentRow.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = dgvNguoiDung.CurrentRow.Cells["MatKhau"].Value.ToString();
                string maNhanvien = dgvNguoiDung.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                cbNhanVien.DataSource = dal_nhanvien.TimTheoMa(maNhanvien);
                string maNhom= dgvNguoiDung.CurrentRow.Cells["MaNhom"].Value.ToString();
                cbNhomNguoiDung.DataSource = dal_phanquyen.TimMaNhom(maNhom);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Tên Đăng Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Mật Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtMatKhau.Focus();
                return;
            }
            NguoiDung sua_data = new NguoiDung();
            sua_data.MatKhau = txtMatKhau.Text;
            sua_data.MaNhanVien = cbNhanVien.SelectedValue.ToString();
            sua_data.MaNhom = cbNhomNguoiDung.SelectedValue.ToString();
            sua_data.TenDangNhap = dgvNguoiDung.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            if (dal_phanquyen.Sua_NguoiDung(sua_data) == 1)
            {
                MessageBox.Show("Sửa Thành công");
                Load_data();
            }
            else
            {
                MessageBox.Show("Sửa Thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Thật Sự Muốn Xoá", "Cảnh Báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                NguoiDung Xoa_da = new NguoiDung();
                Xoa_da.TenDangNhap = dgvNguoiDung.CurrentRow.Cells["TenDangNhap"].Value.ToString();
                if (dal_phanquyen.Xoa_NguoiDung(Xoa_da) == 1)//xoa du lieu ra khoi table du lieu
                {
                    MessageBox.Show("Đã Xóa Thành Công");
                    Load_data();
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại");
                }
            }  
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Load_data();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Dữ Liệu Tìm Kiếm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTimKiem.Focus();
                return;
            }
            else
            {
                dgvNguoiDung.DataSource = dal_phanquyen.Tim_TenDangNhap(txtTimKiem.Text);
            }
        } //string t1 = cbNhanVien.SelectedValue.ToString();
            //string t2 = cbNhomNguoiDung.SelectedValue.ToString();
            //txtTenDangNhap.Text = t1 + t2;
    }
}
