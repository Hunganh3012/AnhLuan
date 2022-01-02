using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLNhaSach.KhoiTao;
namespace QLNhaSach.XuLy
{
    public class DALNhaCungCap:DbConnection
    {
        DataSet ds = new DataSet();

        public DataSet LoadData()
        {
            SqlDataAdapter ht = new SqlDataAdapter("select * from NhaCungCap order by MaNhaCungCap asc", connsql);
            ht.Fill(ds, "NhaCungCap");
            // Set PrimaryKey
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["NhaCungCap"].Columns[0];
            ds.Tables["NhaCungCap"].PrimaryKey = keys;
            return ds;
        }
        //Thêm
        public int Them(NhaCungCap p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from NhaCungCap", connsql);
                DataRow newrow = ds.Tables["NhaCungCap"].NewRow();
                newrow["MaNhaCungCap"] = p.MaNhaCungCap;
                newrow["TenNhaCungCap"] = p.TenNhaCungCap;
                newrow["DiaChi"] = p.DiaChi;
                newrow["SoDienThoai"] = p.SoDienThoai;
                newrow["Email"] = p.Email;
                ds.Tables["NhaCungCap"].Rows.Add(newrow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "NhaCungCap");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Xóa
        public int Sua(NhaCungCap p)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from NhaCungCap", connsql);

                DataRow dr = ds.Tables["NhaCungCap"].Rows.Find(p.MaNhaCungCap);

                if (dr != null)
                {
                    dr["TenNhaCungCap"] = p.TenNhaCungCap;
                    dr["DiaChi"] = p.DiaChi;
                    dr["SoDienThoai"] = p.SoDienThoai;
                    dr["Email"] = p.Email;
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "NhaCungCap");
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa
        public int Xoa(NhaCungCap p)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from NhaCungCap", connsql);
            DataRow dr = ds.Tables["NhaCungCap"].Rows.Find(p.MaNhaCungCap);
            dr.Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            return adapter.Update(ds, "NhaCungCap");
        }
        public DataTable TimKiem_TheoMa(string pMa)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from NhaCungCap where MaNhaCungCap ='" + pMa + "'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public DataTable TimKiem_TheoTen(string pTen)
        {
            DataTable tim = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("SELECT *from NhaCungCap where TenNhaCungCap like N'%" + pTen + "%'", connsql);
            ht.Fill(tim);
            return tim;
        }
        public string MaTuDong()
        {
            DataTable matd = new DataTable();
            SqlDataAdapter ht = new SqlDataAdapter("select *from NhaCungCap ", connsql);
            ht.Fill(matd);
            string g = "";
            if (matd.Rows.Count <= 0)
            {
                g = "NC01";

            }
            else
            {
                int k;
                g = "NC";
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
