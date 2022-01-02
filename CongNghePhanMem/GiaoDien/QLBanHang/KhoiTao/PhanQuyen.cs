using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNhaSach.KhoiTao
{
    public class PhanQuyen
    {
        string _MaPhanQuyen;

        public string MaPhanQuyen
        {
            get { return _MaPhanQuyen; }
            set { _MaPhanQuyen = value; }
        }
        string _MaNhom;

        public string MaNhom
        {
            get { return _MaNhom; }
            set { _MaNhom = value; }
        }
        string _MaManHinh;

        public string MaManHinh
        {
            get { return _MaManHinh; }
            set { _MaManHinh = value; }
        }
        Boolean _CoQuyen;

        public Boolean CoQuyen
        {
            get { return _CoQuyen; }
            set { _CoQuyen = value; }
        }
    }
}
