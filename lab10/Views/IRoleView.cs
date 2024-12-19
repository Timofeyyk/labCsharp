using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.Views
{
    public interface IRoleView
    {
        String RoleName { get; set; }
        int RoleId { get; set; }
        void DisplayRoles(DataTable roles);
        event EventHandler AddRole;
        event EventHandler UpdateRole;
        event EventHandler ViewRoles;
        event EventHandler DeleteRole;
    }
}
