using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        /// This method will validate the user by checking if they exists in database or not 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool ValidateUser(string email, string password)
        {
            bool isValidUser = false;
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString;
            string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        int userCount = (int)command.ExecuteScalar();
                        MessageBox.Show($"User Count: {userCount}"); // Debugging line
                        if (userCount == 1)
                        {
                            isValidUser = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            return isValidUser;
        }

        /// <summary>
        /// Open the form with expenses for the particular user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string email = Email.Text;
            string password = Password.Text;
            // Validation 
            // If the account exists then take the user to their expense record
            if (ValidateUser(email, password))
            {
                MessageBox.Show($"Attempting login with Email: {email} and Password: {password}");
                // Create an instance of the Expense form
                Form1 ExpenseForm = new Form1();
                this.Hide();                // hide Form1.
                ExpenseForm.ShowDialog();   // Open the dialog box
                this.Close();               // Close the Form1
            }
            // Else invalid email and password
            else
            {
                MessageBox.Show("Invalid email or password!! Try again!");
            }

        }

        /// <summary>
        /// This method will direct new users to the create account page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccountlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            this.Hide();
            createAccount.Show();
        }
    }   
}
