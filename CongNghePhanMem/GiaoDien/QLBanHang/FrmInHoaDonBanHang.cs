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
    public partial class FrmInHoaDonBanHang : Form
    {
        public FrmInHoaDonBanHang()
        {
            InitializeComponent();
        }
        public string pMaHoaDon { get; set; }
        private void FormHDBH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsHoaDonBanHang.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DsHoaDonBanHang.DataTable1,pMaHoaDon);
            
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
