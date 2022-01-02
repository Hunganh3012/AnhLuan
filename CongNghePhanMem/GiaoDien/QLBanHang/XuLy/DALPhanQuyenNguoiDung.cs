using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALPhanQuyenNguoiDung:DbConnection
    {
        DataSet ds = new DataSet();

        public DataSet Load_Data_NguoiDung()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select *from NguoiDung order by MaNhom asc", connsql);
            ht.Fill(ds, "NguoiDung");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["NguoiDung"].Columns[0];
            ds.Tables["NguoiDung"].PrimaryKey = keys;
            return ds;
        }
        public DataSet Load_Data_PhanQuyen()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select *from PhanQuyen order by MaPhanQuyen asc", connsql);
            ht.Fill(ds, "MaPhanQuyen");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["PhanQuyen"].Columns[0];
            ds.Tables["PhanQuyen"].PrimaryKey = keys;
            return ds;
        }
        public DataSet Load_Data_NhomNguoiDung()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select manhom, tennhom from NhomNguoiDung order by MaNhom asc", connsql);
            ht.Fill(ds, "NhomNguoiDung");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["NhomNguoiDung"].Columns[0];
            ds.Tables["NhomNguoiDung"].PrimaryKey = keys;
            return ds;
        }
        public DataSet Load_Data_ManHinh()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select *from ManHinh order by MaManHinh asc", connsql);
            ht.Fill(ds, "MaManHinh");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["ManHinh"].Columns[0];
            ds.Tables["ManHinh"].PrimaryKey = keys;
            return ds;
        }

        public int Them_NguoiDung(NguoiDung p)
        {
            try
            {
                SqlDataAdapter ht = new SqlDataAdapter("SELECT *from NguoiDung order by MaNhanVien asc", connsql);
                DataRow newrow = ds.Tables["NguoiDung"].NewRow();
                newrow["MaNhanVien"] = p.MaNhanVien;
                newrow["MaNhom"] = p.MaNhom;
                newrow["TenDangNhap"] = p.TenDangNhap;
                newrow["MatKhau"] = p.MatKhau;
                ds.Tables["NguoiDung"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ht);
                ht.Update(ds, "NguoiDung");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua_NguoiDung(NguoiDung p)
        {
            try
            {
                SqlDataAdapter ht = new SqlDataAdapter("SELECT *from NguoiDung order by MaNhom asc", connsql);
                DataRow newrow = ds.Tables["NguoiDung"].Rows.Find(p.TenDangNhap);

                if (newrow != null)
                {
                    newrow["MaNhanVien"] = p.MaNhanVien;
                    newrow["MaNhom"] = p.MaNhom;
                    newrow["MatKhau"] = p.MatKhau;
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ht);
                ht.Update(ds, "NguoiDung");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Xoa_NguoiDung(NguoiDung p)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from NguoiDung", connsql);
            DataRow dr = ds.Tables["NguoiDung"].Rows.Find(p.TenDangNhap);
            dr.Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            return adapter.Update(ds, "NguoiDung");
        }
        public DataTable TimKiemTheoMaNhom(string pMa)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("SELECT PHANQUYEN.MAPHANQUYEN, MANHINH.TENMANHINH, PHANQUYEN.QUYEN FROM MANHINH INNER JOIN PHANQUYEN ON MANHINH.MAMANHINH = PHANQUYEN.MAMANHINH INNER JOIN NHOMNGUOIDUNG ON PHANQUYEN.MANHOM = NHOMNGUOIDUNG.MANHOM WHERE PHANQUYEN.MANHOM = '" + pMa + "'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public int CapNhat_PhanQuyen(string pMa,Boolean pCoQuyen)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string updatestring = "update PhanQuyen set Quyen='" + pCoQuyen + "' where MaPhanQuyen='" + pMa + "'";
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
        public int DoiMatKhau(string pTenDangNhap, string pMatKhau)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string updatestring = "update NguoiDung set MatKhau='" + pMatKhau + "' where TenDangNhap='" + pTenDangNhap + "'";
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
        public DataTable TimMaNhom(string pMaNhom)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from NhomNguoiDung where MaNhom='" + pMaNhom + "'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public DataTable Tim_TenDangNhap(string pMaNhom)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from NguoiDung where TenDangNhap='" + pMaNhom + "'", connsql);
            ht.Fill(tim);
            return tim;
        }
        // dang nhap he thong
        public bool DangNhapHeThong(string ten, string matkhau)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from NguoiDung where TenDangNhap ='" + ten + "' and MatKhau = '" + matkhau + "'", connsql);
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
        // hien thi ten nhan vien trong form chinh
        public DataTable TimTenNhanVien(string Pten)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("SELECT NHANVIEN.TENNHANVIEN FROM NHANVIEN INNER JOIN NGUOIDUNG ON NHANVIEN.MANHANVIEN = NGUOIDUNG.MANHANVIEN where TenDangNhap='" + Pten + "'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public bool QuyenDangNhap(string pManhom, string pMaManhinh, string pQuyen)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select manhom,mamanhinh,quyen from PhanQuyen where manhom ='" + pManhom + "'and quyen = '" + pQuyen + "' AND mamanhinh = '" + pMaManhinh + "'", connsql);
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
        // kiem tra mat khau cu
        public bool KiemTraMatKhauCu(string pTenDangNhap, string matkhau)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from NguoiDung where TenDangNhap ='" + pTenDangNhap + "' and MatKhau = '" + matkhau + "'", connsql);
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
        //hien thi ten nhan vien len from chinh sau khi dang nhap
        public DataTable Tim_NhanVien(string pTenDangNhap)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("SELECT NHANVIEN.MANHANVIEN, NHANVIEN.TENNHANVIEN FROM NHANVIEN INNER JOIN NGUOIDUNG ON NHANVIEN.MANHANVIEN = NGUOIDUNG.MANHANVIEN WHERE (NGUOIDUNG.TENDANGNHAP = '"+pTenDangNhap+"')", connsql);
            ht.Fill(tim);
            return tim;
        }

        public DataTable TimMaNhom_TheoTenDangNhap(string PTenDangNhap)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter(" SELECT NGUOIDUNG.MANHOM FROM NHOMNGUOIDUNG INNER JOIN NGUOIDUNG ON NHOMNGUOIDUNG.MANHOM = NGUOIDUNG.MANHOM WHERE  NGUOIDUNG.TENDANGNHAP  = '" + PTenDangNhap + "'", connsql);
            ht.Fill(tim);
            return tim;
        }
    }
}
