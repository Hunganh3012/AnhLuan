using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
using QLNhaSach.XuLy;
namespace QLNhaSach
{
    public partial class frmChinh : Office2007RibbonForm
    {
        public frmChinh()
        {
            InitializeComponent();
        }
        //------------------Add new tab---------------
        private void addNewTab(string strTabName, UserControl ucContent)
        {
            //-----------If exist tabpage then exit---------------
            foreach (TabItem tabPage in tabContent.Tabs)
                if (tabPage.Text == strTabName)
                {
                    tabContent.SelectedTab = tabPage;
                    return;
                }
            TabControlPanel newTabPanel = new DevComponents.DotNetBar.TabControlPanel();
            TabItem newTabPage = new TabItem(this.components);
            newTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            newTabPanel.Location = new System.Drawing.Point(0, 26);
            newTabPanel.Name = "panel" + strTabName;
            newTabPanel.Padding = new System.Windows.Forms.Padding(1);
            newTabPanel.Size = new System.Drawing.Size(1230, 384);
            newTabPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            newTabPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            newTabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            newTabPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            newTabPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            newTabPanel.Style.GradientAngle = 90;
            newTabPanel.TabIndex = 2;
            newTabPanel.TabItem = newTabPage;
            //-------------New  tab page---------------------
            Random ran = new Random();
            newTabPage.Name = strTabName + ran.Next(100000) + ran.Next(22342);
            newTabPage.AttachedControl = newTabPanel;
            newTabPage.Text = strTabName;
            ucContent.Dock = DockStyle.Fill;
            newTabPanel.Controls.Add(ucContent);
            //------------add Tab page to Tab control-------------
            tabContent.Controls.Add(newTabPanel);
            tabContent.Tabs.Add(newTabPage);
            tabContent.SelectedTab = newTabPage;
        }
        public string pQuyen { get; set; }
        public string pTenDagNhap { get; set; }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            nv.Show();
        }
        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            frmNhaCungCap ncc = new frmNhaCungCap();
            ncc.Show();
        }
        private void btnThayDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau mk = new frmDoiMatKhau();
            mk.pTenDangNhap = pTenDagNhap;
            mk.Show();
        }
        private void btnLapHoaDonBanHang_Click(object sender, EventArgs e)
        {
            frmPhieuGiaoHang lap = new frmPhieuGiaoHang();
            lap.pMaNhanVien = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            lap.Show();
        }

        private void btnLapPhieuNhapHang_Click(object sender, EventArgs e)
        {
            frmLapPhieuMuaHang ph = new frmLapPhieuMuaHang();
            ph.pMaNhanVien = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            ph.Show();
        }
        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            UCTroGiup ucTroGiup = new UCTroGiup();
            addNewTab("Trợ Giúp", ucTroGiup);
        }

        private void tabContent_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            if (MessageBox.Show("Bạn Thật Sự Muốn Xoá", "Cảnh Báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (tabContent.SelectedTab != null)
                    tabContent.Tabs.Remove(tabContent.SelectedTab);
            }
        }

        private void FormChinh_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult r;
            r = MessageBox.Show("Bạn Thật Sự Muốn Đóng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
        void HienThiNhanVien()
        {
            
            dgvNhanVien.DataSource = dal_phanquyen.Tim_NhanVien(pTenDagNhap);
            lblNhanVien.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            string pMaNhanVien = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            cbMaNhom.DataSource = dal_phanquyen.TimMaNhom_TheoTenDangNhap(pTenDagNhap);
            cbMaNhom.DisplayMember = "MaNhom";
            cbMaNhom.ValueMember = "MaNhom";
        }
        DALPhanQuyenNguoiDung dal_phanquyen = new DALPhanQuyenNguoiDung();
        private void frmChinh_Load(object sender, EventArgs e)
        {
            HienThiNhanVien();
            cbMaNhom.Text = cbMaNhom.SelectedValue.ToString();
            {
                if (cbMaNhom.Text == "MN01")
                {

                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH02", "true") == false)
                    {
                        ribCNHoaDonBanHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH03", "true") == false)
                    {
                        riPhieuGiaoHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH04", "true") == false)
                    {
                        ribLapPhieuNhapHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH05", "true") == false)
                    {
                        riPhieuNhapKho.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH01", "true") == false)
                    {
                        ribKhachHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH10", "true") == false)
                    {
                        ribLoaiMatHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH11", "true") == false)
                    {
                        ribMatHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH06", "true") == false)
                    {
                        ribNhanVien.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH09", "true") == false)
                    {
                        ribNhaCungCap.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH12", "true") == false)
                    {
                        ribGiaBan.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH13", "true") == false)
                    {
                        ribDoanhThu.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH14", "true") == false)
                    {
                        ribTonKho.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH08", "true") == false)
                    {
                        ribNguoiDung.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH07", "true") == false)
                    {
                        ribPhanQuyen.Visible = false;
                    }
                }
                if (cbMaNhom.Text == "MN02")
                {
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH02", "true") == false)
                    {
                        ribCNHoaDonBanHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH03", "true") == false)
                    {
                        riPhieuGiaoHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH04", "true") == false)
                    {
                        ribLapPhieuNhapHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH05", "true") == false)
                    {
                        riPhieuNhapKho.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH01", "true") == false)
                    {
                        ribKhachHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH10", "true") == false)
                    {
                        ribLoaiMatHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH11", "true") == false)
                    {
                        ribMatHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH06", "true") == false)
                    {
                        ribNhanVien.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH09", "true") == false)
                    {
                        ribNhaCungCap.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH12", "true") == false)
                    {
                        ribGiaBan.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH13", "true") == false)
                    {
                        ribDoanhThu.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH14", "true") == false)
                    {
                        ribTonKho.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH08", "true") == false)
                    {
                        ribNguoiDung.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH07", "true") == false)
                    {
                        ribPhanQuyen.Visible = false;
                    }
                }
                if (cbMaNhom.Text == "MN03")
                {
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH02", "true") == false)
                    {
                        ribCNHoaDonBanHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH03", "true") == false)
                    {
                        riPhieuGiaoHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH04", "true") == false)
                    {
                        ribLapPhieuNhapHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH05", "true") == false)
                    {
                        riPhieuNhapKho.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH01", "true") == false)
                    {
                        ribKhachHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH10", "true") == false)
                    {
                        ribLoaiMatHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH11", "true") == false)
                    {
                        ribMatHang.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH06", "true") == false)
                    {
                        ribNhanVien.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH09", "true") == false)
                    {
                        ribNhaCungCap.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH12", "true") == false)
                    {
                        ribGiaBan.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH13", "true") == false)
                    {
                        ribDoanhThu.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH14", "true") == false)
                    {
                        ribTonKho.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH08", "true") == false)
                    {
                        ribNguoiDung.Visible = false;
                    }
                    if (dal_phanquyen.QuyenDangNhap(cbMaNhom.Text, "MH07", "true") == false)
                    {
                        ribPhanQuyen.Visible = false;
                    }
                }
            }
           
        }
        private void btnMatHang_Click(object sender, EventArgs e)
        {
            frmMatHang mh = new frmMatHang();
            mh.Show();
        }

        private void btnLoaiMatHang_Click(object sender, EventArgs e)
        {
            frmLoaiMatHang loai = new frmLoaiMatHang();
            loai.Show();
        }

        private void btnNNHaCungCap_Click_1(object sender, EventArgs e)
        {
            frmNhaCungCap nha = new frmNhaCungCap();
            nha.Show();
        }
        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            frmDoanhThuBanHang dto = new frmDoanhThuBanHang();
            dto.Show();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Click(object sender, EventArgs e)
        {

        }

        private void ribKhachHang_ItemClick(object sender, EventArgs e)
        {

        }

        private void btnKhachHang0_Click(object sender, EventArgs e)
        {
            frmKhachHang dtos = new frmKhachHang();
            dtos.Show();
        }

        private void btnGiaBan_Click(object sender, EventArgs e)
        {
            frmCapNhatGiaBan cngb = new frmCapNhatGiaBan();
            cngb.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblTimer.Text = dt.ToString();
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            frmPhanQuyenNguoiDung pg = new frmPhanQuyenNguoiDung();
            pg.Show();
        }

        private void btnNguoiDung_ItemClick(object sender, EventArgs e)
        {
            frmNguoiDung nd = new frmNguoiDung();
            nd.Show();
        }

        private void ribCNHoaDonBanHang_ItemClick(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnPhieuNhapKho_Click(object sender, EventArgs e)
        {
            frmLapPhieuNhapHang s = new frmLapPhieuNhapHang();
            s.pMaNhanVien = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            s.Show();
        }

        private void ribDanhMuc_Click(object sender, EventArgs e)
        {

        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            frmInThongKeTonKho ds = new frmInThongKeTonKho();
            ds.Show();
        }

        private void ribTonKho_ItemClick(object sender, EventArgs e)
        {

        }
    }
}
