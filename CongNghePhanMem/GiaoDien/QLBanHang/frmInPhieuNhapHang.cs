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
    public partial class frmInPhieuNhapHang : Form
    {
        public frmInPhieuNhapHang()
        {
            InitializeComponent();
        }
        public string pMaPhieuNhapHang { get; set; }

        private void frmInPhieuNhapHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsPhieuNhapHang.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DsPhieuNhapHang.DataTable1,pMaPhieuNhapHang);

            this.reportViewer1.RefreshReport();
        }
    }
}
