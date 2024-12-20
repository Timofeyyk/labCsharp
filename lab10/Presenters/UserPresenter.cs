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
    class UserPresenter
    {
        private readonly IUserView view;
        private readonly UserModel model;

        public UserPresenter(IUserView view, UserModel model)
        {
            this.view = view;
            this.model = model;

            view.AddUser += OnAddUser;
            view.UpdateUser += OnUpdateUser;
            view.DeleteUser += OnDeleteUser;
            view.ViewUsers += OnViewUser;
        }
        private void OnAddUser(object sender, EventArgs e)
        {
            model.AddUser(view.UserLogin,view.UserPassword,view.UserRole,view.UserName);
            OnViewUser(sender, e);
        }
        private void OnUpdateUser(object sender, EventArgs e)
        {
            model.UpdateUser(view.UserId, view.UserLogin, view.UserPassword, view.UserRole, view.UserName);
            OnViewUser(sender, e);
        }
        private void OnViewUser(object sender, EventArgs e)
        {
            Debug.WriteLine($"Просмотр ролей...");
            view.DisplayUsers(model.ReadUsers());
        }
        private void OnDeleteUser(object sender, EventArgs e)
        {
            model.DeleteUser(view.UserId);
            OnViewUser(sender, e);
        }
    }
}
