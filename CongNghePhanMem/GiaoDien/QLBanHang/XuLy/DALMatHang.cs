using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALMatHang:DbConnection
    {
        DataSet ds = new DataSet();


        public DataSet Load_KhoHang()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select MAMATHANG,TENMATHANG,SOLUONGTON from MatHang order by TENMATHANG asc", connsql);
            ht.Fill(ds, "MatHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["MatHang"].Columns[0];
            ds.Tables["MatHang"].PrimaryKey = keys;
            return ds;
        }
        public DataSet LoadData()
        {

            SqlDataAdapter ht = new SqlDataAdapter("SELECT *from MATHANG order by MaMatHang asc", connsql);
            ht.Fill(ds, "MatHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["MatHang"].Columns[0];
            ds.Tables["MatHang"].PrimaryKey = keys;
            return ds;
        }
        //Thêm
        public int Them(MatHang p)
        {
            try
            {
                SqlDataAdapter ht = new SqlDataAdapter("SELECT *from MATHANG order by MaMatHang asc", connsql);
                DataRow newrow = ds.Tables["MatHang"].NewRow();
                newrow["MaMatHang"] = p.MaMatHang;
                newrow["TenMatHang"] = p.TenMatHang;
                newrow["MaNhaCungCap"] = p.MaNhaCungCap;
                newrow["DonViTinh"] = p.DonViTinh;
                newrow["MaLoaiMatHang"] = p.MaLoaiMatHang;
                newrow["SoLuongTon"] = p.SoLuongTon;
                newrow["MoTa"] = p.MoTa;
                newrow["ThoiGianBaoHanh"] = p.ThoiGianBaoHanh;
                ds.Tables["MatHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ht);
                ht.Update(ds, "MatHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Xóa
        public int Sua(MatHang p)
        {
            try
            {
                SqlDataAdapter ht = new SqlDataAdapter("select *from MatHang order by TenMatHang asc", connsql);
                DataRow newrow = ds.Tables["MatHang"].Rows.Find(p.MaMatHang);

                if (newrow != null)
                {
                    newrow["MaMatHang"] = p.MaMatHang;
                    newrow["TenMatHang"] = p.TenMatHang;
                    newrow["MaNhaCungCap"] = p.MaNhaCungCap;
                    newrow["DonViTinh"] = p.DonViTinh;
                    newrow["MaLoaiMatHang"] = p.MaLoaiMatHang;
                    newrow["SoLuongTon"] = p.SoLuongTon;
                    newrow["MoTa"] = p.MoTa;
                    newrow["ThoiGianBaoHanh"] = p.ThoiGianBaoHanh;
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ht);
                ht.Update(ds, "MatHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa
        public int Xoa(MatHang p)
        {
            SqlDataAdapter ht = new SqlDataAdapter("select *from MatHang order by TenMatHang asc", connsql);
            DataRow dr = ds.Tables["MatHang"].Rows.Find(p.MaMatHang);
            dr.Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ht);
            return ht.Update(ds, "MatHang");
        }
        //Kiểm tra Ma mat hang de them xoa sua 
        public bool KiemTra_Ma(string pMa)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietHoaDonBanHang where MaMatHang='" + pMa + "'", connsql);
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
        public DataTable TimKiem_TheoTen(string pTen)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("SELECT *from MatHang where TenMatHang like N'%" + pTen + "%'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public DataTable TimKiem_NCC(string pNcc)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from MatHang where MaNhaCungCap='" + pNcc + "'", connsql);
            ht.Fill(tim);
            return tim;
        }
        //public DataTable TimKiem_SoLuong(string sl)
        //{
        //    DataTable tim = new DataTable();
        //    SqlDataAdapter ht = new SqlDataAdapter("SELECT *from MatHang where SoLuong='" + sl + "'", connsql);
        //    ht.Fill(tim);
        //    return tim;
        //}
        //chu ý
        public int CapNhatSoLuong(string pMa ,int pSoluong)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string updatestring = "update MatHang set SoLuongTon='" + pSoluong + "' where MaMatHang='" + pMa + "'";
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
        public DataTable TimKiem_MatHang(string ptenmathang)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter appter = new SqlDataAdapter("SELECT MATHANG.MAMATHANG, MATHANG.TENMATHANG, MATHANG.SOLUONGTON, MATHANG.DONVITINH, GIABAN.DONGIABAN FROM MATHANG INNER JOIN GIABAN ON MATHANG.MAMATHANG = GIABAN.MAMATHANG WHERE (GIABAN.NGAYTHAYDOI IN(SELECT MAX(NGAYTHAYDOI) AS Expr1 FROM GIABAN AS GIABAN_1)) and MatHang.TenMatHang like N'%" + ptenmathang + "%'", connsql);//like '%" +timTheoten  + "%'"
            appter.Fill(tim);
            return tim;
        }

        public DataTable TimKiem_LoaiMatHang(string maLoai)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter appter = new SqlDataAdapter("SELECT MATHANG.MAMATHANG, MATHANG.TENMATHANG, MATHANG.SOLUONGTON, MATHANG.DONVITINH, GIABAN.DONGIABAN FROM MATHANG INNER JOIN GIABAN ON MATHANG.MAMATHANG = GIABAN.MAMATHANG WHERE (GIABAN.NGAYTHAYDOI IN(SELECT MAX(NGAYTHAYDOI) AS Expr1 FROM GIABAN AS GIABAN_1)) and MatHang.MaLoaiMatHang='" + maLoai + "'", connsql);
            appter.Fill(tim);
            return tim;
        }
        public DataTable TimTheoMa(string pMa)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from MatHang where MaMatHang ='" + pMa + "'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public string MaTuDong()
        {
            DataTable matd = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from MatHang  order by MaMatHang asc", connsql);
            ht.Fill(matd);
            string g = "";
            if (matd.Rows.Count <= 0)
            {
                g = "MH01";

            }
            else
            {
                int k;
                g = "MH";
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
