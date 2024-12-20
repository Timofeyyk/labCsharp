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
                string query = "INSERT INTO users (UserLogin,UserPassword,UserRole,UserName) VALUES (@UserLogin,@UserPassword,@UserRole,@UserName)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserLogin", UserLogin);
                cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
                cmd.Parameters.AddWithValue("@UserRole", UserRole);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ReadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM users";
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
                string query = "DELETE FROM users WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserId", UserId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateUser(int UserId, string UserLogin, string UserPassword, string UserRole, string UserName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE users SET UserLogin = @UserLogin, UserPassword = @UserPassword, UserRole = @UserRole, UserName = @UserName WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@UserLogin", UserLogin);
                cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
                cmd.Parameters.AddWithValue("@UserRole", UserRole);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
