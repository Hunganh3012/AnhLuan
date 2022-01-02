using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class ChiTietPhieuNhapHang
    {
        string _MaPhieuNhapHang;

        public string MaPhieuNhapHang
        {
            get { return _MaPhieuNhapHang; }
            set { _MaPhieuNhapHang = value; }
        }
        string _MaChiTietPMH;
        string _MaChiTietPNH;

        public string MaChiTietPNH
        {
            get { return _MaChiTietPNH; }
            set { _MaChiTietPNH = value; }
        }

        public string MaChiTietPMH
        {
            get { return _MaChiTietPMH; }
            set { _MaChiTietPMH = value; }
        }
        int _SoLuongNhap;

        public int SoLuongNhap
        {
            get { return _SoLuongNhap; }
            set { _SoLuongNhap = value; }
        }
    }
}
