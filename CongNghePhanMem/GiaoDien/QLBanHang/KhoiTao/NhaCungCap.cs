using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class NhaCungCap
    {
        string _MaNhaCungCap;

        public string MaNhaCungCap
        {
            get { return _MaNhaCungCap; }
            set { _MaNhaCungCap = value; }
        }
        string _TenNhaCungCap;

        public string TenNhaCungCap
        {
            get { return _TenNhaCungCap; }
            set { _TenNhaCungCap = value; }
        }
        string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        string _SoDienThoai;

        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }
        string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}
