using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALKhachHang:DbConnection
    {
        DataSet ds = new DataSet();

        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select * from KhachHang order by MaKhachHang asc", connsql);
            ht.Fill(ds, "KhachHang");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["KhachHang"].Columns[0];
            ds.Tables["KhachHang"].PrimaryKey = keys;
            return ds;
        }
        //Thêm
        public int Them(KhachHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from KhachHang", connsql);
                DataRow newrow = ds.Tables["KhachHang"].NewRow();
                newrow["MaKhachHang"] = p.MaKhachHang;
                newrow["TenKhachHang"] = p.TenKhachHang;
                newrow["NgaySinh"] = p.NgaySinh;
                newrow["GioiTinh"] = p.GioiTinh;
                newrow["SoDienThoai"] = p.SoDienThoai;
                newrow["Email"] = p.Email;
                newrow["DiaChi"] = p.DiaChi;
                ds.Tables["KhachHang"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "KhachHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Xóa
        public int Sua(KhachHang p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from KhachHang", connsql);

                DataRow dr = ds.Tables["KhachHang"].Rows.Find(p.MaKhachHang);

                if (dr != null)
                {
                    dr["TenKhachHang"] = p.TenKhachHang;
                    dr["NgaySinh"] = p.NgaySinh;
                    dr["GioiTinh"] = p.GioiTinh;
                    dr["SoDienThoai"] = p.SoDienThoai;
                    dr["Email"] = p.Email;
                    dr["DiaChi"] = p.DiaChi;
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "KhachHang");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa
        public int Xoa(KhachHang p)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from KhachHang", connsql);
            DataRow dr = ds.Tables["KhachHang"].Rows.Find(p.MaKhachHang);
            dr.Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            return adapter.Update(ds, "KhachHang");
        }
        //Kiểm tra Ma mat hang de them xoa sua 
        public bool KiemTra_Ma(string pMa)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from HoaDonBanHang where MaKhachHang='" + pMa + "'", connsql);
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
        // from khach hang
        public DataTable TimTheoTen(string pTen)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select * from KhachHang where TenKhachHang  like N'%" + pTen + "%'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public DataTable TimKiem_TheoMa(string pMa)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select * from KhachHang where MaKhachHang ='"+ pMa +"' ", connsql);
            ht.Fill(tim);
            return tim;
        }
        public string MaTuDong()
        {
            DataTable matd = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from KhachHang  order by MaKhachHang asc", connsql);
            ht.Fill(matd);
            string g = "";
            if (matd.Rows.Count <= 0)
            {
                g = "KH01";

            }
            else
            {
                int k;
                g = "KH";
                k = Convert.ToInt32(matd.Rows[matd.Rows.Count-1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                g = g + "0";
                g = g + k.ToString();
            }
            return g;
        }
    }
}
