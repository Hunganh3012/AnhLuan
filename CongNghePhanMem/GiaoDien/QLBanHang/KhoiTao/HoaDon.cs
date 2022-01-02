using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class HoaDon
    {
        string _MaHoaDonBanHang;

        public string MaHoaDonBanHang
        {
            get { return _MaHoaDonBanHang; }
            set { _MaHoaDonBanHang = value; }
        }
        string _MaNhanVien;

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }
        string _MaKhachHang;

        public string MaKhachHang
        {
            get { return _MaKhachHang; }
            set { _MaKhachHang = value; }
        }
        DateTime _NgayBan;

        public DateTime NgayBan
        {
            get { return _NgayBan; }
            set { _NgayBan = value; }
        }
        float _TongTien;

        public float TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }
        float _Thue;

        public float Thue
        {
            get { return _Thue; }
            set { _Thue = value; }
        }
        float _ThanhToan;

        public float ThanhToan
        {
            get { return _ThanhToan; }
            set { _ThanhToan = value; }
        }
    }
}
