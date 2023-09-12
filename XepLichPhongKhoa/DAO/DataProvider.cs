using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace XepLichPhongKhoa.DAO
{
    public class DataProvider
    {
        private string _connectionSTR = @"Data Source=DESKTOP-C8QU0CC;Initial Catalog=QuanLyPhongKhoa;Integrated Security=True";
        public string connectionSTR
        {
            get
            {
                return _connectionSTR;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connectionSTR);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        } 
    }
}
