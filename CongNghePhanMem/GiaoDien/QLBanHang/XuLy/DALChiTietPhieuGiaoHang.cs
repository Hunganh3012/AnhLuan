using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALChiTietPhieuGiaoHang:DbConnection
    {
        DataSet ds = new DataSet();
        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select *from ChiTietPhieuGiaoHang order by MaPhieuGiaoHang asc", connsql);
            ht.Fill(ds, "ChiTietPhieuGiaoHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["ChiTietPhieuGiaoHang"].Columns[0];
            ds.Tables["ChiTietPhieuGiaoHang"].PrimaryKey = keys;
            return ds;
        }
        public int Them(ChiTietPhieuGiaoHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietPhieuGiaoHang", connsql);
                adapter.Fill(ds, "ChiTietPhieuGiaoHang");
                // Set PrimaryKey
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["ChiTietPhieuGiaoHang"].Columns[0];
                ds.Tables["ChiTietPhieuGiaoHang"].PrimaryKey = keys;
                DataRow newrow = ds.Tables["ChiTietPhieuGiaoHang"].NewRow();

                newrow["MaChiTietHDBH"] = p.MaChiTietHDBH;
                newrow["MaPhieuGiaoHang"] = p.MaPhieuGiaoHang;
                newrow["SoLuongGiao"] = p.SoLuongGiao;
                ds.Tables["ChiTietPhieuGiaoHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "ChiTietPhieuGiaoHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua(ChiTietPhieuGiaoHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietPhieuGiaoHang", connsql);

                DataRow newrow = ds.Tables["ChiTietPhieuGiaoHang"].Rows.Find(p.MaChiTietHDBH);

                if (newrow != null)
                {
                    newrow["SoLuongGiao"] = p.SoLuongGiao;
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "ChiTietPhieuGiaoHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa
        public int Xoa(ChiTietPhieuGiaoHang p)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietPhieuGiaoHang", connsql);
            DataRow dr = ds.Tables["ChiTietPhieuGiaoHang"].Rows.Find(p.MaChiTietHDBH);
            dr.Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            return adapter.Update(ds, "ChiTietPhieuGiaoHang");
        }


    }
}
