using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class PhieuMuaHang
    {
        string _MaPhieuMuaHang;

        public string MaPhieuMuaHang
        {
            get { return _MaPhieuMuaHang; }
            set { _MaPhieuMuaHang = value; }
        }
        string _MaNhanVien;

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }

        string _MaNhaCungCap;

        public string MaNhaCungCap
        {
            get { return _MaNhaCungCap; }
            set { _MaNhaCungCap = value; }
        }
        DateTime _NgayDatMua;

        public DateTime NgayDatMua
        {
            get { return _NgayDatMua; }
            set { _NgayDatMua = value; }
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
        string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        float _ThanhToan;

        public float ThanhToan
        {
            get { return _ThanhToan; }
            set { _ThanhToan = value; }
        }
    }
}
