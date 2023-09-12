using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace XepLichPhongKhoa
{
    class StudentDAL
    {
        private DAO.DataProvider dc;
        private SqlCommand cmd;
        public StudentDAL()
        {
            dc = new DAO.DataProvider();
        }
        public DataTable getStudent()
        {
            string getstudent = "SELECT IDStudent as [Mã học viên], NameStudent as [Tên học viên], CMNN as [CMNN/ CCCD]," +
                "Phone as [Số điện thoại], Sex as [Giới tính (Nam)], BirthDay as [Ngày sinh], Gmail as [Gmail], Address as [Địa chỉ]" +
                "FROM Student";
            return dc.ExecuteQuery(getstudent);
        }
        public int countStudent()
        {
            DataTable data = new DataTable();
            data = getStudent();
            return data.Rows.Count;
        }
        public bool InsertStudent(tblStudent student)
        {
            string query = @"INSERT INTO Student(IDStudent, NameStudent, CMNN, Phone, Sex,
                            BirthDay, Gmail, Address) VALUES(@IDStudent, @NameStudent, @CMNN, @Phone, @Sex,
                            @BirthDay, @Gmail, @Address)";

            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDStudent", SqlDbType.NChar).Value = student.IDStudent;
                cmd.Parameters.Add("@NameStudent", SqlDbType.NVarChar).Value = student.NameStudent;
                cmd.Parameters.Add("@CMNN", SqlDbType.NChar).Value = student.CMNN;
                cmd.Parameters.Add("@Phone", SqlDbType.NChar).Value = student.Phone;
                cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = student.Sex;
                cmd.Parameters.Add("@BirthDay", SqlDbType.Date).Value = student.BirthDay;
                cmd.Parameters.Add("@Gmail", SqlDbType.NVarChar).Value = student.Gmail;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = student.Address;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public bool DeleteStudent(tblStudent student)
        {
            string query = @"DELETE Student WHERE IDStudent = @IDStudent";
            //string qDeleteCourseOfCal = @"DELETE Calendar WHERE IDCourse = @IDCourse";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDStudent", SqlDbType.NChar).Value = student.IDStudent;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateStudent(tblStudent student)
        {
            string query = @"UPDATE Student SET NameStudent = @NameStudent, CMNN = @CMNN, Phone = @Phone,
                           Sex = @Sex, BirthDay = @BirthDay, Gmail = @Gmail, Address = @Address WHERE IDStudent = @IDStudent";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDStudent", SqlDbType.NChar).Value = student.IDStudent;
                cmd.Parameters.Add("@NameStudent", SqlDbType.NVarChar).Value = student.NameStudent;
                cmd.Parameters.Add("@CMNN", SqlDbType.NChar).Value = student.CMNN;
                cmd.Parameters.Add("@Phone", SqlDbType.NChar).Value = student.Phone;
                cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = student.Sex;
                cmd.Parameters.Add("@BirthDay", SqlDbType.Date).Value = student.BirthDay;
                cmd.Parameters.Add("@Gmail", SqlDbType.NVarChar).Value = student.Gmail;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = student.Address;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public DataTable FindStudent(string str)
        {
            string query = "SELECT IDStudent as [Mã học viên], NameStudent as [Tên học viên], CMNN as [CMNN/ CCCD]," +
                "Phone as [Số điện thoại], Sex as [Giới tính (Nam)], BirthDay as [Ngày sinh], Gmail as [Gmail], Address as [Địa chỉ]" +
                "FROM Student " +
                "WHERE IDStudent like N'%" + str + "%' OR NameStudent like N'%" + str + "%'";
            return dc.ExecuteQuery(query);
        }
    }
}
