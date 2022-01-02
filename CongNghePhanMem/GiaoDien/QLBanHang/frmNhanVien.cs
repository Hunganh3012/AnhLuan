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
using System.IO;
using System.Text.RegularExpressions;
namespace QLNhaSach
{
    public partial class frmNhanVien : Form
    {
        DALNhanVien dl=new DALNhanVien();
        DALPhanQuyenNguoiDung dpq = new DALPhanQuyenNguoiDung();
    
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            load_data();
        }
        void stt()
        {
            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            {
                dgvNhanVien.Rows[i].Cells[0].Value = i + 1;
            }
        }
        public static bool KiemTraEmailHopLe(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public void load_data()
        {
            dgvNhanVien.DataSource = dl.LoadData().Tables["NhanVien"];
            stt();
            cbChucVu.Text= cbChucVu.Items[0].ToString();
            btnXoa.Enabled = btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Focus();
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn Thật Sự Muốn Đóng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                txtTenNhanVien.Text = dgvNhanVien.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                datNgaySinh.Text = dgvNhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
                string gt = dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString();
                if (gt == "Nam")
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNua.Checked = true;
                }
                txtCMND.Text = dgvNhanVien.CurrentRow.Cells["CMND"].Value.ToString();
                txtSoDienThoai.Text = dgvNhanVien.CurrentRow.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = dgvNhanVien.CurrentRow.Cells["Email"].Value.ToString();
                txtQueQuan.Text = dgvNhanVien.CurrentRow.Cells["QueQuan"].Value.ToString();
                txtDiaChiThuongTru.Text = dgvNhanVien.CurrentRow.Cells["DiaChiThuongTru"].Value.ToString();
                datNgayNhanViec.Text = dgvNhanVien.CurrentRow.Cells["NgayVaolam"].Value.ToString();
                cbChucVu.Text = dgvNhanVien.CurrentRow.Cells["ChucVu"].Value.ToString();
            }
            btnXoa.Enabled = btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập Số");
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập Số");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = dl.MaTuDong();
            txtTenNhanVien.Text = txtCMND.Text = txtDiaChiThuongTru.Text = txtEmail.Text = txtQueQuan.Text = txtSoDienThoai.Text = "";
            btnLuu.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
            txtTenNhanVien.Focus();
           
        }

        private void cbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbChucVu.SelectedItem.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Thật Sự Muốn Xoá", "Cảnh Báo", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                NhanVien Xoa_da = new NhanVien();
                Xoa_da.MaNhanVien = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
                if (dl.Xoa(Xoa_da) == 1)//xoa du lieu ra khoi table du lieu
                {
                        MessageBox.Show("Đã Xóa Thành Công");
                        load_data();
                    }
                    else
                    {
                        MessageBox.Show("Dữ Liệu Đang Sửa Dụng Không Thể Xóa");
                    }
                
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load_data();
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
                if (radMa.Checked == false)
                {
                    dgvNhanVien.DataSource = dl.TimKiem_TheoTen(txtTimKiem.Text);
                    for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
                    {
                        dgvNhanVien.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                else
                {
                    dgvNhanVien.DataSource = dl.TimTheoMa(txtTimKiem.Text);
                    for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
                    {
                        dgvNhanVien.Rows[i].Cells[0].Value = i + 1;
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (datNgaySinh.Value.Year < datNgayNhanViec.Value.Year)
            {
                MessageBox.Show("Năm Sinh Phải lớn Hơn Năm Nhận Việc");
            }
            if (KiemTraEmailHopLe(txtEmail.Text) == false)
            {
                MessageBox.Show("Email Không Đúng");
                return;
            }
            if (txtSoDienThoai.TextLength < txtSoDienThoai.MaxLength - 1)
            {
                MessageBox.Show("Số Điện Thoại Không Đúng");
                return;
            }
            if (txtTenNhanVien.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Tên Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenNhanVien.Focus();
                return;
            }
            if (txtCMND.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Phải Nhập CMND", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtCMND.Focus();
                return;
            }
            if (txtDiaChiThuongTru.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Phải Nhập Địa Chỉ Thường Trú", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtDiaChiThuongTru.Focus();
                return;
            }
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Phải Nhập Email", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtEmail.Focus();
                return;
            }
            if (txtQueQuan.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Phải Nhập Quê Quán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtQueQuan.Focus();
                return;
            }
            if (txtSoDienThoai.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Phải Nhập SĐT", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtSoDienThoai.Focus();
                return;
            }
            NhanVien them_sua = new NhanVien();
            them_sua.MaNhanVien = dl.MaTuDong();
            them_sua.TenNhanVien = txtTenNhanVien.Text;
            if (radNam.Checked == true)
            {
                them_sua.GioiTinh = radNam.Text;
            }
            else
            {
                them_sua.GioiTinh = radNua.Text;
            }
            them_sua.NgaySinh = datNgaySinh.Value.Date;
            them_sua.SoDienThoai = txtSoDienThoai.Text;
            them_sua.DiaChiThuongTru = txtDiaChiThuongTru.Text;
            them_sua.Email = txtEmail.Text;
            them_sua.QueQuan = txtQueQuan.Text;
            them_sua.CMND = txtCMND.Text;
            them_sua.ChucVu = cbChucVu.Text;
            them_sua.NgayVaoLam = datNgayNhanViec.Value.Date;
            if (btnThem.Enabled == true)
            {
                if (MessageBox.Show("Bạn Thật Sự Muốn Thêm", "Cảnh Báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (dl.Them(them_sua) == 1)
                    {
                        MessageBox.Show("Thêm Thành công");
                        load_data();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất bại");
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Bạn Thật Sự Muốn Sửa", "Cảnh Báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    them_sua.MaNhanVien = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
                    if (dl.Sua(them_sua) == 1)
                    {
                        MessageBox.Show("Sửa Thành công");
                        load_data();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất bại");
                    }
                }
            }
            btnThem.Enabled = true;
            
        }

        private void btnXemIn_Click(object sender, EventArgs e)
        {
            frmInDanhSachNhanVien ds = new frmInDanhSachNhanVien();
            ds.Show();
        }  
        
    }
}
