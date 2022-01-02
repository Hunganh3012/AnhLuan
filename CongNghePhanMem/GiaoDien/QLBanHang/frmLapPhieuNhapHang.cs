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
    public partial class frmLapPhieuNhapHang : Form
    {
        DALMatHang da_mh = new DALMatHang();
        DALNhaCungCap da_ncc = new DALNhaCungCap();
        DALNhanVien da_nv = new DALNhanVien();
        DALChiTietPhieuNhapHang da_ct = new DALChiTietPhieuNhapHang();
        DALPhieuMuaHang da_pn = new DALPhieuMuaHang();
        DALPhieuNhapHang da_nk = new DALPhieuNhapHang();
        DALHoaDonBanHang da_hd = new DALHoaDonBanHang();
        DALChiTietPhieuMuaHang da_ctph = new DALChiTietPhieuMuaHang();
        public frmLapPhieuNhapHang()
        {
            InitializeComponent();
        }
        public string pMaNhanVien { get; set; }
        void Load_NhaCungCap()
        {
            cbNhaCungCap.DataSource = da_nk.TimKiemNhaCungCap(txtmaPhieuMuaHang.Text);
            cbNhaCungCap.DisplayMember = "TenNhaCungCap";//hien thi len cb nha cung cap
            cbNhaCungCap.ValueMember = "MaNhaCungCap";
        }
        private void btnPhieuNhapHang_Click(object sender, EventArgs e)
        {
            dgvPhieuNhapHang.Rows.Clear();
            if (txtmaPhieuMuaHang.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Nhập Mã Phiếu Nhập Hàng ");
                txtmaPhieuMuaHang.Focus(); return;
            }
            else
            {
                dgvMatHang.DataSource = da_nk.Load_DsMatHang_TheoPhieuMuaHang(txtmaPhieuMuaHang.Text);
                for (int i = 0; i < dgvMatHang.Rows.Count; i++)
                {
                    dgvMatHang.Rows[i].Cells[0].Value = i + 1;
                }
                Load_NhaCungCap();
            }

        }
        private int KiemTraTonTai(string maHang)
        {
            for (int i = 0; i < dgvPhieuNhapHang.RowCount; i++)
            {
                string rMH = dgvPhieuNhapHang["MaMatHang", i].Value.ToString();
                if (rMH == maHang)
                    return i;
            }
            return -1;
        }
        private void TinhTongTien()
        {
            float money = 0;
            for (int i = 0; i < dgvPhieuNhapHang.Rows.Count; i++)
            {
                money += float.Parse(dgvPhieuNhapHang["ThanhTien", i].Value.ToString());
            }
            txtTongTien.Text = money.ToString("#,##");

        }
        private void them()
        {
            
            try
            {
                
                string mamh = dgvMatHang.CurrentRow.Cells["MaMatHangNhap"].Value.ToString();
                string tenmh = dgvMatHang.CurrentRow.Cells["TenMatHangNhap"].Value.ToString();

                float dongia = float.Parse(dgvMatHang.CurrentRow.Cells["DonGiaNhap"].Value.ToString());
                string dvtinh = dgvMatHang.CurrentRow.Cells["DonViTinhNhap"].Value.ToString();
                int slKho = int.Parse(dgvMatHang.CurrentRow.Cells["SoLuongMua"].Value.ToString());
                if (txtSoLuongNhap.Text == "0")
                {
                    MessageBox.Show("Số Lượng Phải Lớn Hơn 0");
                    return;
                }
                int slban = int.Parse(txtSoLuongNhap.Text);
                float thanhtien = dongia * slban;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvPhieuNhapHang);
                // Gan du lieu cho tung cot
                row.Cells[0].Value = dgvPhieuNhapHang.RowCount + 1;
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
                    MessageBox.Show("Số Lượng Phải Nhỏ Hơn: " + slKho);
                    return;
                }

                if (kiemTra == -1)  //chua ton tai
                {
                    dgvPhieuNhapHang.Rows.Add(row); //Them hang vao Gridview
                    MessageBox.Show("Thêm Thành Công");
                }
                else
                {
                    MessageBox.Show("Mặt Hàng Đã Được Thêm ");
                }
                TinhTongTien();
            }
            catch 
            {
                MessageBox.Show("Bạn Chưa Chọn Mặt Hàng Nào");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPhieuNhapHang.Text = da_nk.MaTuDong();
            them();
            
        }

        private void frmLapPhieuNhapKho_Load(object sender, EventArgs e)
        {
            Load_MatHang();
            txtmaPhieuMuaHang.Focus();
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtmaPhieuMuaHang.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Nhập Mã Phiếu mua Hàng");
                txtmaPhieuMuaHang.Focus();
                return;
            }
            if (txtTenMatHang.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Nhập Tên Mặt Hàng");
                txtTenMatHang.Focus();
                return;
            }
            dgvMatHang.DataSource = da_nk.TimKiemMatHang(txtmaPhieuMuaHang.Text, txtTenMatHang.Text);
            for (int i = 0; i < dgvMatHang.Rows.Count; i++)
            {
                dgvMatHang.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void txtTenMatHang_TextChanged(object sender, EventArgs e)
        {
            if (txtTenMatHang.Text ==null)
            {
                dgvMatHang.DataSource = da_nk.Load_DsMatHang_TheoPhieuMuaHang(txtmaPhieuMuaHang.Text);
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {
                dgvMatHang.DataSource = da_nk.Load_DsMatHang_TheoPhieuMuaHang(txtmaPhieuMuaHang.Text);
                for (int i = 0; i < dgvMatHang.Rows.Count; i++)
                {
                    dgvMatHang.Rows[i].Cells[0].Value = i + 1;
                }
            }
            catch
            {
                return; 
            }
        }
        private int rowIndex = 0;
        private void sua()
        {
            try
            {
                if (txtSoLuongNhap.Text == string.Empty || txtSoLuongNhap.Text == "0")
                {
                    MessageBox.Show("Cần Nhập Số Lượng");
                    return;
                }
                DataGridViewRow rows = dgvPhieuNhapHang.Rows[rowIndex];
                string ma = dgvPhieuNhapHang.CurrentRow.Cells["MaMatHang"].Value.ToString();
                string ten = dgvPhieuNhapHang.CurrentRow.Cells["TenMatHang"].Value.ToString();
                string dongia = dgvPhieuNhapHang.CurrentRow.Cells["DonGia"].Value.ToString();
                string dvi = dgvPhieuNhapHang.CurrentRow.Cells["DonViTinh"].Value.ToString();
                int soluongnhap = int.Parse(txtSoLuongNhap.Text);
                float dongianhap = float.Parse(dgvPhieuNhapHang.CurrentRow.Cells["DonGia"].Value.ToString());
                float thanhtien = dongianhap * soluongnhap;
                foreach (DataGridViewRow rowmh in dgvMatHang.Rows)
                {
                    string mamathangKh0 = rowmh.Cells["MaMatHangNhap"].Value.ToString();
                    foreach (DataGridViewRow rowhd in dgvPhieuNhapHang.Rows)
                    {
                        string mamathangBan = rowhd.Cells["MaMatHang"].Value.ToString();
                        if (mamathangKh0 == mamathangBan)
                        {
                            int soluongmathang = int.Parse(rowmh.Cells["SoLuongMua"].Value.ToString());
                            int slban = int.Parse(txtSoLuongNhap.Text);
                            if (slban > soluongmathang)
                            {
                                MessageBox.Show("Số lượng Nhập phải <= " + soluongmathang);
                                return;
                            }
                        }
                    }
                }
                rows.Cells[1].Value = ma;
                rows.Cells[2].Value = ten;
                rows.Cells[3].Value = dvi;
                rows.Cells[4].Value = dongia;
                rows.Cells[5].Value = soluongnhap;
                rows.Cells[6].Value = thanhtien;
                MessageBox.Show("Sửa Thành Công");
                TinhTongTien();
            }
            catch
            {
                MessageBox.Show("Chưa Chọn Mặt Hàng Nào");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            sua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
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
                    dgvPhieuNhapHang.Rows.RemoveAt(rowIndex);
                    TinhTongTien();
                    for (int i = 0; i < dgvPhieuNhapHang.RowCount; i++)
                        dgvPhieuNhapHang["STT", i].Value = (i + 1).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Chưa Chọn Mặt Hàng Nào");
            }
        }
        void Load_MatHang()
        {
            dgvMatHangKho.DataSource = da_nk.Load_DsKhoHang();
            for (int i = 0; i < dgvMatHangKho.Rows.Count; i++)
            {
                dgvMatHangKho.Rows[i].Cells[0].Value = i + 1;
            }
        }
        void ThemVaoCSDL()
        {
            string strTongTien = txtTongTien.Text.Replace(",", "");
            PhieuNhapHang them = new PhieuNhapHang();
            them.MaPhieuNhapHang = txtMaPhieuNhapHang.Text;
            them.NgayNhapHang = DateTime.Now;
            them.TongTien = float.Parse(txtTongTien.Text);
            them.ThanhToan = float.Parse(txtThanhToanTruoc.Text);
            them.TongTien = float.Parse(strTongTien);
            them.MaNhanVien = pMaNhanVien;
            them.LanNhap = int.Parse(txtLanGiao.Text);
            them.GhiChu = txtGhiChu.Text;
            if (da_nk.Them(them) == 1)
            {

            }
            else
            {
                MessageBox.Show("Thêm Thất bại");
                return;
            }
            foreach (DataGridViewRow rowmh in dgvMatHangKho.Rows)
            {
                string mamh = rowmh.Cells["MaMatHangKho"].Value.ToString();
                int soluongkho = int.Parse(rowmh.Cells["SoLuongKho"].Value.ToString());
                foreach (DataGridViewRow row in dgvPhieuNhapHang.Rows)
                {
                    
                    //lay du lieu tung hang->insert vao CSDL
                    string mactpnk = row.Cells["STT"].Value.ToString();
                    string manhap = row.Cells["MaMatHang"].Value.ToString();
                    int soLuongnhapKho = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    float donGia = Convert.ToInt32(row.Cells["DonGia"].Value.ToString().Replace(",", ""));
                    float thanhTien = Convert.ToInt32(row.Cells["ThanhTien"].Value.ToString().Replace(",", ""));
                   
                    if (mamh == manhap)
                    {
                        foreach (DataGridViewRow rowkh in dgvMatHang.Rows)
                        {
                            string mact = rowkh.Cells["MaChiTietPMH"].Value.ToString();
                            string makho = rowkh.Cells["MaMatHangNhap"].Value.ToString();
                            int soluongNhapHang = Convert.ToInt32(rowkh.Cells["SoLuongMua"].Value);
                            if (makho == mamh)
                            {
                                string ct= row.Cells["STT"].Value.ToString();
                                ChiTietPhieuNhapHang themct = new ChiTietPhieuNhapHang();
                                themct.MaPhieuNhapHang = txtMaPhieuNhapHang.Text;
                                themct.MaChiTietPMH = mact;
                                themct.SoLuongNhap = soLuongnhapKho;
                                themct.MaChiTietPNH = "CT" + txtMaPhieuNhapHang.Text+ct;
                                if (da_ct.Them(themct) == 1)
                                {
                                    if (da_mh.CapNhatSoLuong(manhap, soluongkho + soLuongnhapKho) == 1)
                                    {
                                        ChiTietPhieuMuaHang capnhap = new ChiTietPhieuMuaHang();
                                        capnhap.MaPhieuMuaHang = txtmaPhieuMuaHang.Text;
                                        capnhap.MaMatHang = manhap;
                                        capnhap.SoLuongMua = soluongNhapHang - soLuongnhapKho;
                                        capnhap.MaCHiTietPMH = mact;
                                        if (da_ctph.CapNhatSoLuongNhapHang(mact, soluongNhapHang - soLuongnhapKho) == 1)
                                        {

                                        }
                                        Load_MatHang(); 
                                    }
                                }
                            }
                        }
                        
                    }
                }
            }
            if (ckInPhieu.Checked == true)
            {
                dgvMatHang.DataSource = da_nk.Load_DsMatHang_TheoPhieuMuaHang(txtmaPhieuMuaHang.Text);
                for (int i = 0; i < dgvMatHang.Rows.Count; i++)
                {
                    dgvMatHang.Rows[i].Cells[0].Value = i + 1;
                }
                frmInPhieuNhapHang hd = new frmInPhieuNhapHang();
                hd.pMaPhieuNhapHang = txtMaPhieuNhapHang.Text;
                hd.Show();

            }
            else
            {
                MessageBox.Show("Dữ Liệu Đã Được Lưu");
                dgvMatHang.DataSource = da_nk.Load_DsMatHang_TheoPhieuMuaHang(txtmaPhieuMuaHang.Text);
                for (int i = 0; i < dgvMatHang.Rows.Count; i++)
                {
                    dgvMatHang.Rows[i].Cells[0].Value = i + 1;
                }
            }

        }
        private void btnLapHD_Click(object sender, EventArgs e)
        {
            string strTongTien = txtTongTien.Text.Replace(",", "");
            if (txtTongTien.Text == string.Empty)
            {
                MessageBox.Show("Chưa Chọn Mặt Hàng Nào!");
                return;
            }
            if (txtLanGiao.Text == string.Empty)
            {
                MessageBox.Show("Bạn Cần Nhập Lần Giao");
                txtLanGiao.Focus();
                return;
            }
            float tongtien = float.Parse(strTongTien);
            if (tongtien == 0)
            {
                MessageBox.Show("Chưa Chọn Mặt Hàng Nào!");
                return;
            }
            else
            {
                ThemVaoCSDL();

                dgvPhieuNhapHang.Rows.Clear();
                txtTongTien.Text = "0";
            }
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

        private void txtLanGiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập Số");
            }
        }
    }
}
