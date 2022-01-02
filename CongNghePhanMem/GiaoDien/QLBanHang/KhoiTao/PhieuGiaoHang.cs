using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class PhieuGiaoHang
    {
        string _MaPhieuGiao;

        public string MaPhieuGiao
        {
            get { return _MaPhieuGiao; }
            set { _MaPhieuGiao = value; }
        }
        string _MaNhanVien;

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }
        string _MaKhacHang;

        public string MaKhacHang
        {
            get { return _MaKhacHang; }
            set { _MaKhacHang = value; }
        }
        int _LanGiao;

        public int LanGiao
        {
            get { return _LanGiao; }
            set { _LanGiao = value; }
        }
        DateTime _NgayGiao;

        public DateTime NgayGiao
        {
            get { return _NgayGiao; }
            set { _NgayGiao = value; }
        }
        string _DiaChiGiao;

        public string DiaChiGiao
        {
            get { return _DiaChiGiao; }
            set { _DiaChiGiao = value; }
        }
        string _SoDienThoai;

        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }
        float _TongTien;

        public float TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }
        float _ThanhToanSau;

        public float ThanhToanSau
        {
            get { return _ThanhToanSau; }
            set { _ThanhToanSau = value; }
        }
        string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    }
}
