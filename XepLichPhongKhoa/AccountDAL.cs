using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace XepLichPhongKhoa
{
    class AccountDAL
    {
        private DAO.DataProvider dc;
        private SqlCommand cmd;
        public AccountDAL()
        {
            dc = new DAO.DataProvider();
        }
        public DataTable getAccount()
        {
            string getaccount = "SELECT Username as [Tên Tài Khoản], Password as [Mật Khẩu], Name as [Họ Tên], Sex as [Giới tính (Nam)]";
            getaccount += ", Birthday as [Ngày sinh], Premission as [Quyền Quản lý], Address as [Địa Chỉ], Career as [Chức Danh] FROM [User]";
            return dc.ExecuteQuery(getaccount);
        }
        public DataTable getUser(string str)
        {
            string getaccount = "SELECT Photo, Name , Sex, Birthday, Premission, Address, Career FROM [User] WHERE Username = '"+str+"'";
            return dc.ExecuteQuery(getaccount);
        }
        public int CheckLogin(string username, string password)
        {
            string query = "SELECT Premission FROM [User] WHERE Username = '" + username + "' AND Password = '" + password + "'";
            DataTable data = dc.ExecuteQuery(query);
            if (data.Rows.Count == 1)
            {
                if (data.Rows[0][0].ToString() == "True")
                    return 0;
                else return 1;
            }
            return 2;
        }
        
        public bool InsertAccountDAL(Account acc)
        {
            string query = "INSERT INTO [User](Username, Password, Photo, Name, Sex, Birthday, Premission, Address, Career) VALUES(@Username, @Password, @Photo, @Name, @Sex, @Birthday, @Premission, @Address, @Career)";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {
                
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@Username", SqlDbType.NChar).Value = acc.Username;
                cmd.Parameters.Add("@Password", SqlDbType.NChar).Value = acc.Password;
                cmd.Parameters.Add("@Photo", SqlDbType.Image).Value = acc.Photo;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = acc.Name;
                cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = acc.Sex;
                cmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = acc.Birthday;
                cmd.Parameters.Add("@Premission", SqlDbType.Bit).Value = acc.Premission;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = acc.Address;
                cmd.Parameters.Add("@Career", SqlDbType.NVarChar).Value = acc.Career;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public bool UpdateAccountDAL(Account acc)
        {
            string query = "UPDATE [User] SET Photo = @Photo, Name = @Name, Sex = @Sex, Birthday = @Birthday, Address = @Address, Career = @Career WHERE Username = @Username ";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {

                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@Username", SqlDbType.NChar).Value = acc.Username;
                cmd.Parameters.Add("@Photo", SqlDbType.Image).Value = acc.Photo;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = acc.Name;
                cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = acc.Sex;
                cmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = acc.Birthday;
                cmd.Parameters.Add("@Premission", SqlDbType.Bit).Value = acc.Premission;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = acc.Address;
                cmd.Parameters.Add("@Career", SqlDbType.NVarChar).Value = acc.Career;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        public bool DeleteAcountDAL(Account acc)
        {
            string query = "DELETE [User] WHERE Username = @Username AND Premission <> 1";
            SqlConnection con = new SqlConnection(dc.connectionSTR);
            try
            {

                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@Username", SqlDbType.NChar).Value = acc.Username;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;

        }
        public DataTable FindAccount(string str)
        {
            string getaccount = "SELECT Username as [Tên Tài Khoản], Password as [Mật Khẩu], Name as [Họ Tên], Sex as [Giới tính (Nam)]";
            getaccount += ", Birthday as [Ngày sinh], Premission as [Quyền Quản lý], Address as [Địa Chỉ], Career as [Chức Danh] FROM [User]";
            getaccount += " WHERE Username like N'%" + str + "%' OR Name like N'%" + str + "%'";
            return dc.ExecuteQuery(getaccount);
        }
    }
}
