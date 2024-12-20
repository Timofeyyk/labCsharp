using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.Views
{
    public interface IUserView
    {
        String UserName { get; set; }
        int UserId { get; set; }
        string UserPassword {  get; set; }
        string UserLogin {  get; set; }
        string UserRole {  get; set; }
        void DisplayUsers(DataTable users);
        event EventHandler AddUser;
        event EventHandler UpdateUser;
        event EventHandler ViewUsers;
        event EventHandler DeleteUser;
    }
}
