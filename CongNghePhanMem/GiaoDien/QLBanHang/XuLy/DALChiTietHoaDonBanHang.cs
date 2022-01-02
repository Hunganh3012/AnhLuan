using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public  class DALChiTietHoaDonBanHang:DbConnection
    {
        DataSet ds = new DataSet();
        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select * from ChiTietHoaDonBanHang order by MaHoaDonBanHang", connsql);
            ht.Fill(ds, "ChiTietHoaDonBanHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["ChiTietHoaDonBanHang"].Columns[0];
            ds.Tables["ChiTietHoaDonBanHang"].PrimaryKey = keys;
            return ds;
        }
        public int Them(ChiTietHoaDonBanHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietHoaDonBanHang", connsql);
                adapter.Fill(ds, "ChiTietHoaDonBanHang");
                // Set PrimaryKey
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["ChiTietHoaDonBanHang"].Columns[0];
                ds.Tables["ChiTietHoaDonBanHang"].PrimaryKey = keys;
                DataRow newrow = ds.Tables["ChiTietHoaDonBanHang"].NewRow();
                newrow["MACHITIETHDBH"] = p.MACHITIETHDBH;
                newrow["MaMatHang"] = p.MaMatHang;
                newrow["MaHoaDonBanHang"] = p.MaHoaDonBanHang;
                newrow["SoLuongBan"] = p.SoLuongBan;
                newrow["DonGiaBan"] = p.DonGiaBan;
                ds.Tables["ChiTietHoaDonBanHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "ChiTietHoaDonBanHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua(ChiTietHoaDonBanHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietHoaDonBanHang", connsql);

                DataRow newrow = ds.Tables["ChiTietHoaDonBanHang"].Rows.Find(p.MACHITIETHDBH);

                if (newrow != null)
                {
                    newrow["MaCTHoaDonBanHang"] = p.MACHITIETHDBH;
                    newrow["MaMatHang"] = p.MaMatHang;
                    newrow["MaHoaDonBanHang"] = p.MaHoaDonBanHang;
                    newrow["SoLuongBan"] = p.SoLuongBan;
                    newrow["ThanhTien"] = p.ThanhTien;
                    newrow["DonGiaBan"] = p.DonGiaBan;
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "ChiTietHoaDonBanHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa
        public int Xoa(ChiTietHoaDonBanHang p)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietHoaDonBanHang", connsql);
            DataRow dr = ds.Tables["ChiTietHoaDonBanHang"].Rows.Find(p.MACHITIETHDBH);
            dr.Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            return adapter.Update(ds, "ChiTietHoaDonBanHang");
        }
        public bool KiemTra_Ma(string pmh)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietHoaDonBanHang where MaMatHang='" + pmh + "'", connsql);
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

        public DataSet TimKiemMa(string pMa)
        {
            ds = new DataSet();
            SqlDataAdapter ht = new SqlDataAdapter("select * from ChiTietHoaDonBanHang where MaCTHoaDonBanHanglike '%" + pMa + "%'", connsql);
            ht.Fill(ds, "ChiTietHoaDonBanHang");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["ChiTietHoaDonBanHang"].Columns[0];
            ds.Tables["ChiTietHoaDonBanHang"].PrimaryKey = keys;
            return ds;
        }
        public bool KiemTraMatHangDaCo(string mapn, string mamh)
        {

            SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietHoaDonBanHang where MaHoaDonBanHang='" + mapn + "'and MaMatHang='" + mamh + "'", connsql);
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
        public int TinhTongTien(int Tong)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select sum(thanhtien) AS tt from CHITIETPHIEUNHAPHANG where MAPHIEUNHAPHANG='" + Tong + "'", connsql);
            return 1;
        }
    }
}
