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
using System.Text.RegularExpressions;
namespace QLNhaSach
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        DALKhachHang dl = new DALKhachHang();
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            load_data();
        }
        public void load_data()
        {
            btnThem.Focus();
            dgvKhachHang.DataSource = dl.LoadData().Tables["KhachHang"];
            txtMaKhachHang.Enabled = false;
            for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
            {
                dgvKhachHang.Rows[i].Cells[0].Value = i + 1;
            }
            btnLuu.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn Thật Sự Muốn Đóng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow != null)
            {

                txtMaKhachHang.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtTenKhachHang.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                datNgaySinh.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
                
                string gt = dgvKhachHang.CurrentRow.Cells[4].Value.ToString();
                if (gt == "Nam")
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNua.Checked = true;
                }
                txtSoDienThoai.Text = dgvKhachHang.CurrentRow.Cells[5].Value.ToString();
                txtEmail.Text = dgvKhachHang.CurrentRow.Cells[6].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[7].Value.ToString();
            }
            btnSua.Enabled = btnXoa.Enabled = btnThem.Enabled = true;

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
            txtMaKhachHang.Text = dl.MaTuDong();
            txtDiaChi.Text = txtSoDienThoai.Text = txtTenKhachHang.Text = txtEmail.Text = "";
            btnLuu.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
            datNgaySinh.Text = datNgaySinh.Value.ToString();
            txtTenKhachHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Thật Sự Muốn Xoá", "Cảnh Báo", MessageBoxButtons.YesNo,
              MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                KhachHang Xoa_da = new KhachHang();
                Xoa_da.MaKhachHang = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                //kiem tra ma co trong ca table hay ko
                if (dl.KiemTra_Ma(Xoa_da.MaKhachHang) == true)//có : ko the xoa
                {
                    MessageBox.Show("Dữ Liệu Đang Sử Dụng Không Thể Xóa");
                }
                else
                {
                    if (dl.Xoa(Xoa_da) == 1)//xoa du lieu ra khoi table du lieu
                    {
                        MessageBox.Show("Đã Xóa Thành Công");
                        load_data();
                    }
                    else
                    {
                        MessageBox.Show("Đã Xóa Thất Bại");
                    }
                }
            }
        }

        private void btnXemIn_Click(object sender, EventArgs e)
        {
            frmInDanhSachKhachHang ds = new frmInDanhSachKhachHang();
            ds.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == string.Empty)
            {
                MessageBox.Show("Cần Nhập Dữ Liệu");
                txtTimKiem.Focus();
                return;
            }
            else
            {
                if (radMa.Checked == false)
                {
                    dgvKhachHang.DataSource = dl.TimTheoTen(txtTimKiem.Text);
                    for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
                    {
                        dgvKhachHang.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                else
                {
                    dgvKhachHang.DataSource = dl.TimKiem_TheoMa(txtTimKiem.Text);
                    for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
                    {
                        dgvKhachHang.Rows[i].Cells[0].Value = i + 1;
                    }
                }
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
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
            if (txtTenKhachHang.Text == string.Empty )
            {
                MessageBox.Show("Bạn Cần Nhập Tên Khách Hàng");
                txtTenKhachHang.Focus();
                return;
            }
             if( txtSoDienThoai.Text == string.Empty)
             {
                MessageBox.Show("Bạn Cần Nhập Số Điện Thoại");
                txtSoDienThoai.Focus();
                return;
             }
            if(txtDiaChi.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Nhập Địa Chỉ");
                txtDiaChi.Focus();
                return;
            }

            if(txtEmail.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Nhập Email");
                txtEmail.Focus();
                return;
            }
            KhachHang them_sua = new KhachHang();
            them_sua.MaKhachHang = txtMaKhachHang.Text;
            them_sua.TenKhachHang = txtTenKhachHang.Text;
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
            them_sua.DiaChi = txtDiaChi.Text;
            them_sua.Email = txtEmail.Text;
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
                    them_sua.MaKhachHang = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
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
      
    }
}
