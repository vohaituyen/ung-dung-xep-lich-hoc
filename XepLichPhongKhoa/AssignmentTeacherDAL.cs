using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace XepLichPhongKhoa
{
    class AssignmentTeacherDAL
    {
        private DAO.DataProvider dc;
        private SqlCommand cmd;
        public AssignmentTeacherDAL()
        {
            dc = new DAO.DataProvider();
        }
        public bool CheckASMCourse(string idcourse)
        {
            string query = @"SELECT count(*) FROM AssignmentTeacher WHERE IDCourse = '"+ idcourse+"'";
            DataTable data = dc.ExecuteQuery(query);
            return (int.Parse(data.Rows[0].ItemArray[0].ToString()) > 0) ? true : false;
        }
        public bool InsertASM(tblAssignmentTeacher asm)
        {
            string query = @"INSERT INTO AssignmentTeacher (IDUser, IDCourse) VALUES(@IDUser, @IDCourse)";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDUser", SqlDbType.NChar).Value = asm.IDUser;
                cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = asm.IDCourse;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public bool UpdateASMUser(tblAssignmentTeacher asm)
        {
            if (!CheckASMCourse(asm.IDCourse)) InsertASM(asm);
            else
            {
                string query = "UPDATE AssignmentTeacher SET IDUser = @IDUser WHERE IDCourse = @IDCourse";
                SqlConnection con = new SqlConnection(dc.connectionSTR);
                try
                {

                    cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.Add("@IDUser", SqlDbType.NChar).Value = asm.IDUser;
                    cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = asm.IDCourse;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    return false;

                }
            }    
            return true;
        }
        public bool DeleteASMCourse(string asm)
        {
            string query = "DELETE AssignmentTeacher WHERE IDCourse = @IDCourse";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {

                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = asm;
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
