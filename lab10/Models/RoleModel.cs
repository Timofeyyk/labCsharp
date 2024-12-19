using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab10.Models
{
    public class RoleModel
    {
        private string connectionString="";
        public void AddRole(string RoleName) {
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
        
        public DataTable ReadRole() {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM roles";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public void DeleteRole(int RoleId) {
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
        public void UpdateRole(int RoleId,string RoleName) {
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
