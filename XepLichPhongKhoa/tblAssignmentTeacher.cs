using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichPhongKhoa
{
    class tblAssignmentTeacher
    {
        private string _IDCourse;
        private string _IDUser;
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
        public string IDUser
        {
            get
            {
                return _IDUser;
            }
            set
            {
                _IDUser = value;
            }
        }
    }
}
