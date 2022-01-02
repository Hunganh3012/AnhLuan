using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class LoaiMatHang
    {
        string _MaLoaiMatHang;

        public string MaLoaiMatHang
        {
            get { return _MaLoaiMatHang; }
            set { _MaLoaiMatHang = value; }
        }
        string _TenLoaiMatHang;

        public string TenLoaiMatHang
        {
            get { return _TenLoaiMatHang; }
            set { _TenLoaiMatHang = value; }
        }
    }
}
