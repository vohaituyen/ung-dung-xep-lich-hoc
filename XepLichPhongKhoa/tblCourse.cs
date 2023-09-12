using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichPhongKhoa
{
    class tblCourse
    {
        private string _IDCourse;
        private string _NameCourse;
        private DateTime _DateBegin;
        private DateTime _DateEnd;
        private int _AvbNumber;
        private bool _OpenStatus;
        private bool _EndStatus;
        private string _SchoolDayType;
        private int _NoSW;

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

        public string NameCourse
        {
            get
            {
                return _NameCourse;
            }
            set
            {
                _NameCourse = value;
            }
        }

        public DateTime DateBegin
        {
            get
            {
                return _DateBegin;
            }
            set
            {
                _DateBegin = value;
            }
        }

        public DateTime DateEnd
        {
            get
            {
                return _DateEnd;
            }
            set
            {
                _DateEnd = value;
            }
        }

        public int AvbNumber
        {
            get
            {
                return _AvbNumber;
            }
            set
            {
                _AvbNumber = value;
            }
        }

        public bool OpenStatus
        {
            get
            {
                return _OpenStatus;
            }
            set
            {
                _OpenStatus = value;
            }
        }

        public bool EndStatus
        {
            get
            {
                return _EndStatus;
            }
            set
            {
                _EndStatus = value;
            }
        }

        public string SchoolDayType
        {
            get
            {
                return _SchoolDayType;
            }
            set
            {
                _SchoolDayType = value;
            }
        }

        public int NoSW
        {
            get
            {
                return _NoSW;
            }
            set
            {
                _NoSW = value;
            }
        }
    }
}
