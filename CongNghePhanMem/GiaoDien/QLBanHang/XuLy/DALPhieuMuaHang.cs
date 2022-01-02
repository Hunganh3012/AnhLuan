using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALPhieuMuaHang:DbConnection
    {
        DataSet ds = new DataSet();
        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select * from PhieuMuaHang order by MaPhieuMuaHang asc", connsql);
            ht.Fill(ds, "PhieuMuaHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["PhieuMuaHang"].Columns[0];
            ds.Tables["PhieuMuaHang"].PrimaryKey = keys;
            return ds;
        }
        public int Them(PhieuMuaHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from PhieuMuaHang", connsql);
                adapter.Fill(ds, "PhieuMuaHang");
                // Set PrimaryKey
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["PhieuMuaHang"].Columns[0];
                ds.Tables["PhieuMuaHang"].PrimaryKey = keys;
                DataRow newrow = ds.Tables["PhieuMuaHang"].NewRow();
                newrow["MaPhieuMuaHang"] = p.MaPhieuMuaHang;
                newrow["MaNhanVien"] = p.MaNhanVien;
                newrow["MaNhaCungCap"] = p.MaNhaCungCap;
                newrow["NgayDatMua"] = p.NgayDatMua;
                newrow["NgayNhapDuKien"] = p.NgayNhapHang;
                newrow["GhiChu"] = p.GhiChu;
                newrow["ThanhToan"] = p.ThanhToan;
                newrow["TongTien"]=p.TongTien;
                ds.Tables["PhieuMuaHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "PhieuMuaHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public DataSet Load_DSMatHang()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select MAMATHANG,TENMATHANG,SOLUONGTON,DONVITINH from MatHang order by MaMatHang asc", connsql);
            ht.Fill(ds, "MatHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["MatHang"].Columns[0];
            ds.Tables["MatHang"].PrimaryKey = keys;
            return ds;
        }
        public DataTable TimKiem_MatHang(string pTenmathang)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter appter = new SqlDataAdapter("select MAMATHANG,TENMATHANG,SOLUONGTON,DONVITINH from MatHang  where TenMatHang='" + pTenmathang + "'order by MaMatHang asc", connsql);
            appter.Fill(tim);
            return tim;
        }

        public DataTable TimKiem_LoaiMatHang(string pMaLoai)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter appter = new SqlDataAdapter("select MAMATHANG,TENMATHANG,SOLUONGTON,DONVITINH from MatHang where MaLoaiMatHang='" + pMaLoai + "'order by MaMatHang asc", connsql);
            appter.Fill(tim);
            return tim;
        }
        public string MaTuDong()
        {
            DataTable matd = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from PhieuMuaHang  order by MaPhieuMuaHang asc", connsql);
            ht.Fill(matd);
            string g = "";
            if (matd.Rows.Count <= 0)
            {
                g = "PM01";

            }
            else
            {
                int k;
                g = "PM";
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
