using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    class DALLoaiMatHang:DbConnection
    {
        DataSet DS_LoaiMatHang = new DataSet();

        public DataSet LoadLoaiMatHang()
        {
            SqlDataAdapter da_loai = new SqlDataAdapter("select * from LoaiMatHang order by MaLoaiMatHang asc", connsql);
            da_loai.Fill(DS_LoaiMatHang, "LoaiMatHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = DS_LoaiMatHang.Tables["LoaiMatHang"].Columns[0];
            DS_LoaiMatHang.Tables["LoaiMatHang"].PrimaryKey = keys;
            return DS_LoaiMatHang;
        }
        //Thêm
        public int ThemLoaiMaThang(LoaiMatHang pLoaiMatHang)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from LoaiMatHang", connsql);
                DataRow newrow = DS_LoaiMatHang.Tables["LoaiMatHang"].NewRow();
                newrow["MaLoaiMatHang"] = pLoaiMatHang.MaLoaiMatHang;
                newrow["TenLoaiMatHang"] = pLoaiMatHang.TenLoaiMatHang;
                DS_LoaiMatHang.Tables["LoaiMatHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(DS_LoaiMatHang, "LoaiMatHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Xóa
        public int SuaLoaiMathang(LoaiMatHang pLoaiMatHang)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from LoaiMatHang", connsql);

                DataRow dr = DS_LoaiMatHang.Tables["LoaiMatHang"].Rows.Find(pLoaiMatHang.MaLoaiMatHang);

                if (dr != null)
                {
                    dr["TenLoaiMatHang"] = pLoaiMatHang.TenLoaiMatHang;
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(DS_LoaiMatHang, "LoaiMatHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa
        public int XoaLoaiMatHang(LoaiMatHang pLoaiMatHang)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from LoaiMatHang", connsql);
            DataRow dr = DS_LoaiMatHang.Tables["LoaiMatHang"].Rows.Find(pLoaiMatHang.MaLoaiMatHang);
            dr.Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            return adapter.Update(DS_LoaiMatHang, "LoaiMatHang");
        }
        //Kiểm tra Ma mat hang de them xoa sua 
        public bool KiemTra_MaLoaiMatHang(string pMaMatHang)
        {
            SqlDataAdapter da_mathang = new SqlDataAdapter("select * from MatHang where MaLoaiMatHang='" + pMaMatHang + "'", connsql);
            DataTable dt_mathang = new DataTable();
            da_mathang.Fill(dt_mathang);
            if (dt_mathang.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable TimTheoTen(string pTen)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select * from LoaiMatHang where TenLoaiMatHang like N'%" + pTen + "%'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public DataTable TimTheoMa(string pMa)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from LoaiMatHang where MaLoaiMatHang ='" + pMa + "'", connsql);
            ht.Fill(tim);
            return tim;
        }

        public string MaTuDong()
        {
            DataTable matd = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from LoaiMatHang ", connsql);
            ht.Fill(matd);
            string g="";
            if (matd.Rows.Count <= 0)
            {
                g = "LH01";

            }
            else
            {
                int k;
                g = "LH";
                k = Convert.ToInt32(matd.Rows[matd.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                 g = g + "0";
                g = g + k.ToString();
            }
            return g;
        }
    }
}
