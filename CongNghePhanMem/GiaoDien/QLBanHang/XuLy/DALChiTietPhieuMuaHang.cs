using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALChiTietPhieuMuaHang : DbConnection
    {
        DataSet ds = new DataSet();
        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select *from ChiTietPhieuMuaHang order by MaPhieuMuaHang asc", connsql);
            ht.Fill(ds, "ChiTietPhieuMuaHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["ChiTietPhieuMuaHang"].Columns[0];
            ds.Tables["ChiTietPhieuMuaHang"].PrimaryKey = keys;
            return ds;
        }
        public DataSet Load_TheoMa(string pMaPhieumuaHang)
        {
            SqlDataAdapter ht = new SqlDataAdapter("select *from ChiTietPhieuMuaHang where MaPhieuMuaHang='" + pMaPhieumuaHang + "' order by MaPhieuMuaHang asc", connsql);
            ht.Fill(ds, "ChiTietPhieuNhapHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["ChiTietPhieuMuaHang"].Columns[0];
            ds.Tables["ChiTietPhieuMuaHang"].PrimaryKey = keys;
            return ds;
        }
        public int Them(ChiTietPhieuMuaHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietPhieuMuaHang", connsql);
                adapter.Fill(ds, "ChiTietPhieuMuaHang");
                // Set PrimaryKey
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["ChiTietPhieuMuaHang"].Columns[0];
                ds.Tables["ChiTietPhieuMuaHang"].PrimaryKey = keys;
                DataRow newrow = ds.Tables["ChiTietPhieuMuaHang"].NewRow();
                newrow["MaCHiTietPMH"] = p.MaCHiTietPMH;
                newrow["MaMatHang"] = p.MaMatHang;
                newrow["MaPhieuMuaHang"] = p.MaPhieuMuaHang;
                newrow["SoLuongMua"] = p.SoLuongMua;
                newrow["DonGiaNhap"] = p.DonGiaNhap;
                ds.Tables["ChiTietPhieuMuaHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "ChiTietPhieuMuaHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public DataSet TimKiemMa(string pMa)
        {
            ds = new DataSet();
            SqlDataAdapter ht = new SqlDataAdapter("select * from ChiTietPhieuMuaHang where MaPhieuMuaHang like '%" + pMa + "%'", connsql);
            ht.Fill(ds, "ChiTietPhieuMuaHang");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["ChiTietPhieuMuaHang"].Columns[0];
            ds.Tables["ChiTietPhieuMuaHang"].PrimaryKey = keys;
            return ds;
        }
        public int CapNhatSoLuongNhapHang(string pMa, int pSoluong)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string updatestring = "update ChiTietPhieuMuaHang set SoLuongMua='" + pSoluong + "' where MaChiTietPMH='" + pMa + "'";
                SqlCommand cmd = new SqlCommand(updatestring, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                    connsql.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public bool KiemTraMatHangDaCo(string mapn,string mamh)
        {

            SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietPhieuMuaHang where MaPhieuMuaHang='" + mapn + "'and MaMatHang='" + mamh + "'", connsql);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

    }

}
