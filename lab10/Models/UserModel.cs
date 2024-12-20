using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10.Models
{
    class UserModel
    {
        private string connectionString = "";
        public void AddUser(string UserLogin, string UserPassword, string UserRole, string UserName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO roles (rolename) VALUES (@rolename)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@rolename", RoleName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ReadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM roles";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public void DeleteUser(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM roles WHERE roleid = @roleid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@roleid", RoleId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateUser(int UserId, string UserLogin, string UserPassword, string UserRole, string UserName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE roles SET rolename = @rolename WHERE orderID = @roleID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@roleid", RoleId);
                cmd.Parameters.AddWithValue("@rolename", RoleName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
