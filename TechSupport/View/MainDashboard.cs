﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechSupport.Controller;

namespace TechSupport.View
{
    public partial class MainDashboard : Form
    {
       
        private readonly IncidentController incidentController;

        /// <summary>
        /// constructor for searchIncidentDialog class
        /// </summary>
        public MainDashboard()
        {
            InitializeComponent();
            this.incidentController = new IncidentController();
        }

       

        /// <summary>
        /// search button to acquire incident record based on customer ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_click(object sender, EventArgs e)
        {
            try
            {
                var customerID = Convert.ToInt32(this.searchCustomerIDField.Value);
                this.RefreshDataGrid(customerID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong with the input!!!\n" + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// populate dataGrid table for search dialog based on customerID
        /// </summary>
        /// <param name="customerID"></param>
        private void RefreshDataGrid(int customerID)
        {
            this.searchDataGridView.DataSource = null;
            this.searchDataGridView.DataSource = this.incidentController.Search(customerID); ;
        }

        private void addIncidentButton_Click(object sender, EventArgs e)
        {
            try
            {
                var title = this.titleTextBox.Text;
                var description = this.descriptionTextBox.Text;
                var customerID = Convert.ToInt32(this.customerIDField.Value);

                this.incidentController.Add(new Model.Incident(title, description, customerID));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong with the input!!!\n" + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cancel the indcident add dialog
        /// </summary>
        /// <param name="sender">sender is the event object</param>
        /// <param name="e"> e is the even arg</param>
        private void resetIncidentTabButton_Click(object sender, EventArgs e)
        {
            this.titleTextBox.Text="";
            this.descriptionTextBox.Text="";
            this.customerIDField.Value=1;
            
        }

        public void setUserNameDisplay(String userName)
        {
            this.loginUsername.Text = userName;
        }


        /// <summary>
        /// logout page redirects user to main
        /// </summary>
        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// gracefully exits the application in case of cancel from top of GUI
        /// </summary>
        private void exitForm(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Upon load of the form populate the data table with current incidents list
        /// </summary>
        /// <param name="sender"> sender is the event object</param>
        /// <param name="e"> e is the even arg</param>
        // private void MainForm_Load(object sender, EventArgs e)
        //{
        //  this.RefreshDataGrid();
        //}


        /// <summary>
        /// populated the data grid with the list of incidents
        /// </summary>
        private void RefreshDataGrid()
        {
            this.incidentDataGridView.DataSource = null;
            this.incidentDataGridView.DataSource = this.incidentController.GetCustomerIncidents();
        }

        private void DashboardTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchIncidentTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addIncident_Click(object sender, EventArgs e)
        {

        }

        private void resetSearchTabButton_click(object sender, EventArgs e)
        {
            this.searchCustomerIDField.Value = 1;
        }
    }
}
