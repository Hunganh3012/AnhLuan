using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class ChiTietPhieuMuaHang
    {
        string _MaCHiTietPMH;

        public string MaCHiTietPMH
        {
            get { return _MaCHiTietPMH; }
            set { _MaCHiTietPMH = value; }
        }
        string _MaPhieuMuaHang;

        public string MaPhieuMuaHang
        {
            get { return _MaPhieuMuaHang; }
            set { _MaPhieuMuaHang = value; }
        }
        string _MaMatHang;

        public string MaMatHang
        {
            get { return _MaMatHang; }
            set { _MaMatHang = value; }
        }
        float _DonGiaNhap;

        public float DonGiaNhap
        {
            get { return _DonGiaNhap; }
            set { _DonGiaNhap = value; }
        }
        int _SoLuongMua;

        public int SoLuongMua
        {
            get { return _SoLuongMua; }
            set { _SoLuongMua = value; }
        }
        float _ThanhTien;

        public float ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }
    }
}
