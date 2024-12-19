using lab10.Models;
using lab10.Presenters;
using lab10.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lab10
{
    public partial class Roles : Form,IRoleView
    {
        public Roles()
        {
            InitializeComponent();

            var model = new RoleModel();
            var presenter = new RolePresenter(this,model);

            button1.Click += (s, e) => AddRole?.Invoke(s, e);
            button4.Click += (s, e) => ViewRoles?.Invoke(s, e);
        }
        public string RoleName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public int RoleId { get; set; }

        public event EventHandler AddRole;
        public event EventHandler UpdateRole;
        public event EventHandler DeleteRole;
        public event EventHandler ViewRoles;

        public void DisplayRoles(DataTable roles)
        {
            dataGridView1.DataSource = roles;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int RoleId = Convert.ToInt32(selectedRow.Cells["RoleId"].Value);
                RoleId = RoleId;
                DeleteRole?.Invoke(sender, e);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите студента для удаления.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                RoleId = Convert.ToInt32(selectedRow.Cells["RoleId"].Value);
                UpdateRole?.Invoke(sender, e);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите студента для обновления.");
            }
        }
    }
}
