using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichPhongKhoa
{
    class tblCalendar
    {
        private DateTime _DateOf;
        private string _IDRoom;
        private string _IDCourse;
        public DateTime DateOf
        {
            get { return _DateOf; }
            set { _DateOf = value; }
        }
        public string IDRoom
        {
            get { return _IDRoom; }
            set { _IDRoom = value; }
        }
        public string IDCourse
        {
            get { return _IDCourse; }
            set { _IDCourse = value; }
        }
    }
}
