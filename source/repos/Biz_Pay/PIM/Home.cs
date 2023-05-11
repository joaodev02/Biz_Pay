using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PIM
{
    public partial class Home : Form
    {
        private Form activeForm;


        public Home()
        {
            InitializeComponent();
        }

        public void FormShow(Form form)
        {
            ActiveFormClose();
            this.activeForm = form;
            form.TopLevel = false;
            panelContentForm.Controls.Add(form);
            form.BringToFront();
            form.Show();

        }

        public void ActiveFormClose()
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
        }

        private void ActiveButton(Button activeForm)
        {
            foreach(Control control in mainPanel.Controls)
            {
                control.ForeColor = Color.White;
                activeForm.ForeColor = Color.FromArgb(233,96,90);
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ActiveButton(btnHome);
            FormShow(new Profile());

            if (PIM.Database.User.Permition != "Admin")
            {
                btnEmployees.Visible = false;
                btnRegisterEmployees.Visible = false;
            };
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActiveButton(btnHome);
            FormShow(new Profile());
        }
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            ActiveButton(btnEmployees);
            FormShow(new Employees());
        }

        private void btnRegisterEmployees_Click(object sender, EventArgs e)
        {
            ActiveButton(btnRegisterEmployees);
            FormShow(new RegisterEmployees());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            PIM.Utils.ContextLogin.Login.Show();
            PIM.Utils.ContextHome._Home.Hide();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Utils.ContextLogin.Login != null)
            {
                string programName = Process.GetCurrentProcess().ProcessName;

                foreach (Process process in Process.GetProcessesByName(programName))
                {
                    process.Kill();
                }
            }
        }
    }
}
