using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace XepLichPhongKhoa
{
    class ColorForCourse
    {
        private string _NameCourse;
        private Color _ColorCourse;
        public string NameCourse 
        {
            get { return _NameCourse; }
            set { _NameCourse = value; }
        }
        public Color ColorCourse
        {
            get { return _ColorCourse; }
            set { _ColorCourse = value; }
        }
        public ColorForCourse(string NameCourse, Color ColorCourse)
        {
            _NameCourse = NameCourse;
            _ColorCourse = ColorCourse;
        }
    }
}
