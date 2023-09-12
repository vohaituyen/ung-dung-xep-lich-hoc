using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichPhongKhoa
{
    class Account
    {
        private string _Username;
        private string _Password;
        private byte[] _Photo;
        private string _Name;
        private bool _Sex;
        private DateTime _Birthday;
        private bool _Premission;
        private string _Address;
        private string _Career;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public bool Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        public DateTime Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }
        public bool Premission
        {
            get { return _Premission; }
            set { _Premission = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string Career
        {
            get { return _Career; }
            set { _Career = value; }
        }

    }
}
