using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace XepLichPhongKhoa
{
    class CourseDAL
    {
        private DAO.DataProvider dc;
        private SqlCommand cmd;
        public CourseDAL()
        {
            dc = new DAO.DataProvider();
        }
        public DataTable getCourse()
        {
            UpdateStatus();
            DataTable data = new DataTable();
            string getcourse = "SELECT c.IDCourse as [Mã Khóa Học], " +
                "c.NameCourse as [Tên Khóa Học], c.DateBegin as [Ngày Bắt Đầu], " +
                "c.DateEnd as [Ngày Kết Thúc], c.AvbNumber as [Số Học Viên], " +
                "c.OpenStatus as [Trạng Thái Mở], c.SchoolDayType as [Học Theo], " +
                "c.NoSW as[Số Tuần Học], [User].Name as [Tên giáo viên] " +
                "FROM dbo.Course as c, [User], dbo.AssignmentTeacher " +
                "WHERE c.IDCourse = AssignmentTeacher.IDCourse AND [User].Username = AssignmentTeacher.IDUser ";       
            return dc.ExecuteQuery(getcourse);
        }
        public DataTable getCourse2()
        {
            string getcourse = "SELECT c.IDCourse as [Mã Khóa Học], c.NameCourse as [Tên Khóa Học]," +
                "c.AvbNumber as [Số Học Viên],c.SchoolDayType as [Học Theo], c.NoSW as[Số Tuần Học]," +
                " [User].Name as [Tên giáo viên] " +
                "FROM dbo.Course as c, [User], dbo.AssignmentTeacher " +
                "WHERE c.IDCourse = AssignmentTeacher.IDCourse AND[User].Username = AssignmentTeacher.IDUser " +
                "AND c.DateBegin > GETDATE() AND c.EndStatus = 1; ";
            return dc.ExecuteQuery(getcourse);
        }
        public DataTable getCourse3(string IDCourse)
        {
            string getcourse = "SELECT s.IDStudent as [Mã học viên], s.NameStudent as [Tên học viên], " +
                "s.Sex as [Giới tính (Nam)], s.BirthDay as [Ngày sinh] " +
                "FROM dbo.Course as c, [Class], Student as s " +
                "WHERE c.IDCourse = [Class].IDCourse AND s.IDStudent = [Class].IDStudent AND [Class].IDCourse = '" + IDCourse + "'";
            return dc.ExecuteQuery(getcourse);
        }
        public DataTable getCourseForUser(string IDUser)
        {
            string getcourse = "SELECT c.IDCourse as [Mã khóa], c.NameCourse as [Tên khóa học], " +
                "c.AvbNumber as [Sĩ số], c.DateBegin as [Ngày bắt đầu], c.SchoolDayType as [Học Theo], c.NoSW as[Số Tuần Học] " +
                "FROM dbo.Course as c, AssignmentTeacher as a, [User] as u " +
                "WHERE c.IDCourse = a.IDCourse AND a.IDUser = u.Username AND a.IDUser = '" + IDUser + "'";
            return dc.ExecuteQuery(getcourse);
        }
        public int countCourse()
        {
            DataTable data = new DataTable();
            data = getCourse();
            return data.Rows.Count;
        }
        public int countCourseEnd()
        {
            DataTable data = new DataTable();
            data = getCourse();
            int s = 0;
            foreach (DataRow row in data.Rows)
            {
                if (row[6].ToString() == "True")
                {
                    s += 1;
                }
            }
            return s;
        }
        public bool InsertCourse(tblCourse course)
        {
            string query = @"INSERT INTO Course(IDCourse, NameCourse, DateBegin, OpenStatus, AvbNumber, SchoolDayType, NoSW) VALUES(@IDCourse, @NameCourse, @DateBegin, @OpenStatus, @AvbNumber, @SchoolDayType, @NoSW)";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = course.IDCourse;
                cmd.Parameters.Add("@NameCourse", SqlDbType.NVarChar).Value = course.NameCourse;
                cmd.Parameters.Add("@DateBegin", SqlDbType.Date).Value = course.DateBegin;
                cmd.Parameters.Add("@AvbNumber", SqlDbType.Int).Value = course.AvbNumber;
                cmd.Parameters.Add("@OpenStatus", SqlDbType.Bit).Value = course.OpenStatus;
                cmd.Parameters.Add("@SchoolDayType", SqlDbType.NVarChar).Value = course.SchoolDayType;
                cmd.Parameters.Add("@NoSW", SqlDbType.Int).Value = course.NoSW;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public bool DeleteCourse(tblCourse course)
        {
            string query = @"DELETE Course WHERE IDCourse = @IDCourse";
            //string qDeleteCourseOfCal = @"DELETE Calendar WHERE IDCourse = @IDCourse";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = course.IDCourse;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable FindCourse(string str)
        {
            string query = "SELECT Course.IDCourse as [Mã Khóa Học], " +
                "NameCourse as [Tên Khóa Học], DateBegin as [Ngày Bắt Đầu], " +
                "DateEnd as [Ngày Kết Thúc], AvbNumber as [Số Học Viên], " +
                "OpenStatus as [Trạng Thái Mở], SchoolDayType as [Học Theo], " +
                "NoSW as[Số Tuần Học], [User].Name as [Tên giáo viên] " +
                "FROM dbo.Course, [User], dbo.AssignmentTeacher " +
                "WHERE (Course.IDCourse = AssignmentTeacher.IDCourse AND [User].Username = AssignmentTeacher.IDUser) AND " +
                "(Course.IDCourse like N'%" + str + "%' OR NameCourse like N'%" + str + "%')";
            return dc.ExecuteQuery(query);
        }
        public DataTable FindCourse2(string str)
        {
            string query = "SELECT c.IDCourse as [Mã Khóa Học], c.NameCourse as [Tên Khóa Học]," +
                "c.AvbNumber as [Số Học Viên],c.SchoolDayType as [Học Theo], c.NoSW as[Số Tuần Học]," +
                " [User].Name as [Tên giáo viên] " +
                "FROM dbo.Course as c, [User], dbo.AssignmentTeacher " +
                "WHERE c.IDCourse = AssignmentTeacher.IDCourse AND[User].Username = AssignmentTeacher.IDUser " +
                "AND c.DateBegin > GETDATE() AND c.EndStatus = 1 AND " +
                "(c.IDCourse like N'%" + str + "%' OR c.NameCourse like N'%" + str + "%')";
            return dc.ExecuteQuery(query);
        }

        public bool UpdateCourse(tblCourse course)
        {
            string query = @"UPDATE Course SET NameCourse = @NameCourse, DateBegin = @DateBegin, OpenStatus = @OpenStatus, SchoolDayType = @SchoolDayType, NoSW = @NoSW WHERE IDCourse = @IDCourse";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = course.IDCourse;
                cmd.Parameters.Add("@NameCourse", SqlDbType.NVarChar).Value = course.NameCourse;
                cmd.Parameters.Add("@DateBegin", SqlDbType.Date).Value = course.DateBegin;
                cmd.Parameters.Add("@OpenStatus", SqlDbType.Bit).Value = course.OpenStatus;
                cmd.Parameters.Add("@SchoolDayType", SqlDbType.NVarChar).Value = course.SchoolDayType;
                cmd.Parameters.Add("@NoSW", SqlDbType.Int).Value = course.NoSW;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public bool UpdateStatus()
        {
            string query = @"UPDATE Course SET OpenStatus = 1 WHERE AvbNumber >15";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public bool UpdateDateEndCourse(tblCourse course)
        {
            string query = @"UPDATE Course SET DateEnd = @DateEnd, EndStatus = @EndStatus WHERE IDCourse = @IDCourse";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = course.IDCourse;
                cmd.Parameters.Add("@DateEnd", SqlDbType.Date).Value = course.DateEnd;
                cmd.Parameters.Add("@EndStatus", SqlDbType.Bit).Value = course.EndStatus;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public void UpdateAvbNumber(string IDCourse, int k)
        {
            string check = "SELECT AvbNumber " +
               "FROM Course " +
               "WHERE IDCourse = '" + IDCourse + "'";
            DataTable data = dc.ExecuteQuery(check);
            int avb = int.Parse(data.Rows[0].ItemArray[0].ToString());
            string query = @"UPDATE Course SET AvbNumber = @AvbNumber WHERE IDCourse = @IDCourse";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = IDCourse;
            cmd.Parameters.Add("@AvbNumber", SqlDbType.Int).Value = avb + k;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
