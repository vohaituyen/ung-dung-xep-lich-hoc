using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace XepLichPhongKhoa
{
    class RoomDAL
    {
        private DAO.DataProvider dc;
        private SqlCommand cmd;
        public RoomDAL()
        {
            dc = new DAO.DataProvider();
        }
        public DataTable getRoom()
        {
            string getroom = "SELECT IDRoom as [Mã Phòng], Maxsize as [Sĩ số tối đa] FROM dbo.Room";
            return dc.ExecuteQuery(getroom); 
        }
        public bool InsertRoom(tblRoom room)
        {
            string query = @"INSERT INTO Room(IDRoom, Maxsize) VALUES(@IDRoom, @Maxsize)";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query,con);
                con.Open();
                cmd.Parameters.Add("@IDRoom", SqlDbType.NChar).Value = room.IDRoom;
                cmd.Parameters.Add("@Maxsize", SqlDbType.Int).Value = room.Maxsize;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
                return false;

            }
            return true;
        }

        public bool UpdateRoom(tblRoom room)
        {
            string query = @"UPDATE Room SET Maxsize = @Maxsize WHERE IDRoom = @IDRoom";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDRoom", SqlDbType.NChar).Value = room.IDRoom;
                cmd.Parameters.Add("@Maxsize", SqlDbType.Int).Value = room.Maxsize;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }

        public bool DeleteRoom(tblRoom room)
        {
            string query = @"DELETE Room WHERE IDRoom = @IDRoom";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@IDRoom", SqlDbType.NChar).Value = room.IDRoom;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable FindRoom(string room)
        {
            string query = "SELECT IDRoom as [Mã Phòng], Maxsize as [Sĩ số tối đa] FROM Room WHERE IDRoom like '%" + room + "%'";
            return dc.ExecuteQuery(query);
        }
    }
}
