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
    public partial class frmPhanQuyenNguoiDung : Form
    {
        DALPhanQuyenNguoiDung dl = new DALPhanQuyenNguoiDung();
        public frmPhanQuyenNguoiDung()
        {
            InitializeComponent();
        }

        private void frmPhanQuyenNguoiDung_Load(object sender, EventArgs e)
        {
            Load_data_NhomNguoiDung();
        }
        void Load_data_NhomNguoiDung()
        {
            dgvNhomNguoiDung.DataSource = dl.Load_Data_NhomNguoiDung().Tables["NhomNguoiDung"];
            for (int i = 0; i < dgvNhomNguoiDung.Rows.Count; i++)
            {
                dgvNhomNguoiDung.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dgvNhomNguoiDung_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhomNguoiDung.CurrentRow != null)
            {
                string manhom = dgvNhomNguoiDung.CurrentRow.Cells[1].Value.ToString();
                dgvPhanQuyenNguoiDung.DataSource = dl.TimKiemTheoMaNhom(manhom);
                for (int i = 0; i < dgvPhanQuyenNguoiDung.Rows.Count; i++)
                {
                    dgvPhanQuyenNguoiDung.Rows[i].Cells[0].Value = i + 1;
                }

            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPhanQuyenNguoiDung.Rows)
            {
                string maquyen = row.Cells[1].Value.ToString();
                Boolean cquyen = bool.Parse(row.Cells[3].Value.ToString());
                if (dl.CapNhat_PhanQuyen(maquyen, cquyen) == 1)
                {
 
                }
                
                
            }
            string manhom = dgvNhomNguoiDung.CurrentRow.Cells[1].Value.ToString();
            dgvPhanQuyenNguoiDung.DataSource = dl.TimKiemTheoMaNhom(manhom);
            for (int i = 0; i < dgvPhanQuyenNguoiDung.Rows.Count; i++)
            {
                dgvPhanQuyenNguoiDung.Rows[i].Cells[0].Value = i + 1;
            }

        }
    }
}
