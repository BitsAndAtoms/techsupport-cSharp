﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechSupport.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (userName.Text == "Jane")
            {
                this.Hide();
                MainForm newMainForm = new MainForm();
                newMainForm.Show();
            }
            else
            {
                messageLabel.Text = "invalid username/password";
            }
           
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
