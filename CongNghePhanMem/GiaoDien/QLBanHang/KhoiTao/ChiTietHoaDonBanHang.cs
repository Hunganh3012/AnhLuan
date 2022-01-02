using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class ChiTietHoaDonBanHang
    {
        string _MACHITIETHDBH;

        public string MACHITIETHDBH
        {
            get { return _MACHITIETHDBH; }
            set { _MACHITIETHDBH = value; }
        }
        string _MaHoaDonBanHang;

        public string MaHoaDonBanHang
        {
            get { return _MaHoaDonBanHang; }
            set { _MaHoaDonBanHang = value; }
        }
        string _MaMatHang;

        public string MaMatHang
        {
            get { return _MaMatHang; }
            set { _MaMatHang = value; }
        }
        int _SoLuongBan;

        public int SoLuongBan
        {
            get { return _SoLuongBan; }
            set { _SoLuongBan = value; }
        }
        float _DonGiaBan;

        public float DonGiaBan
        {
            get { return _DonGiaBan; }
            set { _DonGiaBan = value; }
        }
        float _ThanhTien;

        public float ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }

        
    }
}
