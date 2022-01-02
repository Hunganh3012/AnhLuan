using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALNhanVien : DbConnection
    {
        DataSet ds = new DataSet();

        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select * from NhanVien order by MaNhanVien asc", connsql);
            ht.Fill(ds, "NhanVien");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["NhanVien"].Columns[0];
            ds.Tables["NhanVien"].PrimaryKey = keys;
            return ds;
        }
        public int Them(NhanVien p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from NhanVien", connsql);
                DataRow newrow = ds.Tables["NhanVien"].NewRow();
                newrow["MaNhanVien"] = p.MaNhanVien;
                newrow["Email"] = p.Email;
                newrow["TenNhanVien"] = p.TenNhanVien;
                newrow["NgaySinh"] = p.NgaySinh;
                newrow["GioiTinh"] = p.GioiTinh;
                newrow["SoDienThoai"] = p.SoDienThoai;
                newrow["DiaChiThuongTru"] = p.DiaChiThuongTru;
                newrow["QueQuan"] = p.QueQuan;
                newrow["NgayVaoLam"] = p.NgayVaoLam;
                newrow["ChucVu"] = p.ChucVu;
                newrow["CMND"] = p.CMND;
                ds.Tables["NhanVien"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "NhanVien");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Xóa
        public int Sua(NhanVien p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from NhanVien", connsql);

                DataRow newrow = ds.Tables["NhanVien"].Rows.Find(p.MaNhanVien);

                if (newrow != null)
                {
                    newrow["MaNhanVien"] = p.MaNhanVien;
                    newrow["TenNhanVien"] = p.TenNhanVien;
                    newrow["NgaySinh"] = p.NgaySinh;
                    newrow["GioiTinh"] = p.GioiTinh;
                    newrow["SoDienThoai"] = p.SoDienThoai;
                    newrow["DiaChiThuongTru"] = p.DiaChiThuongTru;
                    newrow["QueQuan"] = p.QueQuan;
                    newrow["NgayVaoLam"] = p.NgayVaoLam;
                    newrow["ChucVu"] = p.ChucVu;
                    newrow["CMND"] = p.CMND;
                    newrow["Email"] = p.Email;
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "NhanVien");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa
        public int Xoa(NhanVien p)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from NhanVien", connsql);
            DataRow dr = ds.Tables["NhanVien"].Rows.Find(p.MaNhanVien);
            dr.Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            return adapter.Update(ds, "NhanVien");
        }
       // Kiểm tra Ma mat hang de them xoa sua 
        public bool KiemTra_Ma(string pMa)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from HoaDonBanHang where MaNhanVien='" + pMa + "'", connsql);
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
        public bool KiemTra_MaNV(string pMa)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from PhieuNhapHang where MaNhanVien='" + pMa + "'", connsql);
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
            SqlDataAdapter ht = new SqlDataAdapter("SELECT *from NhanVien where TenNhanVien like N'%" + pTen + "%'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public DataTable TimTheoMa(string pMa)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from NhanVien where MaNhanVien='" + pMa + "'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public string MaTuDong()
        {
            DataTable matd = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from NhanVien  order by MaNhanVien asc", connsql);
            ht.Fill(matd);
            string g = "";
            if (matd.Rows.Count <= 0)
            {
                g = "NV01";

            }
            else
            {
                int k;
                g = "NV";
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