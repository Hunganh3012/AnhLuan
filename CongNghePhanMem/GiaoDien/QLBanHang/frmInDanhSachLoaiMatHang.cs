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
    public partial class frmInDanhSachLoaiMatHang : Form
    {
        public frmInDanhSachLoaiMatHang()
        {
            InitializeComponent();
        }

        private void frmInDanhSachLoaiMatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsLoaiMatHang.LOAIMATHANG' table. You can move, or remove it, as needed.
            this.LOAIMATHANGTableAdapter.Fill(this.DsLoaiMatHang.LOAIMATHANG);

            this.reportViewer1.RefreshReport();
        }
    }
}
