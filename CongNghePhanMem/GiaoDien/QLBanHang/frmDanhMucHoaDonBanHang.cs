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
    public partial class frmDanhMucHoaDonBanHang : Form
    {

        DALMatHang da_mh = new DALMatHang();
        DALKhachHang da_kh = new DALKhachHang();
        DALNhanVien da_nv = new DALNhanVien();
        DALLoaiMatHang da_loaimh = new DALLoaiMatHang();
        DALHoaDonBanHang da_hd = new DALHoaDonBanHang();
        DALChiTietHoaDonBanHang da_cthd = new DALChiTietHoaDonBanHang();
        public frmDanhMucHoaDonBanHang()
        {
            InitializeComponent();
        }
        void LoadDSHoaDon()
        {
            dgvDsHoaDonBanHang.DataSource = da_hd.LoadDanhSachHoaDon();
            for (int i = 0; i < dgvDsHoaDonBanHang.Rows.Count; i++)
            {
                dgvDsHoaDonBanHang.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void frmDanhMucHoaDonBanHang_Load(object sender, EventArgs e)
        {
            LoadDSHoaDon();
        }

        private void dgvDsHoaDonBanHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDsHoaDonBanHang.CurrentRow != null)
            {
                string pmahd = dgvDsHoaDonBanHang.CurrentRow.Cells["MaHoaDonBanHang"].Value.ToString();
                dgvHoaDonBanHang.DataSource = da_hd.Load_ChiTietHoaDonBanHang(pmahd);
                for (int i = 0; i < dgvHoaDonBanHang.Rows.Count; i++)
                {
                    dgvHoaDonBanHang.Rows[i].Cells[0].Value = i + 1;
                    float dongiaban = float.Parse(dgvHoaDonBanHang.Rows[i].Cells["DonGia"].Value.ToString());
                    int soluongban = int.Parse(dgvHoaDonBanHang.Rows[i].Cells["SoLuong"].Value.ToString());
                    dgvHoaDonBanHang.Rows[i].Cells["ThanhTien"].Value = (dongiaban * soluongban).ToString("#,##");
                }

                txtMaHoaDon.Text = dgvDsHoaDonBanHang.CurrentRow.Cells["MaHoaDonBanHang"].Value.ToString();
                float money = 0;
                for (int i = 0; i < dgvHoaDonBanHang.Rows.Count; i++)
                {

                    money += float.Parse(dgvHoaDonBanHang["ThanhTien", i].Value.ToString());
                }
                txtTongTien.Text = money.ToString("#,##");
                txtTongCong.Text = dgvDsHoaDonBanHang.CurrentRow.Cells[5].Value.ToString();
                cbKhachHang.Text = dgvDsHoaDonBanHang.CurrentRow.Cells["TenKhachHang"].Value.ToString();
                txtThue.Text = dgvDsHoaDonBanHang.CurrentRow.Cells[4].Value.ToString();
                float thue = float.Parse(txtTongCong.Text);
                txtThanhToanTruoc.Text = float.Parse(dgvDsHoaDonBanHang.CurrentRow.Cells[6].Value.ToString()).ToString("#,##");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            FrmInHoaDonBanHang hd = new FrmInHoaDonBanHang();
            hd.pMaHoaDon = txtMaHoaDon.Text;
            hd.Show();
        }
    }
}
