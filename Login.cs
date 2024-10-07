using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Open the form with expenses for the particular user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the Expense form
            Form1 ExpenseForm = new Form1();
            this.Hide(); // hide Form1.

            ExpenseForm.ShowDialog();// Open the dialog box
            this.Close(); // Close the Form1
        }

        private void CreateAccountlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            this.Hide();

            createAccount.Show();
            this.Close();
        }
    }   
}
