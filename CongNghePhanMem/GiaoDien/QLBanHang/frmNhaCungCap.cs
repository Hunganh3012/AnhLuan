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
    public partial class frmNhaCungCap : Form
    {
        DALNhaCungCap dl = new DALNhaCungCap();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            btnThem.Focus();
            dgvNhaCungCap.DataSource = dl.LoadData().Tables["NhaCungCap"];
            for (int i = 0; i < dgvNhaCungCap.Rows.Count; i++)
            {
                dgvNhaCungCap.Rows[i].Cells[0].Value = i + 1;
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = btnSua.Enabled = false;
            
        }
        private void dgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow != null)
            {

                txtMaNhaCungCap.Text = dgvNhaCungCap.CurrentRow.Cells["MaNhaCungCap"].Value.ToString();
                txtTenNhaCungCap.Text = dgvNhaCungCap.CurrentRow.Cells["TenNhaCungCap"].Value.ToString();
                txtDiaChi.Text = dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtSoDienThoai.Text = dgvNhaCungCap.CurrentRow.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = dgvNhaCungCap.CurrentRow.Cells["Email"].Value.ToString();
            }
            btnXoa.Enabled = btnSua.Enabled = true;
        }

        private void frmiNhaCungCap_Load(object sender, EventArgs e)
        {
            load_data();
        }
        private void frmiNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn Thật Sự Muốn Đóng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNhaCungCap.Text = dl.MaTuDong();
            txtDiaChi.Text = txtEmail.Text = txtSoDienThoai.Text = txtTenNhaCungCap.Text = "";
            btnLuu.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
            txtTenNhaCungCap.Focus();
           
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
                NhaCungCap Xoa_data = new NhaCungCap();
                Xoa_data = new NhaCungCap();
                Xoa_data.MaNhaCungCap = dgvNhaCungCap.CurrentRow.Cells[1].Value.ToString();
                //kiem tra ma co trong ca table hay ko
                if (dl.Xoa(Xoa_data) == 1)//xoa du lieu ra khoi table du lieu
                {
                    MessageBox.Show("Đã Xóa Thành Công");
                    load_data();
                }
                else
                {
                    MessageBox.Show("Dữ Liệu Đang Sử Dụng Không Thể Xóa");
                }
            }
        }
        private void btnXemIn_Click(object sender, EventArgs e)
        {
            frmInDanhSachNhaCungCap ds = new frmInDanhSachNhaCungCap();
            ds.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load_data();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Email", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtEmail.Focus();
                return;
            }
            if (radMa.Checked == true)
            {
                dgvNhaCungCap.DataSource = dl.TimKiem_TheoMa(txtTimKiem.Text);
                for (int i = 0; i < dgvNhaCungCap.Rows.Count; i++)
                {
                    dgvNhaCungCap.Rows[i].Cells[0].Value = i + 1;
                }

            }
            else
            {
                dgvNhaCungCap.DataSource = dl.TimKiem_TheoTen(txtTimKiem.Text);
                for (int i = 0; i < dgvNhaCungCap.Rows.Count; i++)
                {
                    dgvNhaCungCap.Rows[i].Cells[0].Value = i + 1;
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
            if (txtSoDienThoai.TextLength < txtSoDienThoai.MaxLength-1)
            {
                MessageBox.Show("Số Điện Thoại Không Đúng");
                return;
            }
            if (txtTenNhaCungCap.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Tên Nhà Cung Cấp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenNhaCungCap.Focus();
                return;
            }
            if (txtSoDienThoai.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Số Điện Thoại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtSoDienThoai.Focus();
                return;
            }
            if (txtDiaChi.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Địa Chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtDiaChi.Focus();
                return;
            }
            if (txtEmail.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Email", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtEmail.Focus();
                return;
            }
            
            NhaCungCap them_sua = new NhaCungCap();
            them_sua.MaNhaCungCap = dl.MaTuDong();
            them_sua.TenNhaCungCap = txtTenNhaCungCap.Text;
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
                    them_sua.MaNhaCungCap = dgvNhaCungCap.CurrentRow.Cells[1].Value.ToString();
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

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtSoDienThoai_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập Số");
            }

        }
    }
}
