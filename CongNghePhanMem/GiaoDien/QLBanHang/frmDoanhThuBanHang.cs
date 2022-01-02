using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNhaSach
{
    public partial class frmDoanhThuBanHang : Form
    {
        public frmDoanhThuBanHang()
        {
            InitializeComponent();
        }

        private void frmDoanhThuBanHang_Load(object sender, EventArgs e)
        {
        
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.DoanhThu_BaCaoTableAdapter.Fill(this.DsDoanhThuTheoThang.DoanhThu_BaCao, dpkTuNgay.Value, dpkDenNgay.Value);
            this.reportViewer1.RefreshReport();

        }
    }
}
