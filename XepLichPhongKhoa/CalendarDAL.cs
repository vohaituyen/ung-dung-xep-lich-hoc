using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace XepLichPhongKhoa
{
    class CalendarDAL
    {
        private DAO.DataProvider dc;
        private SqlCommand cmd;
        public CalendarDAL()
        {
            dc = new DAO.DataProvider();
        }
        public bool InsertCalendar(tblCalendar cal)
        {
            //DeleteCalendar();
            string query = @"INSERT INTO Calendar (DateOf, IDRoom, IDCourse) VALUES(@DateOf, @IDRoom, @IDCourse)";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@DateOf", SqlDbType.Date).Value = cal.DateOf;
                cmd.Parameters.Add("@IDRoom", SqlDbType.NChar).Value = cal.IDRoom;
                cmd.Parameters.Add("@IDCourse", SqlDbType.NChar).Value = cal.IDCourse;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public bool DeleteCalendar()
        {
            string query = @"DELETE FROM Calendar";
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
    }
}
