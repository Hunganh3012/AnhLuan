using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class PhieuNhapHang
    {
        string _MaPhieuNhapHang;

        public string MaPhieuNhapHang
        {
            get { return _MaPhieuNhapHang; }
            set { _MaPhieuNhapHang = value; }
        }
        string _MaNhanVien;

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }
        int _LanNhap;

        public int LanNhap
        {
            get { return _LanNhap; }
            set { _LanNhap = value; }
        }
        DateTime _NgayNhapHang;

        public DateTime NgayNhapHang
        {
            get { return _NgayNhapHang; }
            set { _NgayNhapHang = value; }
        }
        float _TongTien;

        public float TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }
        float _ThanhToan;

        public float ThanhToan
        {
            get { return _ThanhToan; }
            set { _ThanhToan = value; }
        }
        string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }

      
    }
}
