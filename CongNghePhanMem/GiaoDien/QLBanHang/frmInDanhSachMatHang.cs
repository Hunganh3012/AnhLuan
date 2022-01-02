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
    public partial class frmInDanhSachMatHang : Form
    {
        public frmInDanhSachMatHang()
        {
            InitializeComponent();
        }

        private void InDanhSachMatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsMatHang.InDsMatHang' table. You can move, or remove it, as needed.
            this.InDsMatHangTableAdapter.Fill(this.DsMatHang.InDsMatHang);

            this.reportViewer1.RefreshReport();
        }
    }
}
