using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
using System.Data;
namespace QLNhaSach.XuLy
{
    public class DALGiaBan:DbConnection
    {
        DataSet ds = new DataSet();

        public DataSet LoadGiaBan()
        {
            SqlDataAdapter da_dongia = new SqlDataAdapter("select * from GiaBan order by MaMatHang asc", connsql);
            da_dongia.Fill(ds, "GiaBan");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["GiaBan"].Columns[0];
            ds.Tables["GiaBan"].PrimaryKey = keys;
            return ds;
        }
        public int CapNhatGiaBan(GiaBan pGiaBan)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select *from GiaBan order by MaMatHang asc", connsql);
                DataRow newrow = ds.Tables["GiaBan"].NewRow();
                newrow["MaDonGiaBan"] = pGiaBan.MaDonGiaBan;
                newrow["MaMatHang"] = pGiaBan.MaMatHang;
                newrow["DonGiaBan"] = pGiaBan.DonGiaBan;
                newrow["NgayThayDoi"] = pGiaBan.NgayThayDoi;
                ds.Tables["GiaBan"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "GiaBan");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Xoa(GiaBan p)
        {
            SqlDataAdapter ht = new SqlDataAdapter("select *from GiaBan order by MaDonGiaBan asc", connsql);
            DataRow dr = ds.Tables["GiaBan"].Rows.Find(p.MaDonGiaBan);
            dr.Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ht);
            return ht.Update(ds, "GiaBan");
        }
        public DataTable TimTheoMa(string pMa)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from MatHang where MaLoaiMatHang ='" + pMa + "'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public string MaTuDong()
        {
            DataTable matd = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from GiaBan  order by MaDonGiaBan asc", connsql);
            ht.Fill(matd);
            string g = "";
            if (matd.Rows.Count <= 0)
            {
                g = "GB01";

            }
            else
            {
                int k;
                g = "GB";
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
