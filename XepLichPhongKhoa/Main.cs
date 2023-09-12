using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using OfficeOpenXml;

namespace XepLichPhongKhoa
{
    public partial class fMain : Form
    {
        /// <summary>
        /// Properties
        /// </summary>
        private RoomDAL bllroom = new RoomDAL();
        private CourseDAL bllcourse = new CourseDAL();
        private AccountDAL bllaccount = new AccountDAL();
        private CalendarDAL bllcalendar = new CalendarDAL();
        private AssignmentTeacherDAL bllams = new AssignmentTeacherDAL();
        private StudentDAL bllstudent = new StudentDAL();
        private ClassDAL bllclass = new ClassDAL();
        private Schedule c;
        private RoomStatus[,] rs;
        private int week = 0;
        private DateTime dayTemp;
        private Panel[] pnarr;
        private string UserName;
        private int Prem;
        private ColorForCourse[] courarr;
        private int gb_index = 0;
        /// <summary>
        /// Method
        /// </summary>
        public fMain()
        {
            InitializeComponent();
            //LoadUserInfo();
            //LoadRoom();
            //LoadCourse();

        }
        public fMain(int p, string username)
        {
            UserName = username;
            Prem = p;
            InitializeComponent();
            LockControl();
            LoadRoom();
            courarr = new ColorForCourse[bllcourse.getCourse().Rows.Count];
            LoadColorCourse();
            pnarr = new Panel[bllroom.getRoom().Rows.Count];
            c = new Schedule(bllroom.getRoom(), bllcourse.getCourse());
            rs = c.SolveSchedule(0);
            dayTemp = c.dateStart;
            addRoomForm();
            LoadCbbSort();
            cbbSort.SelectedIndex = 0;
            LoadCbbSearch();
            LoadCbbCourse();
            LoadCourse();
            LoadStudent();
            LoadUserInfo();
            if (Prem == 1)
            {
                tabControl1.TabPages.Remove(tabStudent);
            }
            //courarr = new ColorForCourse[bllcourse.getCourse().Rows.Count];
            //LoadColorCourse();

        }

        #region Room

        public void LoadRoom()
        {
            LockControl();
            dtgvRoom.DataSource = bllroom.getRoom();
        }

        public void LockControl()
        {
            btnAdd.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            //btnSearchRoom.Enabled = false;
            btnCancel.Enabled = false;
            tbIDRoom.ReadOnly = true;
            tbNumber.ReadOnly = true;
            tbIDRoom.Text = null;
            tbNumber.Text = null;
            if (Prem == 1)
            {
                btnAdd.Enabled = false;
            }
            //tbSearchRoom.Text = null;
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(tbIDRoom.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã phòng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbIDRoom.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbNumber.Text))
            {
                MessageBox.Show("Bạn chưa nhập Sĩ số tối đa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNumber.Focus();
                return false;
            }
            return true;
        }

        private void dtgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LockControl();
            int index = e.RowIndex;
            if (index >= 0)
            {
                tbIDRoom.Text = dtgvRoom.Rows[index].Cells[0].Value.ToString();
                tbNumber.Text = dtgvRoom.Rows[index].Cells[1].Value.ToString();
            }
            if (Prem == 0)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }

