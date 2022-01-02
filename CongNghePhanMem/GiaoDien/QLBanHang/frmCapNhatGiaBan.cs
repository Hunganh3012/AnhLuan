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

namespace QLNhaSach
{
    public partial class frmCapNhatGiaBan : Form
    {
        public frmCapNhatGiaBan()
        {
            InitializeComponent();
        }
        DALGiaBan dl = new DALGiaBan();
        DALMatHang da_mh = new DALMatHang();
        DALLoaiMatHang da_loaimh = new DALLoaiMatHang();
        void Load_LoaiMatHang()
        {
            cbLoaiMatHang.DataSource = da_loaimh.LoadLoaiMatHang().Tables["LoaiMatHang"];
            cbLoaiMatHang.DisplayMember = "TenLoaiMatHang";
            cbLoaiMatHang.ValueMember = "MaLoaiMatHang";
        }
        //load ds mat hang
        void Load_MatHang()
        {
            cbMatHang.DataSource = da_mh.LoadData().Tables["MatHang"];
            cbMatHang.DisplayMember = "TenMatHang";
            cbMatHang.ValueMember = "MaMatHang";
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDonGiaBan.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Phải Nhập Đơn Giá Bán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtDonGiaBan.Focus();
                return;
            }
            GiaBan them_data = new GiaBan();
            them_data.MaDonGiaBan = dl.MaTuDong();
            them_data.MaMatHang = cbMatHang.SelectedValue.ToString();
            DateTime today = DateTime.Now;
            them_data.NgayThayDoi = today.Date;
            them_data.DonGiaBan = float.Parse(txtDonGiaBan.Text);
            if (dl.CapNhatGiaBan(them_data) == 1)
            {
                MessageBox.Show("Thêm Thành công");
                loadDATA();
            }
            else
            {
                MessageBox.Show("Thêm Thất bại");
            }

        }
        void loadDATA()
        {
            Load_MatHang();
            Load_LoaiMatHang();
            dgvGiaBan.DataSource = dl.LoadGiaBan().Tables["GiaBan"];
            for (int i = 0; i < dgvGiaBan.Rows.Count; i++)
            {
                dgvGiaBan.Rows[i].Cells[0].Value = i + 1;
            }
            
        }
        private void frmCapNhatGiaBan_Load(object sender, EventArgs e)
        {
            loadDATA();
            cbMatHang.DataSource = dl.TimTheoMa(cbLoaiMatHang.SelectedValue.ToString());
            
        }

        private void cbLoaiMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMatHang.DataSource = dl.TimTheoMa(cbLoaiMatHang.SelectedValue.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Thật Sự Muốn Xoá", "Cảnh Báo", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                GiaBan xoa = new GiaBan();
                xoa.MaDonGiaBan = dgvGiaBan.CurrentRow.Cells[1].Value.ToString();
                if (dl.Xoa(xoa) == 1)//xoa du lieu ra khoi table du lieu
                {
                    MessageBox.Show("Đã Xóa Thành Công");
                    loadDATA();
                }
                else
                {
                    MessageBox.Show("Dữ Liệu Đang Sử Dụng Không Thể Xóa");
                }
            }

        }
    }
}
