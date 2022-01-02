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
    public partial class frmPhieuGiaoHang : Form
    {
        DALMatHang da_mh = new DALMatHang();
        DALKhachHang da_kh = new DALKhachHang();
        DALNhanVien da_nv = new DALNhanVien();
        DALLoaiMatHang da_loaimh = new DALLoaiMatHang();
        DALHoaDonBanHang da_hd = new DALHoaDonBanHang();
        DALChiTietHoaDonBanHang da_cthd = new DALChiTietHoaDonBanHang();
        public frmPhieuGiaoHang()
        {
            InitializeComponent();
        }
        public string pMaNhanVien { get; set; }
       
        private void frmLapHoaDonBanHang_Load(object sender, EventArgs e)
        {
            Load_LoaiMatHang();
            Load_KhachHang();
            Load_MatHang();
            ckInHoaDon.Checked = true;

        }
        void Load_KhachHang()
        {

            cbKhachHang.DataSource = da_kh.LoadData().Tables["KhachHang"];
            cbKhachHang.DisplayMember = "TenKhachHang";
            cbKhachHang.ValueMember = "MaKhachHang";
        }
        //load ds loai mat hang
        void Load_LoaiMatHang()
        {
            cbLoaiMatHang.DataSource = da_loaimh.LoadLoaiMatHang().Tables["LoaiMatHang"];
            cbLoaiMatHang.DisplayMember = "TenLoaiMatHang";
            cbLoaiMatHang.ValueMember = "MaLoaiMatHang";
        }
        //load ds mat hang
        void Load_MatHang()
        {
            dgvMatHang.DataSource = da_hd.Load_DsMatHang();
            for (int i = 0; i < dgvMatHang.Rows.Count; i++)
            {
                dgvMatHang.Rows[i].Cells[0].Value = i + 1;
            }

        }
        //tinh tong tien hoa don ban hang
        private void TinhTongTien()
        {
            float money = 0;
            for (int i = 0; i < dgvHoaDonBanHang.Rows.Count; i++)
            {
                money += float.Parse(dgvHoaDonBanHang["ThanhTien", i].Value.ToString().Replace(",", ""));
            }
            txtTongTien.Text = money.ToString("#,##");
            txtTongCong.Text = money.ToString("#,##");

        }
        //kiem tra ma da ton tai 
        private int KiemTraTonTai(string maHang)
        {
            for (int i = 0; i < dgvHoaDonBanHang.RowCount; i++)
            {
                string rMH = dgvHoaDonBanHang["MaMatHang", i].Value.ToString();
                if (rMH == maHang)
                    return i;
            }
            return -1;
        }

        //them vao hoa don ban hang
        private void them()
        {
           
            try
            {
                string mamh = dgvMatHang.CurrentRow.Cells["MaMatHangKho"].Value.ToString();
                string tenmh = dgvMatHang.CurrentRow.Cells["TenMatHangKho"].Value.ToString();

                float dongia = float.Parse(dgvMatHang.CurrentRow.Cells["DonGiaBanKho"].Value.ToString());
                string dvtinh = dgvMatHang.CurrentRow.Cells["DonViTinhKho"].Value.ToString();
                int slKho = int.Parse(dgvMatHang.CurrentRow.Cells["SoLuongKho"].Value.ToString());
                
                if (int.Parse(txtSoLuongBan.Text)<0)
                {
                    MessageBox.Show("Số Lượng Phải Lớn Hơn 0");
                    return;
                }
                int slban = int.Parse(txtSoLuongBan.Text);
                float thanhtien = dongia * slban;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvHoaDonBanHang);
                // Gan du lieu cho tung cot
                row.Cells[0].Value = dgvHoaDonBanHang.RowCount + 1;
                row.Cells[1].Value = mamh;
                row.Cells[2].Value = tenmh;
                row.Cells[4].Value = dongia.ToString("#,##"); ;
                row.Cells[3].Value = dvtinh;
                row.Cells[5].Value = slban;
                row.Cells[6].Value = thanhtien.ToString("#,##");
                //kiem tra mat hang xem co chua
                int kiemTra = KiemTraTonTai(mamh);
                if (slKho - slban < 0)
                {
                    MessageBox.Show("Số Lượng Mua Phải Nhỏ Hơn: " + slKho);
                    return;
                }
                
                if (kiemTra == -1)  //chua ton tai
                {
                    dgvHoaDonBanHang.Rows.Add(row); //Them hang vao Gridview
                    MessageBox.Show("Thêm Thành Công");
                }
                else
                {
                    MessageBox.Show("Mặt Hàng Đã Được Thêm ");
                }
                TinhTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
           
        }
        private void sua()
        {
            try
            {
                int slKho = int.Parse(dgvMatHang.CurrentRow.Cells["SoLuongKho"].Value.ToString());
                int slBan = int.Parse(dgvHoaDonBanHang.CurrentRow.Cells["SoLuong"].Value.ToString());
                int soluongban = int.Parse(txtSoLuongBan.Text);
                DataGridViewRow row = dgvHoaDonBanHang.Rows[rowIndex];
                row.Cells[1].Value = dgvHoaDonBanHang.CurrentRow.Cells["MaMatHang"].Value.ToString();
                row.Cells[2].Value = dgvHoaDonBanHang.CurrentRow.Cells["TenMatHang"].Value.ToString();
                float dongiaban = float.Parse(dgvHoaDonBanHang.CurrentRow.Cells["DonGia"].Value.ToString());
                row.Cells[4].Value = dongiaban.ToString().Replace(",", "");
                row.Cells[3].Value = dgvHoaDonBanHang.CurrentRow.Cells["DonViTinh"].Value.ToString();
                foreach (DataGridViewRow rowmh in dgvMatHang.Rows)
                {
                    string mamathangKh0 = rowmh.Cells["MaMatHangKho"].Value.ToString();
                    foreach (DataGridViewRow rowhd in dgvHoaDonBanHang.Rows)
                    {
                        string mamathangBan =  rowhd.Cells["MaMatHang"].Value.ToString();
                        if (mamathangKh0 == mamathangBan)
                        {
                            int soluongmathang = int.Parse(rowmh.Cells["SoLuongKho"].Value.ToString());
                            int slban = int.Parse(txtSoLuongBan.Text);
                            if (slban > soluongmathang)
                            {
                                MessageBox.Show("Số lượng bán phải <= " + soluongmathang);
                                return;
                            }
                        }
                    }
                }
                row.Cells[5].Value = soluongban;
                float thanhtien = dongiaban * soluongban;
                row.Cells[6].Value = thanhtien.ToString("#,##");
                MessageBox.Show("Sửa Thành Công");
                TinhTongTien();
            }
            catch
            {
                MessageBox.Show("Chưa Chọn Mặt Hàng Nào");
            }

        }
        private void CapNhaTSoLuongBan()
        {
            int slKho = int.Parse(dgvMatHang.CurrentRow.Cells["SoLuongKho"].Value.ToString());
            int soluongban = int.Parse(dgvHoaDonBanHang.CurrentRow.Cells["SoLuong"].Value.ToString());
            if (soluongban ==0)
            {
                MessageBox.Show("Số Lượng Lớn Hơn 0");
                return;
            }
            try
            {
                DataGridViewRow row = dgvHoaDonBanHang.Rows[rowIndex];
                row.Cells[1].Value = dgvHoaDonBanHang.CurrentRow.Cells["MaMatHang"].Value.ToString();
                row.Cells[2].Value = dgvHoaDonBanHang.CurrentRow.Cells["TenMatHang"].Value.ToString();
                float dongiaban = float.Parse(dgvHoaDonBanHang.CurrentRow.Cells["DonGia"].Value.ToString());
                row.Cells[4].Value = dongiaban.ToString().Replace(",", "");
                row.Cells[3].Value = dgvHoaDonBanHang.CurrentRow.Cells["DonViTinh"].Value.ToString();
                if (slKho - soluongban <= 0)
                {
                    MessageBox.Show("Số Lượng Mua Phải Nhỏ Hơn: " + slKho);
                    return;
                }
                foreach (DataGridViewRow rowmh in dgvMatHang.Rows)
                {
                    int soluongmathang = int.Parse(rowmh.Cells["SoLuongKho"].Value.ToString());
                    int slban = int.Parse(txtSoLuongBan.Text);
                    if (slban > soluongmathang)
                    {
                        MessageBox.Show("Số lượng bán phải <= " + soluongmathang);
                        return;
                    }
                }
                row.Cells[5].Value = soluongban;
                float thanhtien = dongiaban * soluongban;
                row.Cells[6].Value = thanhtien.ToString("#,##");
                MessageBox.Show("Sửa Thành Công");
                TinhTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        void xoa()
        {
            try
            {
                if (rowIndex != -1)
                {

                    if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa",
                        "Cảnh Báo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    dgvHoaDonBanHang.Rows.RemoveAt(rowIndex);
                    TinhTongTien();
                    for (int i = 0; i < dgvHoaDonBanHang.RowCount; i++)
                        dgvHoaDonBanHang["STT", i].Value = (i + 1).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Bạn Chưa Chọn Mặt Hàng Nào");
            }
        }
        private int rowIndex = 0;
        void ThemVaoCSDL()
        {
            string strTongTien = txtTongCong.Text.Replace(",", "");
            HoaDon them = new HoaDon();
            string mahd = txtMaHoaDon.Text;
            them.MaHoaDonBanHang =mahd;
            them.NgayBan = DateTime.Now;
            them.Thue = float.Parse(txtThue.Text);
            them.ThanhToan = float.Parse(txtThanhToanTruoc.Text);
            them.TongTien = float.Parse(strTongTien);
            them.MaKhachHang = cbKhachHang.SelectedValue.ToString();
            them.MaNhanVien = pMaNhanVien;
            if (da_hd.Them(them) == 1)
            {
              
            }
            else
            {
                MessageBox.Show("Thêm Thất bại");
                return;
            }
            foreach (DataGridViewRow rowmh in dgvMatHang.Rows)
            {
                string mamh = rowmh.Cells["MaMatHangKho"].Value.ToString();
                int soluongkho = int.Parse(rowmh.Cells["SoLuongKho"].Value.ToString());
                foreach (DataGridViewRow row in dgvHoaDonBanHang.Rows)
                {
                    //lay du lieu tung hang->insert vao CSDL
                    string mact = row.Cells["STT"].Value.ToString();
                    string maBan = row.Cells["MaMatHang"].Value.ToString();
                    int soLuongban = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    float donGia = Convert.ToInt32(row.Cells["DonGia"].Value.ToString().Replace(",", ""));
                    float thanhTien = Convert.ToInt32(row.Cells["ThanhTien"].Value.ToString().Replace(",", ""));
                    ChiTietHoaDonBanHang themct = new ChiTietHoaDonBanHang();
                    themct.MACHITIETHDBH = "CT" + mahd + mact;
                    themct.MaHoaDonBanHang = mahd;
                    themct.MaMatHang = maBan;
                    themct.SoLuongBan = soLuongban;
                    themct.DonGiaBan = donGia;
                    themct.ThanhTien = thanhTien;
                    if (mamh==maBan)
                    {
                        if (da_cthd.Them(themct) == 1)
                        {
                            if (da_mh.CapNhatSoLuong(maBan, soluongkho - soLuongban) == 1)
                            {
                                Load_MatHang();
                            }
                        }
                    }
                }
            }
            if (ckInHoaDon.Checked == true)
            {
                FrmInHoaDonBanHang hd = new FrmInHoaDonBanHang();
                hd.pMaHoaDon = mahd;
                hd.Show();
            }
            else
                MessageBox.Show("Dữ Liệu Đã Được Lưu");
           
           
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            them();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {
                if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa",
                    "Cảnh Báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                    return;
                dgvHoaDonBanHang.Rows.RemoveAt(rowIndex);
                TinhTongTien();
                for (int i = 0; i < dgvHoaDonBanHang.RowCount; i++)
                    dgvHoaDonBanHang["STT", i].Value = (i + 1).ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            sua();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoLuongBan_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập Số");
            }

        }

        private void dgvHoaDonBanHang_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)//hang tieu de
            {
                return;//ko lam gi 
            }
            rowIndex = e.RowIndex;
            DataGridViewRow row = dgvHoaDonBanHang.Rows[e.RowIndex];
            txtSoLuongBan.Text = row.Cells["SoLuong"].Value.ToString();
        }

        private void cbLoaiMatHang_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dgvMatHang.DataSource = da_mh.TimKiem_LoaiMatHang(cbLoaiMatHang.SelectedValue.ToString());
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            dgvMatHang.DataSource = da_mh.TimKiem_MatHang(txtTenMatHang.Text);
        }
        private void txtPhanTram_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập Số");
            }

        }

        private void txtThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập Số");
            }

        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            if (txtTongTien.Text == "")
            {
                return;
            }
            else
            {
                float strTongTien = float.Parse(txtTongTien.Text.Replace(",", ""));
                txtTongCong.Text = strTongTien.ToString();
            }

        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = da_hd.MaTuDong();
            them();
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            sua();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            xoa();
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.Show();
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void btnLapHD_Click(object sender, EventArgs e)
        {
            string strTongTien = txtTongCong.Text.Replace(",", "");
            if (txtTongTien.Text == string.Empty)
            {
                MessageBox.Show("Chưa Chọn Mặt Hàng Nào!");
                return;
            }
            float tongtien = float.Parse(strTongTien);
            if (float.Parse(txtThanhToanTruoc.Text.Replace(",", ""))>tongtien)
            {
                MessageBox.Show("Thanh Toán Phải Nhỏ Tổng Tiền");
                txtThanhToanTruoc.Focus();
                return;
            }
            if (tongtien == 0)
            {
                MessageBox.Show("Chưa Chọn Mặt Hàng Nào!");
            }
            else
            {
                ThemVaoCSDL();
                MessageBox.Show("Thanh Toán Thành Công !");
                dgvHoaDonBanHang.Rows.Clear();
                txtTongTien.Text = "0";
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Load_MatHang();
        }

        private void txtThue_TextChanged(object sender, EventArgs e)
        {
            float strTongTien = float.Parse(txtTongTien.Text.Replace(",", ""));
            if (txtThue.Text == string.Empty)
            {
                txtThue.Text = "0";
            }
            float thue = float.Parse(txtThue.Text);
            float thue_hd = (strTongTien * thue) / 100;
            txtTongCong.Text = (strTongTien + thue_hd).ToString("#,##");
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Load_KhachHang();
        }
     
        private void dgvDsHoaDonBanHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvMatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLapHD.Enabled = true;
            btnSua.Enabled = true;
            txtTongCong.Text  = txtMaHoaDon.Text = txtSoLuongBan.Text = "0";
            txtThue.Text = txtTongTien.Text = "0";
            dgvHoaDonBanHang.ClearSelection();

        }

        private void lblDSHD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDanhMucHoaDonBanHang dm = new frmDanhMucHoaDonBanHang();
            dm.Show();
        }

        private void txtThanhToanTruoc_TextChanged(object sender, EventArgs e)
        {

            try
            {

                float chuyendoi = float.Parse(txtThanhToanTruoc.Text.Replace(",", ""));
                txtThanhToanTruoc.Text = chuyendoi.ToString("0,00.##");
                txtThanhToanTruoc.Select(txtThanhToanTruoc.TextLength, 0);

            }
            catch 
            {

            }
        }
    }
}
