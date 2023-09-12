using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XepLichPhongKhoa
{
    public partial class AddStuToCou : Form
    {
        private CourseDAL bllcourse = new CourseDAL();
        private ClassDAL bllclass = new ClassDAL();
        private string IDStudent;
        private int gb_index = 0;
        public AddStuToCou(string _IDStudent)
        {
            InitializeComponent();
            IDStudent = _IDStudent;
            LoadCOS();
        }
        public AddStuToCou(string _IDCourse, int i)
        {
            InitializeComponent();
            label7.Text = "Học viên";
            btnAddCouToStu.Hide();
            panel32.Visible = false;
            dtgvCourseOfStu.DataSource = bllcourse.getCourse3(_IDCourse);
        }
        public AddStuToCou(string UserName, int i, int k)
        {
            InitializeComponent();
            label7.Text = "Lớp học của bạn";
            btnAddCouToStu.Hide();
            panel32.Visible = false;
            dtgvCourseOfStu.DataSource = bllcourse.getCourseForUser(UserName);
        }
        public void LoadCOS()
        {
            dtgvCourseOfStu.DataSource = bllcourse.getCourse2();
            LockControl();
        }

        //private void pbInsertPhoto_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnCancel_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnSaveUser_Click(object sender, EventArgs e)
        //{

        //}

        public void LockControl()
        {
            btnAddCouToStu.Enabled = false;
        }
        public void UnLockControl()
        {
            btnAddCouToStu.Enabled = true;
        }

        private void TbSearchS_TextChanged(object sender, EventArgs e)
        {
            string str = tbSearchS.Text;
            if (!string.IsNullOrEmpty(str))
            {
                DataTable data = bllcourse.FindCourse2(str);
                dtgvCourseOfStu.DataSource = data;
            }
            else
            {
                LoadCOS();
                LockControl();
            }
        }

        private void DtgvCourseOfStu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gb_index = e.RowIndex;
            UnLockControl();
        }

        private void BtnAddCouToStu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm khóa học này ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tblClass cl = new tblClass();
                cl.IDStudent = IDStudent;
                cl.IDCourse = dtgvCourseOfStu.Rows[gb_index].Cells[0].Value.ToString();
                if (!bllclass.CheckClass(cl))
                {
                    MessageBox.Show("Học viên đã đăng ký khóa học này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (bllclass.InsertIntoClass(cl))
                {
                    bllcourse.UpdateAvbNumber(cl.IDCourse, 1);
                    tbSearchS.Clear();
                    LockControl();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        
    }
}
