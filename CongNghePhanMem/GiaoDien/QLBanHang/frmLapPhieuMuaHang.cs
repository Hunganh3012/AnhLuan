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
    public partial class frmLapPhieuMuaHang : Form
    {
        DALMatHang da_mh = new DALMatHang();
        DALNhaCungCap da_ncc = new DALNhaCungCap();
        DALNhanVien da_nv = new DALNhanVien();
        DALLoaiMatHang da_loaimh = new DALLoaiMatHang();
        DALChiTietPhieuMuaHang da_ct = new DALChiTietPhieuMuaHang();
        DALPhieuMuaHang da_pn = new DALPhieuMuaHang();
        public frmLapPhieuMuaHang()
        {
            InitializeComponent();
        }
        public string pMaNhanVien { get; set; }
        private void frmLapPhieuNhapHang_Load(object sender, EventArgs e)
        {
            Load_NhaCungCap();
            Load_LoaiMatHang();
            Load_MatHang();
        }
        void Load_NhaCungCap()
        {
            cbNhaCungCap.DataSource = da_ncc.LoadData().Tables["NhaCungCap"];
            cbNhaCungCap.DisplayMember = "TenNhaCungCap";
            cbNhaCungCap.ValueMember = "MaNhaCungCap";
        }
        void Load_LoaiMatHang()
        {
            cbLoaiMatHang.DataSource = da_loaimh.LoadLoaiMatHang().Tables["LoaiMatHang"];
            cbLoaiMatHang.DisplayMember = "TenLoaiMatHang";
            cbLoaiMatHang.ValueMember = "MaLoaiMatHang";
        }
        //load ds mat hang
        void Load_MatHang()
        {
            dgvMatHang.DataSource = da_pn.Load_DSMatHang().Tables["MatHang"];
        }
        //tinh tong tien hoa don ban hang
        private void TinhTongTien()
        {
            int money = 0;
            for (int i = 0; i < dgvPhieuNhapHang.Rows.Count; i++)
            {
                money += Convert.ToInt32(dgvPhieuNhapHang["ThanhTien", i].Value);
            }
            txtTongTien.Text = money.ToString("#,##");

        }
        //kiem tra ma da ton tai 
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
        void them()
        {
            try
            {
                string mamh = dgvMatHang.CurrentRow.Cells["MaMatHangKho"].Value.ToString();
                string tenmh = dgvMatHang.CurrentRow.Cells["TenMatHangKho"].Value.ToString();

                string dvtinh = dgvMatHang.CurrentRow.Cells["DonViTinhKho"].Value.ToString();
                int slKho = int.Parse(dgvMatHang.CurrentRow.Cells["SoLuongKho"].Value.ToString());
                if (txtSoLuongNhap.Text == string.Empty || txtSoLuongNhap.Text == "0")
                {
                    MessageBox.Show("Cần Nhập Số Lượng");
                    return;
                }
                if (txtDonGiaNhap.Text == string.Empty )
                {
                    MessageBox.Show("Cần Nhập Đơn Giá Nhập");
                    return;
                }
                if (float.Parse(txtDonGiaNhap.Text)<=0)
                {
                    MessageBox.Show("Đơn Giá Lớn Hơn 0");
                    return;
                }
                float dongia = float.Parse(txtDonGiaNhap.Text);
                int slnhap = int.Parse(txtSoLuongNhap.Text);
                float thanhtien =(dongia * slnhap);
                
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvPhieuNhapHang);
                // Gan du lieu cho tung cot
                row.Cells[0].Value = dgvPhieuNhapHang.RowCount + 1;
                row.Cells[1].Value = mamh;
                row.Cells[2].Value = tenmh;
                row.Cells[3].Value = dvtinh;
                row.Cells[4].Value = dongia;
                row.Cells[5].Value = slnhap;
                row.Cells[6].Value = thanhtien;
                //kiem tra mat hang xem co chua
                int kiemTra = KiemTraTonTai(mamh);
                if (kiemTra == -1)  //chua ton tai
                {
                    dgvPhieuNhapHang.Rows.Add(row); //Them hang vao Gridview
                    MessageBox.Show("Thêm Thành Công");
                    txtDonGiaNhap.Text = "0";
                    txtSoLuongNhap.Text = "1";
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
        private int rowIndex = 0;
        private void sua()
        {
            try
            {
                int slKho = int.Parse(dgvMatHang.CurrentRow.Cells["SoLuongKho"].Value.ToString());
                if (txtSoLuongNhap.Text == string.Empty || txtSoLuongNhap.Text == "0")
                {
                    MessageBox.Show("Cần Nhập Số Lượng");
                    return;
                }
                if (txtDonGiaNhap.Text == string.Empty)
                {
                    MessageBox.Show("Cần Nhập Đơn Giá Nhập");
                    return;
                }
                if (float.Parse(txtDonGiaNhap.Text) <= 0)
                {
                    MessageBox.Show("Đơn Giá Lớn Hơn 0");
                    return;
                }
                int soluongnhap = int.Parse(txtSoLuongNhap.Text);
                float dongiaban = float.Parse(txtDonGiaNhap.Text);
                float thanhtien = (dongiaban * soluongnhap);

                DataGridViewRow row = dgvPhieuNhapHang.Rows[rowIndex];
                row.Cells[1].Value = dgvPhieuNhapHang.CurrentRow.Cells[1].Value.ToString();
                row.Cells[2].Value = dgvPhieuNhapHang.CurrentRow.Cells[2].Value.ToString();
                row.Cells[4].Value = dongiaban;
                row.Cells[3].Value = dgvPhieuNhapHang.CurrentRow.Cells[3].Value.ToString();
                row.Cells[5].Value = soluongnhap;
                row.Cells[6].Value = thanhtien;
                MessageBox.Show("Sửa Thành Công");
                TinhTongTien();
            }
            catch
            {
                MessageBox.Show("Chưa Chọn Mặt Hàng Nào");
            }
        }

        public object soluongnhap { get; set; }
        void ThemVaoCSDL()
        {

            string strTongTien = txtTongTien.Text.Replace(",", "");
            PhieuMuaHang them = new PhieuMuaHang();
            them.MaPhieuMuaHang = txtMaPhieuNhapKho.Text;
            them.NgayDatMua = DateTime.Now;
            them.NgayNhapHang = dpkNgayNhapHang.Value;
            them.TongTien = float.Parse(strTongTien);
            them.MaNhaCungCap = cbNhaCungCap.SelectedValue.ToString();
            them.MaNhanVien = pMaNhanVien;
            them.ThanhToan = float.Parse(txtThanhToanTruoc.Text);
            them.GhiChu = txtGhiChu.Text;
            if (da_pn.Them(them) == 1)
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
                foreach (DataGridViewRow row in dgvPhieuNhapHang.Rows)
                {
                    //lay du lieu tung hang->insert vao CSDL
                    string mact = row.Cells["STT"].Value.ToString();
                    string maBan = row.Cells["MaMatHang"].Value.ToString();
                    int soluongnhap = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    float donGia = Convert.ToInt32(row.Cells["DonGia"].Value);
                    float thanhTien = Convert.ToInt32(row.Cells["ThanhTien"].Value);
                    ChiTietPhieuMuaHang themct = new ChiTietPhieuMuaHang();
                    themct.MaCHiTietPMH = "CT" + txtMaPhieuNhapKho.Text + mact;
                    themct.MaPhieuMuaHang = txtMaPhieuNhapKho.Text;
                    themct.MaMatHang = maBan;
                    themct.SoLuongMua = soluongnhap;
                    themct.DonGiaNhap = donGia;
                    themct.ThanhTien = thanhTien;
                    Load_MatHang();
                }
            }
            if (ckInPhieu.Checked == true)
            {
                frmInPhieuMuaHang hd = new frmInPhieuMuaHang();
                hd.pMaPhieuMua = txtMaPhieuNhapKho.Text;
                hd.Show();
            }
            else
            {
                MessageBox.Show("Dữ Liệu Đã Được Lưu");
            }
        }
        private void btnLapHD_Click_1(object sender, EventArgs e)
        {
            string strTongTien = txtTongTien.Text.Replace(",", "");
            if (txtTongTien.Text == string.Empty)
            {
                MessageBox.Show("Chưa Chọn Mặt Hàng Nào!");
                return;

            }
            float tongtien = float.Parse(strTongTien);
            if (float.Parse(txtThanhToanTruoc.Text.Replace(",", "")) > tongtien)
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
                dgvPhieuNhapHang.Rows.Clear();
                txtTongTien.Text = "0";
                txtSoLuongNhap.Text = "0";
                txtDonGiaNhap.Text = "0";
            }
        }

        private void dgvPhieuNhapHang_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)//hang tieu de
            {
                btnSua.Enabled = btnXoa.Enabled = false;
                return;//ko lam gi 
            }
            rowIndex = e.RowIndex;
            btnSua.Enabled = btnXoa.Enabled = true;
            DataGridViewRow row = dgvPhieuNhapHang.Rows[e.RowIndex];
            txtSoLuongNhap.Text = row.Cells["SoLuong"].Value.ToString();
            txtDonGiaNhap.Text = row.Cells["DonGia"].Value.ToString();
        }

        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập Số");
            }
        }

        private void txtSoLuongNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập Số");
            }
        }
        private void cbLoaiMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMatHang.DataSource = da_pn.TimKiem_LoaiMatHang(cbLoaiMatHang.SelectedValue.ToString());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvMatHang.DataSource = da_pn.TimKiem_MatHang(txtTenMatHang.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPhieuNhapKho.Text = da_pn.MaTuDong();
            them();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            sua();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
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

        private void txtDonGiaNhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                float chuyendoi = float.Parse(txtDonGiaNhap.Text.Replace(",",""));
                txtDonGiaNhap.Text = chuyendoi.ToString("0,00.##");
                txtDonGiaNhap.Select(txtDonGiaNhap.TextLength, 0);

            }
            catch
            {
 
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
        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDonGiaNhap.Text = "0";
            txtSoLuongNhap.Text = "1";
        }
    }
}
