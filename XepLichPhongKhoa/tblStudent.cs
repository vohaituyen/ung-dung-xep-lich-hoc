using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichPhongKhoa
{
    class tblStudent
    {
        private string _IDStudent;
        private string _NameStudent;
        private string _CMNN;
        private string _Phone;
        private bool _Sex;
        private DateTime _BirthDay;
        private string _Gmail;
        private string _Address;

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

        public string NameStudent
        {
            get
            {
                return _NameStudent;
            }
            set
            {
                _NameStudent = value;
            }
        }

        public string CMNN
        {
            get
            {
                return _CMNN;
            }
            set
            {
                _CMNN = value;
            }
        }

        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }

        public bool Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }

        public DateTime BirthDay
        {
            get
            {
                return _BirthDay;
            }
            set
            {
                _BirthDay = value;
            }
        }

        public string Gmail
        {
            get
            {
                return _Gmail;
            }
            set
            {
                _Gmail = value;
            }
        }

        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
    }
}
