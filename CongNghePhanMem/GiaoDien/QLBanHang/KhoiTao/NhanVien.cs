using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class NhanVien
    {
        string _MaNhanVien;

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }
        string _TenNhanVien;

        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; }
        }
        string _GioiTinh;

        public string GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }
        string _ChucVu;

        public string ChucVu
        {
            get { return _ChucVu; }
            set { _ChucVu = value; }
        }
        string _CMND;

        public string CMND
        {
            get { return _CMND; }
            set { _CMND = value; }
        }
        string _DiaChiThuongTru;

        public string DiaChiThuongTru
        {
            get { return _DiaChiThuongTru; }
            set { _DiaChiThuongTru = value; }
        }
        string _QueQuan;

        public string QueQuan
        {
            get { return _QueQuan; }
            set { _QueQuan = value; }
        }
        DateTime _NgaySinh;

        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }
        DateTime _NgayVaoLam;

        public DateTime NgayVaoLam
        {
            get { return _NgayVaoLam; }
            set { _NgayVaoLam = value; }
        }
        string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        string _SoDienThoai;

        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }
    }
}
