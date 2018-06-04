using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyPhongTro
{
    class RoomDetail
    {
        public RoomDetail(int _dienCu, int _nuocCu, int _tienPhong, int _dien, int _nuoc)
        {
            dienCu = _dienCu;
            nuocCu = _nuocCu;
            tienPhong = _tienPhong;
            dien = _dien;
            nuoc = _nuoc;
        }

        public RoomDetail()
        {

        }
        //public string ten
        //{
        //    get { return ten; }
        //    set { ten = value; }
        //}


        public int tienPhong;

        public int nuocCu;

        public int dien;
        public int nuoc;

        public int dienCu;

        public void AddRoom()
        {

        }

        public void RemoveRoom()
        {

        }
    }
}
