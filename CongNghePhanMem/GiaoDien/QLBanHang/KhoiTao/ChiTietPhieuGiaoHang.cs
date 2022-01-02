using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class ChiTietPhieuGiaoHang
    {
        string _MaChiTietHDBH;

        public string MaChiTietHDBH
        {
            get { return _MaChiTietHDBH; }
            set { _MaChiTietHDBH = value; }
        }
        string _MaPhieuGiaoHang;

        public string MaPhieuGiaoHang
        {
            get { return _MaPhieuGiaoHang; }
            set { _MaPhieuGiaoHang = value; }
        }
        int _SoLuongGiao;

        public int SoLuongGiao
        {
            get { return _SoLuongGiao; }
            set { _SoLuongGiao = value; }
        }

        float _ThanhTien;

        public float ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }
    }
}
