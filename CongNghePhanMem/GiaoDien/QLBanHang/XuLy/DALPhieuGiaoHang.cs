using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALPhieuGiaoHang:DbConnection
    {
        DataSet ds = new DataSet();
        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select * from PhieuGiaoHang rder by MaPhieuGiaoHang asc", connsql);
            ht.Fill(ds, "PhieuGiaoHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["PhieuGiaoHang"].Columns[0];
            ds.Tables["PhieuGiaoHang"].PrimaryKey = keys;
            return ds;
        }
        public int Them(PhieuGiaoHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from PhieuGiaoHang", connsql);
                adapter.Fill(ds, "PhieuGiaoHang");
                // Set PrimaryKey
                //DataColumn[] keys = new DataColumn[1];
                //keys[0] = ds.Tables["HoaDonBanHang"].Columns[0];
                //ds.Tables["HoaDonBanHang"].PrimaryKey = keys;
                DataRow newrow = ds.Tables["PhieuGiaoHang"].NewRow();
                newrow["MaKhacHang"] = p.MaKhacHang;
                newrow["MaNhanVien"] = p.MaNhanVien;
                newrow["NgayGiao"] = p.NgayGiao;
                newrow["MaPhieuGiao"] = p.MaPhieuGiao;
                newrow["DiaChiGiao"] = p.DiaChiGiao;
                newrow["GhiChu"] = p.GhiChu;

                newrow["LanGiao"] = p.LanGiao;
                newrow["SoDienThoai"] = p.SoDienThoai;
                newrow["TongTien"] = p.TongTien;
                newrow["ThanhToanSau"] = p.ThanhToanSau;
                ds.Tables["PhieuGiaoHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "PhieuGiaoHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public string MaTuDong()
        {
            DataTable matd = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from PhieuGiaoHang  order by MaPhieuGiaoHang", connsql);
            ht.Fill(matd);
            string g = "";
            if (matd.Rows.Count <= 0)
            {
                g = "PG01";

            }
            else
            {
                int k;
                g = "PG";
                k = Convert.ToInt32(matd.Rows[matd.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                    g = g + "0";
                g = g + k.ToString();
            }
            return g;
        }

        public DataSet Load_DsMatHang()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select * from HoaDonBanHang order by MaHoaDonBanHang asc", connsql);
            ht.Fill(ds, "HoaDonBanHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["HoaDonBanHang"].Columns[0];
            ds.Tables["HoaDonBanHang"].PrimaryKey = keys;
            return ds;
        }
    }
}
