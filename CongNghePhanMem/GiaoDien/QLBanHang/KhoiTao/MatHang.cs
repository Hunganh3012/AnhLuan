using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class MatHang
    {
        string _MaMatHang;

        public string MaMatHang
        {
            get { return _MaMatHang; }
            set { _MaMatHang = value; }
        }
        string _MaNhaCungCap;

        public string MaNhaCungCap
        {
            get { return _MaNhaCungCap; }
            set { _MaNhaCungCap = value; }
        }
        string _DonViTinh;

        public string DonViTinh
        {
            get { return _DonViTinh; }
            set { _DonViTinh = value; }
        }
        string _MaLoaiMatHang;

        public string MaLoaiMatHang
        {
            get { return _MaLoaiMatHang; }
            set { _MaLoaiMatHang = value; }
        }
        int _SoLuongTon;

        public int SoLuongTon
        {
            get { return _SoLuongTon; }
            set { _SoLuongTon = value; }
        }
        string _TenMatHang;

        public string TenMatHang
        {
            get { return _TenMatHang; }
            set { _TenMatHang = value; }
        }
        string _MoTa;

        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }
        private string _ThoiGianBaoHanh;

        public string ThoiGianBaoHanh
        {
            get { return _ThoiGianBaoHanh; }
            set { _ThoiGianBaoHanh = value; }
        }
    }
}