            //btnAdd.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            tbIDRoom.ReadOnly = false;
            tbNumber.ReadOnly = false;
            tbSearchRoom.ReadOnly = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            tbIDRoom.Text = null;
            tbNumber.Text = null;
            tbIDRoom.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn phòng này ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblRoom room = new tblRoom();
                room.IDRoom = tbIDRoom.Text;
                bllcalendar.DeleteCalendar();
                if (bllroom.DeleteRoom(room))
                {
                    LoadSchedule();
                    LoadCourse();
                    if (string.IsNullOrEmpty(tbSearchRoom.Text))
                    {
                        LoadRoom();
                    }
                    else
                    {
                        LoadRoom();
                        tbSearchRoom_TextChanged(sender, e);
                    }
                    LockControl();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            //tbIDRoom.ReadOnly = false;
            tbNumber.ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (btnAdd.Enabled == true)
            {
                if (CheckData())
                {
                    tblRoom room = new tblRoom();
                    room.IDRoom = tbIDRoom.Text;
                    room.Maxsize = Int32.Parse(tbNumber.Text);
                    if (bllroom.InsertRoom(room))
                    {
                        LoadSchedule();
                        LoadCourse();
                        if (string.IsNullOrEmpty(tbSearchRoom.Text))
                        {
                            LoadRoom();
                        }
                        else
                        {
                            LoadRoom();
                            tbSearchRoom_TextChanged(sender, e);
                        }

                        LockControl();
                        btnAdd_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại mã phòng này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }

            if (btnEdit.Enabled == true)
            {
                if (CheckData())
                {
                    tblRoom room = new tblRoom();
                    room.IDRoom = tbIDRoom.Text;
                    room.Maxsize = Int32.Parse(tbNumber.Text);
                    if (bllroom.UpdateRoom(room))
                    {
                        LoadSchedule();
                        LoadCourse();
                        if (string.IsNullOrEmpty(tbSearchRoom.Text))
                        {
                            LoadRoom();
                        }
                        else
                        {
                            LoadRoom();
                            tbSearchRoom_TextChanged(sender, e);
                        }
                        LockControl();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //LoadRoom();
            LockControl();
        }

        private void tbSearchRoom_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            tbIDRoom.ReadOnly = false;
            tbNumber.ReadOnly = false;
            btnCancel.Enabled = true;
            string str = tbSearchRoom.Text;
            if (!string.IsNullOrEmpty(str))
            {
                DataTable data = bllroom.FindRoom(str);
                dtgvRoom.DataSource = data;
                if (dtgvRoom.RowCount > 1)
                {
                    tbIDRoom.ReadOnly = true;
                    tbNumber.ReadOnly = true;
                    tbIDRoom.Text = dtgvRoom.Rows[0].Cells[0].Value.ToString();
                    tbNumber.Text = dtgvRoom.Rows[0].Cells[1].Value.ToString();
                    if (Prem == 0)
                    {
                        btnDelete.Enabled = true;
                        btnEdit.Enabled = true;
                    }
                }
            }
            else
            {
                LoadRoom();
                LockControl();
            }

        }

        #endregion

        #region Course
        public void LoadCourse()
        {
            LoadSchedule();
            //bllcourse = new CourseDAL();
            dtgvCourse.DataSource = bllcourse.getCourse();
            tbSumC.Text = bllcourse.countCourse().ToString();
            tbSumCEnd.Text = bllcourse.countCourseEnd().ToString();
            int n = 0;
            foreach (DataRow row in bllcourse.getCourse().Rows)
            {
                if (!string.IsNullOrEmpty(row[3].ToString()))
                {
                    DateTime temp1 = new DateTime();
                    temp1 = DateTime.Parse(row[3].ToString());
                    if (temp1 < DateTime.Today && temp1 > new DateTime(2000,1,1))
                    {
                        n++;
                    }
                }
            }
            tbSumCEnd.Text = n.ToString();
            LockControlCourse();
        }
        //public void updateCourse()
        //{
        //    tblCourse course = new tblCourse();
        //    if (course.AvbNumber > 15) course.OpenStatus = true;
        //    else course.OpenStatus = false;
        //    bllcourse.UpdateStatus(course.OpenStatus);
        //}
        private void dtgvCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cbbSchoolDayType.Enabled = false;
            //tbAvbNumber.Enabled = false;
            LockControlCourse();
            btnView.Enabled = true;
            int index = e.RowIndex;
            if (index >= 0)
            {
                if (Prem == 0)
                {
                    btnEditC.Enabled = true;
                    btnDeleteC.Enabled = true;
                }
                tbIDCourse.Text = dtgvCourse.Rows[index].Cells[0].Value.ToString();
                tbNameCourse.Text = dtgvCourse.Rows[index].Cells[1].Value.ToString();
                CultureInfo viVn = new CultureInfo("vi-VN");
                dtpDateBegin.Text = dtgvCourse.Rows[index].Cells[2].Value.ToString();
                if (string.IsNullOrEmpty(dtgvCourse.Rows[index].Cells[3].Value.ToString()))
                {
                    tbDateEnd.ReadOnly = true;
                }
                else
                {
                    DateTime temp1 = new DateTime();
                    temp1 = DateTime.Parse(dtgvCourse.Rows[index].Cells[3].Value.ToString());
                    tbDateEnd.Text = temp1.Date.ToShortDateString();
                }

                tbAvbNumber.Text = dtgvCourse.Rows[index].Cells[4].Value.ToString();
                if (dtgvCourse.Rows[index].Cells[5].Value.ToString() == "True")
                {
                    tbStatus.Text = "Có thể mở lớp";
                }
                else
                {
                    tbStatus.Text = "Chưa mở lớp";
                }
                if (!string.IsNullOrEmpty(dtgvCourse.Rows[index].Cells[3].Value.ToString()))
                {
                    DateTime temp1,temp3 = new DateTime();
                    temp1 = DateTime.Parse(dtgvCourse.Rows[index].Cells[3].Value.ToString());
                    temp3 = DateTime.Parse(dtgvCourse.Rows[index].Cells[2].Value.ToString());
                    DateTime temp2 = new DateTime(2000,1,1);
                    if (temp1 == temp2)
                    {
                        tbStatus.Text = "Không có phòng phù hợp";
                    }
                    else if (temp1 < DateTime.Today)
                    {
                        tbStatus.Text = "Đã kết thúc";
                    }
                    if (temp3 < DateTime.Today && temp1 > DateTime.Today) tbStatus.Text = "Đang học";
                }
                cbbSchoolDayType.Text = dtgvCourse.Rows[index].Cells[6].Value.ToString();
                tbNoSW.Text = dtgvCourse.Rows[index].Cells[7].Value.ToString();
                cbbTeacher.Text = dtgvCourse.Rows[index].Cells[8].Value.ToString();
            }
        }
        public bool CheckDataCourse()
        {
            if (string.IsNullOrEmpty(tbIDCourse.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã phòng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbIDCourse.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbNameCourse.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên khóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNameCourse.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtpDateBegin.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày bắt đầu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpDateBegin.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbTeacher.Text))
            {
                MessageBox.Show("Bạn chưa chọn giáo viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbTeacher.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(tbAvbNumber.Text))
            //{
            //    MessageBox.Show("Bạn chưa nhập Mã phòng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tbAvbNumber.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(cbbSchoolDayType.Text))
            {
                MessageBox.Show("Bạn chưa nhập hình thức học !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbSchoolDayType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbNoSW.Text))
            {
                MessageBox.Show("Bạn chưa nhập số tuần học !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNoSW.Focus();
                return false;
            }
            return true;
        }
        public void ClearControlCourse()
        {
            tbIDCourse.Text = null;
            tbNameCourse.Text = null;
            tbAvbNumber.Text = null;
            tbNoSW.Text = null;
            cbbTeacher.Text = null;
            tbStatus.Text = null;
        }
        private void LockControlCourse()
        {
            if (Prem == 1)
            {
                btnAddC.Enabled = false;
            }
            else btnAddC.Enabled = true;
            tbIDCourse.ReadOnly = true;
            tbNameCourse.ReadOnly = true;
            //tbAvbNumber.ReadOnly = true;
            tbNoSW.ReadOnly = true;
            tbStatus.ReadOnly = true;
            tbDateEnd.ReadOnly = true;
            dtpDateBegin.Enabled = false;
            cbbSchoolDayType.Enabled = false;
            cbbTeacher.Enabled = false;
            btnCancelC.Enabled = false;
            btnDeleteC.Enabled = false;
            btnEditC.Enabled = false;
            btnSaveC.Enabled = false;
            btnView.Enabled = false;
            cbbTeacher.Items.Clear();
        }
        private void UnLockControlCourse()
        {
            tbIDCourse.ReadOnly = false;
            tbNameCourse.ReadOnly = false;
            //tbAvbNumber.ReadOnly = false;
            tbNoSW.ReadOnly = false;
            dtpDateBegin.Enabled = true;
            cbbSchoolDayType.Enabled = true;
            cbbSchoolDayType.Enabled = true;
            btnView.Enabled = true;
        }
        private void LoadCbbTeacher()
        {
            cbbTeacher.Enabled = true;
            AccountDAL account = new AccountDAL();
            DataTable dUser = account.getAccount();
            for(int i = 0; i < dUser.Rows.Count; i++)
            {
                cbbTeacher.Items.Add(dUser.Rows[i].ItemArray[2]);
            }
        }
        private void btnAddC_Click(object sender, EventArgs e)
        {
            ClearControlCourse();
            UnLockControlCourse();
            LoadCbbTeacher();
            //btnAddC.Enabled = false;
            btnEditC.Enabled = false;
            btnDeleteC.Enabled = false;
            btnCancelC.Enabled = true;
            btnSaveC.Enabled = true;
            tbIDCourse.Focus();
        }

        private void btnSaveC_Click(object sender, EventArgs e)
        {
            AccountDAL account = new AccountDAL();
            DataTable dUser = account.getAccount();
            if (btnAddC.Enabled == true)
            {
                if (CheckDataCourse())
                {
                    tblCourse course = new tblCourse();
                    tblAssignmentTeacher ams = new tblAssignmentTeacher();
                    //
                    ams.IDCourse = tbIDCourse.Text;
                    if (cbbTeacher.SelectedIndex >= 0) ams.IDUser = dUser.Rows[cbbTeacher.SelectedIndex].ItemArray[0].ToString();
                    else ams.IDUser = "";
                    course.IDCourse = tbIDCourse.Text;
                    course.NameCourse = tbNameCourse.Text;
                    course.DateBegin = dtpDateBegin.Value;
                    if(string.IsNullOrEmpty(tbAvbNumber.Text)) course.AvbNumber = 0;
                    course.SchoolDayType = cbbSchoolDayType.Text;
                    course.NoSW = Int32.Parse(tbNoSW.Text);                   
                    if (bllcourse.InsertCourse(course))
                    {
                        bllams.InsertASM(ams);
                        LoadSchedule();
                        LoadCourse();
                        LoadStudent();
                        if (string.IsNullOrEmpty(tbSearchC.Text))
                        {
                            LoadCourse();
                        }
                        else
                        {
                            LoadCourse();
                            tbSearchC_TextChanged(sender, e);
                        }
                        LockControlCourse();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            if (btnEditC.Enabled == true)
            {
                if (CheckDataCourse())
                {
                    tblCourse course = new tblCourse();
                    tblAssignmentTeacher ams = new tblAssignmentTeacher();
                    //
                    ams.IDCourse = tbIDCourse.Text;
                    if (cbbTeacher.SelectedIndex >= 0) ams.IDUser = dUser.Rows[cbbTeacher.SelectedIndex].ItemArray[0].ToString();
                    else ams.IDUser = "-1";
                    //
                    course.IDCourse = tbIDCourse.Text;
                    course.NameCourse = tbNameCourse.Text;
                    course.DateBegin = dtpDateBegin.Value;
                    if (string.IsNullOrEmpty(tbAvbNumber.Text)) course.AvbNumber = 0;
                    if (course.AvbNumber > 15) course.OpenStatus = true;
                    else course.OpenStatus = false;
                    course.SchoolDayType = cbbSchoolDayType.Text;
                    course.NoSW = Int32.Parse(tbNoSW.Text);
                    if (bllcourse.UpdateCourse(course))
                    {
                        if (ams.IDUser != "-1") bllams.UpdateASMUser(ams);
                        LoadSchedule();
                        LoadCourse();
                        if (string.IsNullOrEmpty(tbSearchC.Text))
                        {
                            LoadCourse();
                        }
                        else
                        {
                            LoadStudent();
                            LoadCourse();
                            tbSearchC_TextChanged(sender, e);
                        }
                        LockControlCourse();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra !" + ams.IDCourse + ams.IDUser, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

            }
        }

        private void btnCalcelC_Click(object sender, EventArgs e)
        {
            ClearControlCourse();
            LockControlCourse();
        }

        private void tbSearchC_TextChanged(object sender, EventArgs e)
        {
            string str = tbSearchC.Text;
            if (!string.IsNullOrEmpty(str))
            {
                DataTable data = bllcourse.FindCourse(str);
                dtgvCourse.DataSource = data;
                if (dtgvCourse.RowCount == 1)
                {
                    tbSumC.Text = "0";
                    tbSumCEnd.Text = "0";
                }
                if (dtgvCourse.RowCount > 1)
                {
                    tbIDCourse.Text = dtgvCourse.Rows[0].Cells[0].Value.ToString();
                    tbNameCourse.Text = dtgvCourse.Rows[0].Cells[1].Value.ToString();
                    dtpDateBegin.Text = dtgvCourse.Rows[0].Cells[2].Value.ToString();
                    if (string.IsNullOrEmpty(dtgvCourse.Rows[0].Cells[3].Value.ToString()))
                    {
                        tbDateEnd.ReadOnly = true;
                    }
                    else
                    {
                        tbDateEnd.Text = dtgvCourse.Rows[0].Cells[3].Value.ToString();
                    }

                    tbAvbNumber.Text = dtgvCourse.Rows[0].Cells[4].Value.ToString();
                    if (dtgvCourse.Rows[0].Cells[5].Value.ToString() == "True")
                    {
                        tbStatus.Text = "Có thể mở lớp";
                    }
                    else
                    {
                        tbStatus.Text = "Chưa mở lớp";
                    }
                    if (dtgvCourse.Rows[0].Cells[5].Value.ToString() == "True")
                    {
                        tbStatus.Text = "Đã kết thúc";
                    }
                    cbbSchoolDayType.Text = dtgvCourse.Rows[0].Cells[6].Value.ToString();
                    tbNoSW.Text = dtgvCourse.Rows[0].Cells[7].Value.ToString();
                    cbbTeacher.Text = dtgvCourse.Rows[0].Cells[8].Value.ToString();
                    if (Prem == 0)
                    {
                        btnEditC.Enabled = true;
                        btnDeleteC.Enabled = true;
                        btnCancelC.Enabled = true;
                    }
                    tbSumC.Text = (dtgvCourse.RowCount - 1).ToString();
                    int s = 0;
                    foreach (DataRow row in data.Rows)
                    {
                        if (row[6].ToString() == "True")
                        {
                            s += 1;
                        }
                    }
                    tbSumCEnd.Text = s.ToString();
                }
            }
            else
            {
                LoadCourse();
                LockControlCourse();
            }

        }

        private void btnEditC_Click(object sender, EventArgs e)
        {
            UnLockControlCourse();
            tbIDCourse.ReadOnly = true;
            btnCancelC.Enabled = true;
            btnSaveC.Enabled = true;
            btnAddC.Enabled = false;
            btnDeleteC.Enabled = false;
            LoadCbbTeacher();
        }

        private void btnDeleteC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn khóa học này ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblCourse course = new tblCourse();
                course.IDCourse = tbIDCourse.Text;
                bllcalendar.DeleteCalendar();
                bllams.DeleteASMCourse(course.IDCourse);
                bllclass.DeleteCourseOfClass(course.IDCourse);
                if (bllcourse.DeleteCourse(course))
                {
                    LoadSchedule();
                    LoadCbbCourse();
                    if (string.IsNullOrEmpty(tbSearchC.Text))
                    {
                        LoadCourse();
                    }
                    else
                    {
                        LoadCourse();
                        tbSearchC_TextChanged(sender, e);
                    }
                    LockControlCourse();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }

        #endregion

        #region Student
        public void LoadStudent()
        {
            dtgvStudent.DataSource = bllstudent.getStudent();
            tbNumberStu.Text = bllstudent.countStudent().ToString();
            LockControlStudent();
        }
        public void ClearControlStudent()
        {
            tbIDS.Text = null;
            tbNameS.Text = null;
            tbCMNNS.Text = null;
            tbSDTS.Text = null;
            tbGmailS.Text = null;
            tbARS.Text = null;
        }
        private void LockControlStudent()
        {
            if (Prem == 1)
            {
                btnAddS.Enabled = false;
            }
            else btnAddS.Enabled = true;
            tbIDS.ReadOnly = true;
            tbNameS.ReadOnly = true;
            tbCMNNS.ReadOnly = true;
            cbbSexS.Enabled = false;
            dtpkS.Enabled = false;
            tbGmailS.ReadOnly = true;
            tbARS.ReadOnly = true;
            btnCancelS.Enabled = false;
            btnDeleteS.Enabled = false;
            btnEditS.Enabled = false;
            btnSaveS.Enabled = false;
            btnAddCFS.Enabled = false;
            btnCancelAdd.Enabled = false;
            btnView.Enabled = false;
        }
        private void UnLockControlStudent()
        {
            tbIDS.ReadOnly = false;
            tbNameS.ReadOnly = false;
            tbCMNNS.ReadOnly = false;
            cbbSexS.Enabled = true;
            tbGmailS.ReadOnly = false;
            tbARS.ReadOnly = false;
            dtpkS.Enabled = true;
            btnView.Enabled = true;
        }
        public bool CheckDataStudent()
        {
            if (string.IsNullOrEmpty(tbIDS.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã học viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbIDS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbNameS.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên học viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNameS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbCMNNS.Text))
            {
                MessageBox.Show("Bạn chưa nhập CMNN/ CCCD !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbCMNNS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbGmailS.Text))
            {
                MessageBox.Show("Bạn chưa nhập Gmail !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbGmailS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbARS.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbARS.Focus();
                return false;
            }
            return true;
        }
        private void DtgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LockControlStudent();
            btnAddCFS.Enabled = true;
            int index = e.RowIndex;
            if (index >= 0)
            {
                if (Prem == 0)
                {
                    btnEditS.Enabled = true;
                    btnDeleteS.Enabled = true;
                }
                tbIDS.Text = dtgvStudent.Rows[index].Cells[0].Value.ToString();
                tbNameS.Text = dtgvStudent.Rows[index].Cells[1].Value.ToString();
                tbCMNNS.Text = dtgvStudent.Rows[index].Cells[2].Value.ToString();
                tbSDTS.Text = dtgvStudent.Rows[index].Cells[3].Value.ToString();
                tbGmailS.Text = dtgvStudent.Rows[index].Cells[6].Value.ToString();
                tbARS.Text = dtgvStudent.Rows[index].Cells[7].Value.ToString();
                CultureInfo viVn = new CultureInfo("vi-VN");
                dtpkS.Text = dtgvStudent.Rows[index].Cells[5].Value.ToString();
                cbbSexS.Text = dtgvStudent.Rows[index].Cells[4].Value.ToString() == "True" ? "Nam" : "Nữ";            
                dtgvCourseOfStu.DataSource = bllclass.getCourseOfStudent(tbIDS.Text);
            }
        }

        private void BtnAddS_Click(object sender, EventArgs e)
        {
            ClearControlStudent();
            UnLockControlStudent();
            btnEditS.Enabled = false;
            btnDeleteS.Enabled = false;
            btnCancelS.Enabled = true;
            btnSaveS.Enabled = true;
            tbIDS.Focus();
        }

        private void BtnSaveS_Click(object sender, EventArgs e)
        {
            AccountDAL account = new AccountDAL();
            DataTable dUser = account.getAccount();
            if (btnAddS.Enabled == true)
            {
                if (CheckDataStudent())
                {
                    tblStudent student = new tblStudent();
                    student.IDStudent= tbIDS.Text;
                    student.NameStudent = tbNameS.Text;
                    student.CMNN = tbCMNNS.Text;
                    student.Phone = tbSDTS.Text;
                    student.Sex = (cbbSexS.Text == "Nam") ? true : false;
                    student.BirthDay = dtpkS.Value;
                    student.Gmail = tbGmailS.Text;
                    student.Address = tbARS.Text;
                    if (bllstudent.InsertStudent(student))
                    {
                        LoadSchedule();
                        LoadCourse();
                        LoadStudent();
                        if (string.IsNullOrEmpty(tbSearchS.Text))
                        {
                            LoadStudent();
                        }
                        else
                        {
                            LoadStudent();
                            TbSearchS_TextChanged(sender, e);
                        }
                        LockControlStudent();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            if (btnEditS.Enabled == true)
            {
                if (CheckDataStudent())
                {
                    tblStudent student = new tblStudent();
                    student.IDStudent = tbIDS.Text;
                    student.NameStudent = tbNameS.Text;
                    student.CMNN = tbCMNNS.Text;
                    student.Phone = tbSDTS.Text;
                    student.Sex = (cbbSexS.Text == "Nam") ? true : false;
                    student.BirthDay = dtpkS.Value;
                    student.Gmail = tbGmailS.Text;
                    student.Address = tbARS.Text;
                    if (bllstudent.UpdateStudent(student))
                    {
                        LoadSchedule();
                        LoadCourse();
                        LoadStudent();
                        if (string.IsNullOrEmpty(tbSearchS.Text))
                        {
                            LoadStudent();
                        }
                        else
                        {
                            LoadStudent();
                            TbSearchS_TextChanged(sender, e);
                        }
                        LockControlStudent();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

            }
        }

        private void BtnCancelS_Click(object sender, EventArgs e)
        {
            ClearControlStudent();
            LockControlStudent();
        }

        private void TbSearchS_TextChanged(object sender, EventArgs e)
        {
            string str = tbSearchS.Text;
            if (!string.IsNullOrEmpty(str))
            {
                DataTable data = bllstudent.FindStudent(str);
                dtgvStudent.DataSource = data;
                if (dtgvStudent.RowCount > 1)
                {
                    tbIDS.Text = dtgvStudent.Rows[0].Cells[0].Value.ToString();
                    tbNameS.Text = dtgvStudent.Rows[0].Cells[1].Value.ToString();
                    tbCMNNS.Text = dtgvStudent.Rows[0].Cells[2].Value.ToString();
                    tbSDTS.Text = dtgvStudent.Rows[0].Cells[3].Value.ToString();
                    tbGmailS.Text = dtgvStudent.Rows[0].Cells[6].Value.ToString();
                    tbARS.Text = dtgvStudent.Rows[0].Cells[7].Value.ToString();
                    CultureInfo viVn = new CultureInfo("vi-VN");
                    dtpkS.Text = dtgvStudent.Rows[0].Cells[5].Value.ToString();
                    cbbSexS.Text = dtgvStudent.Rows[0].Cells[4].Value.ToString() == "True" ? "Nam" : "Nữ";
                    if (Prem == 0)
                    {
                        btnEditC.Enabled = true;
                        btnDeleteC.Enabled = true;
                        btnCancelC.Enabled = true;
                    }
                    tbNumberStu.Text = (dtgvStudent.RowCount - 1).ToString();
                }
            }
            else
            {
                LoadStudent();
                LockControlStudent();
            }
        }
        private void BtnEditS_Click(object sender, EventArgs e)
        {
            UnLockControlStudent();
            tbIDS.ReadOnly = true;
            btnCancelS.Enabled = true;
            btnSaveS.Enabled = true;
            btnAddS.Enabled = false;
            btnDeleteS.Enabled = false;
        }
        private void BtnDeleteS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa học viên này ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblStudent student = new tblStudent();
                student.IDStudent = tbIDS.Text;
                for (int i = 0; i < dtgvCourseOfStu.Rows.Count - 1; i++)
                {
                    tblClass cl = new tblClass();
                    cl.IDCourse = dtgvCourseOfStu.Rows[i].Cells[0].Value.ToString();
                    cl.IDStudent = student.IDStudent;
                    bllclass.DeleteStuOfClass(cl);
                    bllcourse.UpdateAvbNumber(dtgvCourseOfStu.Rows[i].Cells[0].Value.ToString(), -1);
                }
                if (bllstudent.DeleteStudent(student))
                {                 
                        if (string.IsNullOrEmpty(tbSearchC.Text))
                    {
                        LoadStudent();
                    }
                    else
                    {
                        LoadStudent();
                        TbSearchS_TextChanged(sender, e);
                    }
                    LoadCourse();
                    LockControlStudent();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void BtnAddCFS_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStuToCou f = new AddStuToCou(tbIDS.Text);
            f.ShowDialog();
            this.Show();
            dtgvCourseOfStu.DataSource = bllclass.getCourseOfStudent(tbIDS.Text);
            LoadCourse();
        }

        private void TbNumberStu_TextChanged(object sender, EventArgs e)
        {

        }

        private void DtgvCourseOfStu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCancelAdd.Enabled = true;
            gb_index = e.RowIndex;
        }
        private void BtnCancelAdd_Click(object sender, EventArgs e)
        {
            tblClass cl = new tblClass();
            cl.IDCourse = dtgvCourseOfStu.Rows[gb_index].Cells[0].Value.ToString();
            cl.IDStudent = tbIDS.Text;
            if (bllclass.DeleteStuOfClass(cl))
            {
                bllcourse.UpdateAvbNumber(cl.IDCourse, -1);
                btnCancelAdd.Enabled = false;
                dtgvCourseOfStu.DataSource = bllclass.getCourseOfStudent(cl.IDStudent);
                MessageBox.Show("Hủy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                LoadCourse();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region User

        private byte[] ImageToByte(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }

        private Image ByteToImage(byte[] p)
        {
            MemoryStream m = new MemoryStream(p);
            return Image.FromStream(m);
        }

        private void LoadUserInfo()
        {
            LockControlUser();
            AccountDAL acc = new AccountDAL();
            DataTable data = bllaccount.getUser(UserName);
            if (!string.IsNullOrEmpty(data.Rows[0][0].ToString()))
            {
                byte[] p = (byte[])data.Rows[0][0];
                pbUser.Image = ByteToImage(p);
            }
            //tbName.Text = data.Rows[0][0].ToString();
            lbAccName.Text = data.Rows[0][1].ToString();
            tbName.Text = data.Rows[0][1].ToString();
            cbbSex.Text = data.Rows[0][2].ToString() == "True" ? "Nam" : "Nữ";
            dtpBirthday.Text = data.Rows[0][3].ToString();
            tbCareer.Text = data.Rows[0][6].ToString();
            tbAddress.Text = data.Rows[0][5].ToString();
        }

        private void LockControlUser()
        {
            tbName.ReadOnly = true;
            tbAddress.ReadOnly = true;
            tbCareer.ReadOnly = true;
            cbbSex.Enabled = false;
            dtpBirthday.Enabled = false;
            btnSaveUser.Enabled = false;
            pbUser.Enabled = false;
            if (Prem == 1)
            {
                btnAddUser.Enabled = false;
            }
        }

        private void UnLockControlUser()
        {
            tbName.ReadOnly = false;
            tbAddress.ReadOnly = false;
            tbCareer.ReadOnly = false;
            cbbSex.Enabled = true;
            dtpBirthday.Enabled = true;
            btnSaveUser.Enabled = true;
            pbUser.Enabled = true;
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            tbName.BackColor = Color.White;
            tbAddress.BackColor = Color.White;
            cbbSex.BackColor = Color.White;
            tbCareer.BackColor = Color.White;
            dtpBirthday.Enabled = true;
            btnSaveUser.Enabled = true;
            UnLockControlUser();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            fInsertAcc f = new fInsertAcc();
            f.ShowDialog();
            this.Show();
        }

        private void pbUser_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbUser.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.Username = UserName;
            acc.Name = tbName.Text;
            if (cbbSex.Text == "Nam") acc.Sex = true;
            else acc.Sex = false;
            acc.Birthday = dtpBirthday.Value;
            acc.Career = tbCareer.Text;
            acc.Address = tbAddress.Text;
            acc.Photo = ImageToByte(pbUser.Image);
            if (bllaccount.UpdateAccountDAL(acc))
            {
                MessageBox.Show("Đã sửa thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserInfo();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra ??? !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Schedule

        private void LoadColorCourse()
        {
            Random rand = new Random();
            for (int i = 0; i < courarr.Length; i++)
            {
                courarr[i] = new ColorForCourse(bllcourse.getCourse().Rows[i][0].ToString(), Color.FromArgb(rand.Next(100, 254), rand.Next(100, 254), rand.Next(100, 254)));
            }
        }

        private void LoadSchedule()
        {
            ClearSchedule();
            c = new Schedule(bllroom.getRoom(), bllcourse.getCourse());
            rs = c.SolveSchedule(cbbSort.SelectedIndex);
            pnarr = new Panel[bllroom.getRoom().Rows.Count];
            //c = new Schedule(bllroom.getRoom(), bllcourse.getCourse());
            //rs = c.SolveSchedule();
            LoadCbbSort();
            LoadCbbSearch();
            LoadCbbCourse();
            dayTemp = c.dateStart;
            addRoomForm();
            BtnClick();
        }

        private void ClearSchedule()
        {
            //cbbSearchWeek.Items.Clear();
            foreach (Panel pn in pnarr)
            {
                flpnS1.Controls.Remove(pn);
            }
        }

        private void loadDayth(DateTime monday)
        {
            CultureInfo viVn = new CultureInfo("vi-VN");
            dtpSearchWeek.Text = monday.Date.ToString();
            lbt2.Text = monday.Date.ToString("d", viVn);
            lbt3.Text = monday.AddDays(1).Date.ToString("d", viVn);
            lbt4.Text = monday.AddDays(2).Date.ToString("d", viVn);
            lbt5.Text = monday.AddDays(3).Date.ToString("d", viVn);
            lbt6.Text = monday.AddDays(4).Date.ToString("d", viVn);
            lbt7.Text = monday.AddDays(5).Date.ToString("d", viVn);
            lbcn.Text = monday.AddDays(6).Date.ToString("d", viVn);
        }

        private void addRoomForm()
        {
            ///
            c.SortRoomBySize();
            ///
            for (int j = 0; j < bllroom.getRoom().Rows.Count; j++)
            {
                pnarr[j] = new Panel() { Width = 900, Height = 100 };
                Button[] ab = new Button[9];
                int lc = 16;
                for (int i = 0; i < 8; i++)
                {
                    if (i > 0) lc = 113 + ab[i - 1].Location.X;
                    ab[i] = new Button() { Width = 80, Height = 80 };
                    ab[i].Location = new Point(lc, 3);
                    //ab[i].TextAlign = ContentAlignment.MiddleCenter;
                    if (i == 0)
                    {
                        ab[i].Text = c.arR[j].IDRoom + "\n Size: " + c.arR[j].Maxsize.ToString();
                        ab[i].TextAlign = ContentAlignment.MiddleCenter;
                        ab[i].ForeColor = Color.FromArgb(241, 250, 238);
                        ab[i].BackColor = Color.FromArgb(230, 57, 70);
                    }

                    pnarr[j].Controls.Add(ab[i]);
                }
                flpnS1.Controls.Add(pnarr[j]);
            }
            loadDayth(dayTemp);
            ScheWeek(0);
            //ClearCalendar();
        }

        public void ScheWeek(int w)
        {
            for (int j = 0; j < rs.GetLength(0); j++)
            {
                if (!string.IsNullOrEmpty(rs[j, w].NC246))
                {
                    int d = 0;
                    foreach (Button btn in pnarr[j].Controls)
                    {
                        if (d == 1 || d == 3 || d == 5)
                        {
                            btn.Text = rs[j, w].NC246;
                            btn.TextAlign = ContentAlignment.MiddleCenter;
                            foreach (ColorForCourse cl in courarr)
                            {
                                if (cl.NameCourse == rs[j, w].NC246)
                                {
                                    btn.BackColor = cl.ColorCourse;
                                }
                            }
                        }
                        d++;
                    }
                }
                if (!string.IsNullOrEmpty(rs[j, w].NC357))
                {
                    int d = 0;
                    foreach (Button btn in pnarr[j].Controls)
                    {
                        if (d == 2 || d == 4 || d == 6)
                        {
                            btn.Text = rs[j, w].NC357;
                            btn.TextAlign = ContentAlignment.MiddleCenter;
                            foreach (ColorForCourse cl in courarr)
                            {
                                if (cl.NameCourse == rs[j, w].NC357)
                                {
                                    btn.BackColor = cl.ColorCourse;
                                }
                            }
                        }
                        btn.TextAlign = ContentAlignment.MiddleCenter;
                        d++;
                    }
                }
                if (!string.IsNullOrEmpty(rs[j, w].NCCN))
                {
                    pnarr[j].Controls[7].Text = rs[j, w].NCCN;
                    foreach (ColorForCourse cl in courarr)
                    {
                        if (cl.NameCourse == rs[j, w].NCCN)
                        {
                            pnarr[j].Controls[7].BackColor = cl.ColorCourse;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(cbbCourse.Text))
            {
                foreach (Panel pn in pnarr)
                {
                    int d = 0;
                    foreach (Button btn in pn.Controls)
                    {
                        if (d != 0 && btn.Text != cbbCourse.Text)
                        {
                            btn.Text = null;
                            btn.BackColor = Color.White;
                        }
                        d++;
                    }
                }
            }
        }

        private void ClearCalendar()
        {
            for (int j = 0; j < rs.GetLength(0); j++)
            {
                int d = 0;
                foreach (Button btn in pnarr[j].Controls)
                {
                    if (d != 0)
                    {
                        btn.Text = null;
                        btn.BackColor = Color.White;
                    }
                    d++;
                }
            }
        }

        private void BtnClick()
        {
            foreach (Panel pn in pnarr)
            {
                int d = 0;
                foreach (Button btn in pn.Controls)
                {
                    if (d > 0)
                    {
                        btn.Click += new EventHandler(btn_Click);
                        //btn_Click(btn, e);
                    }
                    d++;
                }
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (!string.IsNullOrEmpty(btn.Text))
            {
                CultureInfo viVn = new CultureInfo("vi-VN");
                DataTable data = bllcourse.FindCourse(btn.Text);
                string str = "";
                str += "Mã Khóa học: " + data.Rows[0][0].ToString() + "\n";
                str += "Tên Khóa học: " + data.Rows[0][1].ToString() + "\n";
                DateTime temp = new DateTime();
                temp = DateTime.Parse(data.Rows[0][2].ToString());
                str += "Ngày bắt đầu: " + temp.Date.ToShortDateString() + "\n";
                temp = DateTime.Parse(data.Rows[0][3].ToString());
                str += "Ngày kết thúc: " + temp.Date.ToShortDateString() + "\n";
                str += "Số học viên: " + data.Rows[0][4].ToString() + "\n";
                str += "Học theo: " + data.Rows[0][6].ToString() + "\n";
                str += "Số tuần học: " + data.Rows[0][7].ToString() + "\n";
                str += "Giáo viên: " + data.Rows[0][8].ToString() + "\n";
                MessageBox.Show(str, "Thông tin khóa học", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (week + 1 < rs.GetLength(1))
            {
                week++;
                dayTemp = dayTemp.AddDays(7);
                loadDayth(dayTemp);
                ClearCalendar();
                //LoadColorCourse();
                LoadCbbSort();
                LoadCbbCourse();
                LoadCbbSearch();
                ScheWeek(week);
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (week - 1 > -1)
            {
                week--;
                dayTemp = dayTemp.AddDays(-7);
                loadDayth(dayTemp);
                ClearCalendar();
                LoadCbbSort();
                LoadCbbCourse();
                LoadCbbSearch();
                ScheWeek(week);
            }
        }

        private DateTime MondayOfWeek(DateTime date)
        {
            var dateOfWeek = date.DayOfWeek;
            if (dateOfWeek == DayOfWeek.Sunday)
            {
                return date.AddDays(-6);
            }
            int temp = dateOfWeek - DayOfWeek.Monday;
            return date.AddDays(-temp);
        }

        private void dtpSearchWeek_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan span = dtpSearchWeek.Value.Subtract(c.dateStart);
            int n = span.Days / 7;
            if (n >= 0 && n < rs.GetLength(1))
            {
                week = n;
                dayTemp = MondayOfWeek(dtpSearchWeek.Value);
                loadDayth(dayTemp);
                ClearCalendar();
                ScheWeek(week);
            }
        }

        private void LoadCbbSort()
        {
            if (cbbSort.Items.Count == 0)
            {
                cbbSort.Items.Add("Tổng thời gian");
                cbbSort.Items.Add("Thời gian từng khóa");
                cbbSort.Items.Add("Sĩ số lớp");
            }
        }

        private void LoadCbbSearch()
        {
            if (cbbSearchWeek.Items.Count == 0)
            {
                cbbSearchWeek.Items.Add(" ");
                foreach (tblRoom room in c.arR)
                {
                    cbbSearchWeek.Items.Add(room.IDRoom);
                }
            }
        }

        private void cbbSearchWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSchedule();
            if (cbbSearchWeek.Text == " ") return;
            int k = 0;
            foreach (Panel pn in pnarr)
            {
                int d = 0;
                foreach (Button btn in pn.Controls)
                {
                    if (d == 0 && btn.Text != cbbSearchWeek.Text + "\n Size: " + c.arR[k].Maxsize.ToString())
                    {
                        btn.Text = "";
                        flpnS1.Controls.Remove(pn);
                    }
                    else break;
                    d++;
                }
                k++;
            }
        }

        private void LoadCbbCourse()
        {
            if (cbbCourse.Items.Count == 0 && cbbCourse.SelectedIndex != 0)
            {
                cbbCourse.Items.Add("");
                foreach (tblCourse course in c.arC)
                {
                    cbbCourse.Items.Add(course.IDCourse);
                }
            }
        }

        private void cbbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSchedule();
            if (cbbCourse.Text == "")
            {
                return;
            }
            foreach (Panel pn in pnarr)
            {
                int d = 0;
                foreach (Button btn in pn.Controls)
                {
                    if (d != 0 && btn.Text != cbbCourse.Text)
                    {
                        btn.Text = null;
                        btn.BackColor = Color.White;
                    }
                    d++;
                }
            }
        }

        public EventArgs e { get; set; }

        #endregion

        private void cbbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStuToCou f = new AddStuToCou(tbIDCourse.Text,1);
            f.ShowDialog();
            this.Show();
        }

        private string filExcel;
        private void Button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                filExcel = fileName;
                tbNameFileExcel.Text = dlg.FileName.Substring(dlg.FileName.LastIndexOf("\\") + 1);
            }
            btnAddEx.Enabled = true;
        }

        private void BtnAddEx_Click(object sender, EventArgs e)
        {

            btnAddEx.Enabled = false;
            tblStudent s = new tblStudent();
            try
            {
                // mở file excel
                var package = new ExcelPackage(new FileInfo(filExcel));

                // lấy ra sheet đầu tiên để thao tác
                ExcelWorksheet workSheet = package.Workbook.Worksheets[0];

                // duyệt tuần tự từ dòng thứ 2 đến dòng cuối cùng của file. lưu ý file excel bắt đầu từ số 1 không phải số 0
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    try
                    {
                        // biến j biểu thị cho một column trong file
                        int j = 1;

                        // lấy ra cột họ tên tương ứng giá trị tại vị trí [i, 1]. i lần đầu là 2
                        // tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
                        s.IDStudent = workSheet.Cells[i, j++].Value.ToString();
                        s.NameStudent = workSheet.Cells[i, j++].Value.ToString();
                        s.CMNN = workSheet.Cells[i, j++].Value.ToString();
                        s.Phone = workSheet.Cells[i, j++].Value.ToString();
                        string str = workSheet.Cells[i, j++].Value.ToString();
                        if (str == "Nam") s.Sex = true; else s.Sex = false;
                        var birthdayTemp = workSheet.Cells[i, j++].Value;
                        if (birthdayTemp != null)
                        {
                            s.BirthDay = (DateTime)birthdayTemp;
                        }
                        s.Gmail = workSheet.Cells[i, j++].Value.ToString();
                        s.Address = workSheet.Cells[i, j++].Value.ToString();
                        bllstudent.InsertStudent(s);

                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show("Error!" + exe.Message);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("File không hợp lệ!" + ee.Message);
            }
            LoadStudent();
            tbNameFileExcel.Text = "";
        }

        private void BtnMyClass_Click(object sender, EventArgs e)
        {
            AddStuToCou f = new AddStuToCou(UserName,1,1);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
