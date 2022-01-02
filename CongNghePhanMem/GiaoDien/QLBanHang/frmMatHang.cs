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
using DevComponents.DotNetBar;
namespace QLNhaSach
{
    public partial class frmMatHang : Form
    {
        DALMatHang dl = new DALMatHang();
        DALLoaiMatHang da_LoaiMatHang = new DALLoaiMatHang();
        DALNhaCungCap da_NhaCungCap = new DALNhaCungCap();
        public frmMatHang()
        {
            InitializeComponent();
        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            load_data();
        }
        void Load_LoaiMatHang()
        {
            cbLoaiMatHang.DataSource = da_LoaiMatHang.LoadLoaiMatHang().Tables["LoaiMatHang"];
            cbLoaiMatHang.DisplayMember = "TenLoaiMatHang";
            cbLoaiMatHang.ValueMember = "MaLoaiMatHang";
        }
        void Load_NhaCungCap()
        {
            cbNhaCungCap.DataSource = da_NhaCungCap.LoadData().Tables["NhaCungCap"];
            cbNhaCungCap.DisplayMember = "TenNhaCungCap";//hien thi len cb nha cung cap
            cbNhaCungCap.ValueMember = "MaNhaCungCap";
        }
        void load_data()
        {
            dgvMatHang.DataSource = dl.LoadData().Tables["MatHang"];
            Load_LoaiMatHang();
            txtMaMatHang.Enabled = false;
            Load_NhaCungCap();
            for (int i = 0; i < dgvMatHang.Rows.Count; i++)
            {
                dgvMatHang.Rows[i].Cells[0].Value = i + 1;
            }
            btnXoa.Enabled = btnSua.Enabled = false;
        }
        private void frmMatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn Thật Sự Muốn Đóng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
        private void dgvMatHang_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvMatHang.CurrentRow != null)
            {


                txtMaMatHang.Text = dgvMatHang.CurrentRow.Cells["MaMatHang"].Value.ToString();
                txtTenMatHang.Text = dgvMatHang.CurrentRow.Cells["TenMatHang"].Value.ToString();
                txtSoLuongTon.Text = dgvMatHang.CurrentRow.Cells["SoLuongTon"].Value.ToString();
                cbDonViTinh.Text = dgvMatHang.CurrentRow.Cells["DonViTinh"].Value.ToString();
                string MaLoai = dgvMatHang.CurrentRow.Cells["MaLoaiMatHang"].Value.ToString();
                cbLoaiMatHang.DataSource = da_LoaiMatHang.TimTheoMa(MaLoai);
                string manhacungcap = dgvMatHang.CurrentRow.Cells["MaNhaCungCap"].Value.ToString();
                cbNhaCungCap.DataSource = da_NhaCungCap.TimKiem_TheoMa(manhacungcap);
                cbThoiGianBaoHanh.Text = dgvMatHang.CurrentRow.Cells["ThoiGianBaoHanh"].Value.ToString();
                txtMoTa.Text = dgvMatHang.CurrentRow.Cells["MoTa"].Value.ToString();

            } 
            btnXoa.Enabled = btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaMatHang.Text = dl.MaTuDong();
            txtTenMatHang.Text = txtSoLuongTon.Text = txtMoTa.Text = "";
            btnLuu.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
            Load_LoaiMatHang();
            Load_NhaCungCap();
            txtTenMatHang.Focus();
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn Thật Sự Muốn Xoá", "Cảnh Báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MatHang Xoa_da = new MatHang();
                Xoa_da.MaMatHang = dgvMatHang.CurrentRow.Cells["MaMatHang"].Value.ToString();
                //kiem tra ma co trong ca table hay ko
                if (dl.KiemTra_Ma(Xoa_da.MaMatHang) == true)//có : ko the xoa
                {
                    MessageBox.Show("Dữ Liệu Đang Sử Dụng Không Xóa Đã");
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            Load_LoaiMatHang();
            Load_NhaCungCap();
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
                    dgvMatHang.DataSource =dl.TimKiem_TheoTen(txtTimKiem.Text);
                    for (int i = 0; i < dgvMatHang.Rows.Count; i++)
                    {
                        dgvMatHang.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                else
                {
                    dgvMatHang.DataSource = dl.TimTheoMa(txtTimKiem.Text);
                    for (int i = 0; i < dgvMatHang.Rows.Count; i++)
                    {
                        dgvMatHang.Rows[i].Cells[0].Value = i + 1;
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            load_data();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtTenMatHang.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Tên Mặt Hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenMatHang.Focus();
                return;
            }
            if (txtMoTa.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Mô Tả", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenMatHang.Focus();
                return;
            }
            MatHang them_sua = new MatHang();
            them_sua.MaMatHang = dl.MaTuDong();
            them_sua.DonViTinh = cbDonViTinh.Text;
            them_sua.MaLoaiMatHang = cbLoaiMatHang.SelectedValue.ToString();
            them_sua.MaNhaCungCap = cbNhaCungCap.SelectedValue.ToString();
            them_sua.TenMatHang = txtTenMatHang.Text;
            them_sua.ThoiGianBaoHanh = cbThoiGianBaoHanh.Text;
            them_sua.SoLuongTon = int.Parse(txtSoLuongTon.Text);
            them_sua.MoTa = txtMoTa.Text;
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
                        load_data();
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Bạn Thật Sự Muốn Sửa", "Cảnh Báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    them_sua.MaMatHang = dgvMatHang.CurrentRow.Cells[1].Value.ToString();
                    if (dl.Sua(them_sua) == 1)
                    {
                        MessageBox.Show("Sửa Thành công");
                        load_data();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất bại");
                        load_data();
                    }
                }
            }
            btnThem.Enabled = true;
        }

        private void btnXemIn_Click(object sender, EventArgs e)
        {
            frmInDanhSachMatHang ds = new frmInDanhSachMatHang();
            ds.Show();
        }
    }
}
