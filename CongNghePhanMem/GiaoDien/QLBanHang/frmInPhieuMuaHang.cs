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
    public partial class frmInPhieuMuaHang : Form
    {
        public frmInPhieuMuaHang()
        {
            InitializeComponent();
        }
        public string pMaPhieuMua { get; set; }

        private void frmInPhieuMuaHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DasetPhieuNhapHang.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DasetPhieuNhapHang.DataTable1,pMaPhieuMua);

            this.reportViewer1.RefreshReport();
        }
    }
}
