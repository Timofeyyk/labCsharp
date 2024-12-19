using lab10.Models;
using lab10.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.Presenters
{
    public class RolePresenter
    {
        private readonly IRoleView view;
        private readonly RoleModel model;

        public RolePresenter(IRoleView view, RoleModel model)
        {
            this.view = view;
            this.model = model;

            view.AddRole += OnAddRole;
            view.UpdateRole += OnUpdateRole;
            view.DeleteRole += OnDeleteRole;
            view.ViewRoles += OnViewRole;
        }
        private void OnAddRole(object sender, EventArgs e)
        {
            model.AddRole(view.RoleName);
            OnViewRole(sender, e);
        }
        private void OnUpdateRole(object sender, EventArgs e)
        {
            model.UpdateRole(view.RoleId, view.RoleName);
            OnViewRole(sender, e);
        }
        private void OnViewRole(object sender, EventArgs e)
        {
            Debug.WriteLine($"Просмотр ролей...");
            view.DisplayRoles(model.ReadRole());
        }
        private void OnDeleteRole(object sender, EventArgs e)
        {
            model.DeleteRole(view.RoleId);
            OnViewRole(sender, e);
        }

    }
}
