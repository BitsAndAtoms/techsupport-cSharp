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
    public partial class AddIncidentDialog : Form
    {
        private readonly IncidentController incidentController;

        /// <summary>
        /// constructor for addIncidentDialog
        /// </summary>
        public AddIncidentDialog()
        {
            InitializeComponent();
            this.incidentController = new IncidentController();
        }

        /// <summary>
        /// add Incident button adds an incident to the incidents list in main form
        /// </summary>
        /// <param name="sender">sender is the event object</param>
        /// <param name="e"> e is the even arg</param>
        private void addIncidentButton_Click(object sender, EventArgs e)
        {
            try
            {
                var title = this.titleTextBox.Text;
                var description = this.descriptionTextBox.Text;
                var customerID = Convert.ToInt32(this.customerIDField.Value);

                this.incidentController.Add(new Model.Incident(title, description, customerID));
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) {
                MessageBox.Show("Something is wrong with the input!!!\n" + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cancel the indcident add dialog
        /// </summary>
        /// <param name="sender">sender is the event object</param>
        /// <param name="e"> e is the even arg</param>
        private void cancelIncidentAddButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

      
    }
}
