using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class GiaBan
    {
        string _MaMatHang;

        public string MaMatHang
        {
            get { return _MaMatHang; }
            set { _MaMatHang = value; }
        }
        string _MaDonGiaBan;

        public string MaDonGiaBan
        {
            get { return _MaDonGiaBan; }
            set { _MaDonGiaBan = value; }
        }
        float _DonGiaBan;

        public float DonGiaBan
        {
            get { return _DonGiaBan; }
            set { _DonGiaBan = value; }
        }
        DateTime _NgayThayDoi;

        public DateTime NgayThayDoi
        {
            get { return _NgayThayDoi; }
            set { _NgayThayDoi = value; }
        }
    }
}
