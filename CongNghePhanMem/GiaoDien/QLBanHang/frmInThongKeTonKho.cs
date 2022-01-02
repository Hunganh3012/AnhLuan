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
    public partial class frmInThongKeTonKho : Form
    {
        public frmInThongKeTonKho()
        {
            InitializeComponent();
        }

        private void frmInThongKeTonKho_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsThongKeTonKho.dsTonKho' table. You can move, or remove it, as needed.
            this.dsTonKhoTableAdapter.Fill(this.DsThongKeTonKho.dsTonKho);

            this.reportViewer1.RefreshReport();
        }
    }
}
