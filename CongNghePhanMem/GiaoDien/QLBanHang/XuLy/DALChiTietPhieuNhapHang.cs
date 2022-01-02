using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALChiTietPhieuNhapHang:DbConnection
    {
        DataSet ds = new DataSet();
        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select *from ChiTietPhieuNhapHang", connsql);
            ht.Fill(ds, "ChiTietPhieuNhapHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["ChiTietPhieuNhapHang"].Columns[0];
            ds.Tables["ChiTietPhieuNhapHang"].PrimaryKey = keys;
            return ds;
        }
        public int Them(ChiTietPhieuNhapHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietPhieuNhapHang", connsql);
                adapter.Fill(ds, "ChiTietPhieuNhapHang");
                // Set PrimaryKey
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["ChiTietPhieuNhapHang"].Columns[0];
                ds.Tables["ChiTietPhieuNhapHang"].PrimaryKey = keys;
                DataRow newrow = ds.Tables["ChiTietPhieuNhapHang"].NewRow();
                newrow["MaPhieuNhapHang"] = p.MaPhieuNhapHang;
                newrow["MaCHiTietPMH"] = p.MaChiTietPMH;
                newrow["SoLuongNhap"] = p.SoLuongNhap;
                newrow["MaChiTietPNH"] = p.MaChiTietPNH;
                ds.Tables["ChiTietPhieuNhapHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "ChiTietPhieuNhapHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
