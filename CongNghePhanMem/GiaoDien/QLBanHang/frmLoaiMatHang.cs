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
    public partial class frmLoaiMatHang : Form
    {
        DALLoaiMatHang dl = new DALLoaiMatHang();
        public frmLoaiMatHang()
        {
            InitializeComponent();
        }
        public void load_data_LoaiMatHang()
        {
            dgvLoaiMatHang.DataSource = dl.LoadLoaiMatHang().Tables["LoaiMatHang"];
         
          
       
            for (int i = 0; i < dgvLoaiMatHang.Rows.Count; i++)
            {
                dgvLoaiMatHang.Rows[i].Cells[0].Value = i + 1;
            }
            btnXoa.Enabled = btnSua.Enabled = false;
        }
        private void frmLoaiMatHang_Load(object sender, EventArgs e)
        {
            radMa.Checked = true;
            load_data_LoaiMatHang();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            load_data_LoaiMatHang();
        }

        private void frmLoaiMatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn Thật Sự Muốn Đóng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        } 
        private void dgvLoaiMatHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoaiMatHang.CurrentRow != null)
            {

                txtMaLoaiMatHang.Text = dgvLoaiMatHang.CurrentRow.Cells[1].Value.ToString();
                txtTenLoaiMatHang.Text = dgvLoaiMatHang.CurrentRow.Cells[2].Value.ToString();
            }
            btnXoa.Enabled = btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaLoaiMatHang.Text = dl.MaTuDong();
            txtTenLoaiMatHang.Text = "";
            btnLuu.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
            txtTenLoaiMatHang.Focus();
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn Thật Sự Muốn Xoá", "Cảnh Báo", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                LoaiMatHang Xoa_loaiMathang = new LoaiMatHang();
                Xoa_loaiMathang.MaLoaiMatHang = dgvLoaiMatHang.CurrentRow.Cells[1].Value.ToString();
                if (dl.XoaLoaiMatHang(Xoa_loaiMathang) == 1)//xoa du lieu ra khoi table du lieu
                {
                    MessageBox.Show("Đã Xóa Thành Công");
                    load_data_LoaiMatHang();
                }
                else
                {
                    MessageBox.Show("Dữ Liệu Đang Sử Dụng ");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnXemIn_Click(object sender, EventArgs e)
        {
            frmInDanhSachLoaiMatHang inds = new frmInDanhSachLoaiMatHang();
            inds.Show();

        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            load_data_LoaiMatHang();
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
                    dgvLoaiMatHang.DataSource = dl.TimTheoTen(txtTimKiem.Text);
                    for (int i = 0; i < dgvLoaiMatHang.Rows.Count; i++)
                    {
                        dgvLoaiMatHang.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                else
                {
                    dgvLoaiMatHang.DataSource = dl.TimTheoMa(txtTimKiem.Text);
                    for (int i = 0; i < dgvLoaiMatHang.Rows.Count; i++)
                    {
                        dgvLoaiMatHang.Rows[i].Cells[0].Value = i + 1;
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiMatHang.Text == string.Empty)//neu du lieu can xu ly ma rong thi bao can nhap su lieu
            {
                MessageBox.Show("Bạn Cần Phải Nhập Dữ Liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenLoaiMatHang.Focus();
                return;
            }
            LoaiMatHang them_sua = new LoaiMatHang();
            them_sua.MaLoaiMatHang = dl.MaTuDong();
            them_sua.TenLoaiMatHang = txtTenLoaiMatHang.Text;
            if (btnThem.Enabled == true)
            {
                if (MessageBox.Show("Bạn Thật Sự Muốn Thêm", "Cảnh Báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (dl.ThemLoaiMaThang(them_sua) == 1)
                    {
                        MessageBox.Show("Thêm Thành công");
                        load_data_LoaiMatHang();
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
                    them_sua.MaLoaiMatHang = dgvLoaiMatHang.CurrentRow.Cells[1].Value.ToString();
                    if (dl.SuaLoaiMathang(them_sua) == 1)
                    {
                        MessageBox.Show("Sửa Thành công");
                        load_data_LoaiMatHang();
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
