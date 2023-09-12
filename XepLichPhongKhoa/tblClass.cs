using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichPhongKhoa
{
    class tblClass
    {
        private string _IDCourse;
        private string _IDStudent;
        public string IDCourse
        {
            get
            {
                return _IDCourse;
            }
            set
            {
                _IDCourse = value;
            }
        }
        public string IDStudent
        {
            get
            {
                return _IDStudent;
            }
            set
            {
                _IDStudent = value;
            }
        }
    }
}
