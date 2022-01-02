using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALPhieuNhapHang:DbConnection
    {
        DataSet ds = new DataSet();
        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select * from PhieuNhapHang order by MaPhieuNhapHang asc", connsql);
            ht.Fill(ds, "PhieuNhapHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["PhieuNhapHang"].Columns[0];
            ds.Tables["PhieuNhapHang"].PrimaryKey = keys;
            return ds;
        }
        public int Them(PhieuNhapHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from PhieuNhapHang", connsql);
                adapter.Fill(ds, "PhieuNhapHang");
                // Set PrimaryKey
                DataColumn[] keys = new DataColumn[1];
                keys[0] = ds.Tables["PhieuNhapHang"].Columns[0];
                ds.Tables["PhieuNhapHang"].PrimaryKey = keys;
                DataRow newrow = ds.Tables["PhieuNhapHang"].NewRow();
                newrow["MaPhieuNhapHang"] = p.MaPhieuNhapHang;
                newrow["MaNhanVien"] = p.MaNhanVien;
                newrow["NgayNhapHang"] = p.NgayNhapHang;
                newrow["LanNhap"] = p.LanNhap;
                newrow["GhiChu"] = p.GhiChu;
                newrow["ThanhToan"] = p.ThanhToan;
                newrow["TongTien"] = p.TongTien;
                ds.Tables["PhieuNhapHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "PhieuNhapHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
         
        public DataTable Load_DsMatHang_TheoPhieuMuaHang(string pMaPhieu)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter appter = new SqlDataAdapter("SELECT MATHANG.TENMATHANG, CHITIETPHIEUMUAHANG.DONGIANHAP, CHITIETPHIEUMUAHANG.SOLUONGMUA, CHITIETPHIEUMUAHANG.MAMATHANG,  CHITIETPHIEUMUAHANG.MACHITIETPMH, MATHANG.DONVITINH FROM MATHANG INNER JOIN CHITIETPHIEUMUAHANG ON MATHANG.MAMATHANG = CHITIETPHIEUMUAHANG.MAMATHANG WHERE  CHITIETPHIEUMUAHANG.MAPHIEUMUAHANG ='" + pMaPhieu + "' and CHITIETPHIEUMUAHANG.SOLUONGMua >0 order by MaMatHang asc", connsql);
            appter.Fill(tim);
            return tim;
        }
        public DataTable TimKiemMatHang(string pMaPhieu, string pTenMatHang)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter appter = new SqlDataAdapter("SELECT CHITIETPHIEUMUAHANG.MAMATHANG, CHITIETPHIEUMUAHANG.DONGIANHAP, CHITIETPHIEUMuaHANG.SOLUONGMUA, MATHANG.TENMATHANG, MATHANG.DONVITINH FROM MATHANG INNER JOIN CHITIETPHIEUMUAHANG ON MATHANG.MAMATHANG = CHITIETPHIEUMUAHANG.MAMATHANG WHERE  CHITIETPHIEUMUAHANG.MAPHIEUMUAHANG ='" + pMaPhieu + "' and mathang.TENMATHANG like N'%" + pTenMatHang + "%' and CHITIETPHIEUMUAHANG.SOLUONGMua >0 order by MaMatHang asc", connsql);
            appter.Fill(tim);
            return tim;
        }
        public DataTable Load_DsKhoHang()
        {
            DataTable tim = new DataTable();
            SqlDataAdapter appter = new SqlDataAdapter("select mamathang,tenmathang,soluongton from mathang order by MaMatHang asc", connsql);
            appter.Fill(tim);
            return tim;
        }
        public DataTable TimKiemNhaCungCap(string pMaPhieu)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter appter = new SqlDataAdapter("SELECT PHIEUMUAHANG.MaNhaCungCap, NHACUNGCAP.TENNHACUNGCAP FROM NHACUNGCAP INNER JOIN PHIEUMUAHANG ON NHACUNGCAP.MANHACUNGCAP = PHIEUMUAHANG.MaNhaCungCap WHERE PHIEUMUAHANG.MAPHIEUMUAHANG ='" + pMaPhieu + "'", connsql);
            appter.Fill(tim);
            return tim;
        }
        public string MaTuDong()
        {
            DataTable matd = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from PhieuNhapHang  order by MaPhieuNhapHang asc", connsql);
            ht.Fill(matd);
            string g = "";
            if (matd.Rows.Count <= 0)
            {
                g = "PN01";

            }
            else
            {
                int k;
                g = "PN";
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
