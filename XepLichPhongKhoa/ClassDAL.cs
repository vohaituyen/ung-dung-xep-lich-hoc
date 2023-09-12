using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace XepLichPhongKhoa
{
    class ClassDAL
    {
        private DAO.DataProvider dc;
        private SqlCommand cmd;
        public ClassDAL()
        {
            dc = new DAO.DataProvider();
        }
        public DataTable getCourseOfStudent(string str)
        {
            string getCOS = "SELECT Course.IDCourse as [Mã], Course.NameCourse [Tên]" +
                "FROM [Class], Student, Course " +
                "WHERE [Class].IDStudent = Student.IDStudent AND [Class].IDCourse = Course.IDCourse AND [Class].IDStudent = '" + str +"'";
            return dc.ExecuteQuery(getCOS);
        }
        public bool InsertIntoClass(tblClass cl)
        {
            string query = @"INSERT INTO [Class] (IDCourse, IDStudent) VALUES(@IDCourse, @IDStudent)";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = cl.IDCourse;
                cmd.Parameters.Add("@IDStudent", SqlDbType.NChar).Value = cl.IDStudent;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public bool CheckClass(tblClass cl)
        {
            string check = "SELECT IDCourse, IDStudent " +
               "FROM [Class] " +
               "WHERE IDStudent = '" + cl.IDStudent + "' AND IDCourse = '" + cl.IDCourse + "'";
            DataTable data = new DataTable();
            data = dc.ExecuteQuery(check);
            if (data.Rows.Count == 0) return true;
            return false;
        }
        public bool DeleteStuOfClass(tblClass cl)
        {
            string query = @"DELETE Class WHERE IDCourse = @IDCourse AND IDStudent = @IDStudent";
            //string qDeleteCourseOfCal = @"DELETE Calendar WHERE IDCourse = @IDCourse";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = cl.IDCourse;
                cmd.Parameters.Add("@IDStudent", SqlDbType.NChar).Value = cl.IDStudent;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteCourseOfClass(string cl)
        {
            string query = @"DELETE Class WHERE IDCourse = @IDCourse";
            //string qDeleteCourseOfCal = @"DELETE Calendar WHERE IDCourse = @IDCourse";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = cl;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
