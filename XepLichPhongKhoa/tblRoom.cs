using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichPhongKhoa
{
    class tblRoom
    {
        private string _IDRoom;
        private int _Maxsize;
        

        public string IDRoom
        {
            get
            {
                return _IDRoom;
            }
            set
            {
                _IDRoom = value;
            }
        }
        public int Maxsize
        {
            get
            {
                return _Maxsize;
            }
            set
            {
                _Maxsize = value;
            }
        }
        
    }
}
