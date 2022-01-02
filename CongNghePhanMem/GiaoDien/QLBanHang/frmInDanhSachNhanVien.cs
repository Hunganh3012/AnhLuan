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
    public partial class frmInDanhSachNhanVien : Form
    {
        public frmInDanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void XuatDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSNhanVien.DanhSachNhanVien' table. You can move, or remove it, as needed.
            this.DanhSachNhanVienTableAdapter.Fill(this.DSNhanVien.DanhSachNhanVien);

            this.reportViewer1.RefreshReport();
        }
    }
}
