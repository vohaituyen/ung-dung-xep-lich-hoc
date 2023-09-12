using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLichPhongKhoa
{
    public class RoomStatus
    {
        private bool _th246=false;
        private bool _th357=false;
        private bool _cn=false;
        private string _NC246;
        private string _NC357;
        private string _NCCN;

        public bool th246
        {
            get { return _th246; }
            set { _th246 = value; }
        }
        public bool th357
        {
            get { return _th357; }
            set { _th357 = value; }
        }
        public bool cn
        {
            get { return _cn; }
            set { _cn = value; }
        }
        public string NC246
        {
            get { return _NC246; }
            set { _NC246=value; }
        }
        public string NC357
        {
            get { return _NC357; }
            set { _NC357 = value; }
        }
        public string NCCN
        {
            get { return _NCCN; }
            set { _NCCN = value; }
        }
        public RoomStatus()
        {
            _NC246 = null;
            _NC357 = null;
            _NCCN = null;
        }
    }
}
