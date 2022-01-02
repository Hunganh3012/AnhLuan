using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALHoaDonBanHang:DbConnection
    {
        DataSet ds = new DataSet();
        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select * from HoaDonBanHang order by MaHoaDonBanHang asc", connsql);
            ht.Fill(ds, "HoaDonBanHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["HoaDonBanHang"].Columns[0];
            ds.Tables["HoaDonBanHang"].PrimaryKey = keys;
            return ds;
        }
        public DataTable LoadDanhSachHoaDon()
        {
             DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("SELECT HOADONBANHANG.MAHOADONBANHANG,KHACHHANG.TENKHACHHANG, HOADONBANHANG.NGAYBAN, HOADONBANHANG.THUE, HOADONBANHANG.TONGTIEN, HOADONBANHANG.THANHTOAN FROM HOADONBANHANG INNER JOIN  KHACHHANG ON HOADONBANHANG.MAKHACHHANG = KHACHHANG.MAKHACHHANG order by hoadonbanHang.mahoadonbanhang asc", connsql);
            ht.Fill(ds, "HoaDonBanHang");
            ht.Fill(tim);
            return tim;
        }
        public int Them(HoaDon p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from HoaDonBanHang", connsql);
                adapter.Fill(ds, "HoaDonBanHang");
                // Set PrimaryKey
                //DataColumn[] keys = new DataColumn[1];
                //keys[0] = ds.Tables["HoaDonBanHang"].Columns[0];
                //ds.Tables["HoaDonBanHang"].PrimaryKey = keys;
                DataRow newrow = ds.Tables["HoaDonBanHang"].NewRow();
                newrow["MaHoaDonBanHang"] =p.MaHoaDonBanHang;
                newrow["MaNhanVien"] = p.MaNhanVien;
                newrow["MaKhachHang"] = p.MaKhachHang;
                newrow["NgayBan"] = p.NgayBan;
                newrow["TongTien"] = p.TongTien;
                newrow["Thue"] = p.Thue;
                newrow["ThanhToan"] = p.ThanhToan;
                ds.Tables["HoaDonBanHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "HoaDonBanHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua(HoaDon p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from HoaDonBanHang", connsql);

                DataRow newrow = ds.Tables["HoaDonBanHang"].Rows.Find(p.MaHoaDonBanHang);

                if (newrow != null)
                {
                    newrow["MaHoaDonBanHang"] = p.MaHoaDonBanHang;
                    newrow["MaNhanVien"] = p.MaNhanVien;
                    newrow["MaKhachHang"] = p.MaKhachHang;
                    newrow["NgayBan"] = p.NgayBan;
                    newrow["TongTien"] = p.TongTien;
                    newrow["Thue"] = p.Thue;
                    newrow["ThanhToan"] = p.ThanhToan;
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "HoaDonBanHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa
        public int Xoa(HoaDon p)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from HoaDonBanHang", connsql);
            DataRow dr = ds.Tables["HoaDonBanHang"].Rows.Find(p.MaHoaDonBanHang);
            dr.Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            return adapter.Update(ds, "HoaDonBanHang");
        }
        public bool KiemTra_Ma(string pMa)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietHoaDonBanHang where MaHoaDonBanHang='" + pMa + "'", connsql);
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

        public DataSet TimKiem(string pMa, string nv, string kh)
        {
            ds = new DataSet();
            SqlDataAdapter ht = new SqlDataAdapter("select * from HoaDonBanHang where MaHoaDonBanHang like '%" + pMa + "%' and MaNhanVien like'%" + nv + "%'and MaKhachHang like'%" + kh + "%'", connsql);
            ht.Fill(ds, "HoaDonBanHang");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["HoaDonBanHang"].Columns[0];
            ds.Tables["HoaDonBanHang"].PrimaryKey = keys;
            return ds;
        }
        public DataTable Load_DsMatHang()
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("SELECT MATHANG.MAMATHANG, MATHANG.TENMATHANG, MATHANG.SOLUONGTON, MATHANG.DONVITINH, GIABAN.DONGIABAN FROM MATHANG INNER JOIN GIABAN ON MATHANG.MAMATHANG = GIABAN.MAMATHANG WHERE (GIABAN.NGAYTHAYDOI IN(SELECT MAX(NGAYTHAYDOI) AS Expr1 FROM GIABAN AS GIABAN_1))", connsql);
            ht.Fill(tim);
            return tim;
        }
        public DataTable Load_ChiTietHoaDonBanHang(string pMaHD)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("SELECT  CHITIETHOADONBANHANG.DonGiaBan, CHITIETHOADONBANHANG.SOLUONGBAN,CHITIETHOADONBANHANG.MAMATHANG, MATHANG.TENMATHANG, MATHANG.DONVITINH FROM CHITIETHOADONBANHANG INNER JOIN HOADONBANHANG ON CHITIETHOADONBANHANG.MAHOADONBANHANG = HOADONBANHANG.MAHOADONBANHANG INNER JOIN MATHANG ON CHITIETHOADONBANHANG.MAMATHANG = MATHANG.MAMATHANG WHERE (CHITIETHOADONBANHANG.MAHOADONBANHANG IN (SELECT  MAHOADONBANHANG FROM HOADONBANHANG AS HOADONBANHANG_1 WHERE (MAHOADONBANHANG = '" + pMaHD + "')))", connsql);
            ht.Fill(tim);
            return tim;
        }
        public string MaTuDong()
        {
            DataTable matd = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from HoaDonBanHang  order by MaHoaDonBanHang asc", connsql);
            ht.Fill(matd);
            string g = "";
            if (matd.Rows.Count <= 0)
            {
                g = "HD01";

            }
            else
            {
                int k;
                g = "HD";
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
