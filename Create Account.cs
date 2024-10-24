using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ExpenseTracker
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create the account for the new user, save it to the database and direct the user back to the login page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            // Ensure that the text boxes are not null and contain valid input
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return; // Exit the method if any field is empty
            }

            string fullName = FullNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            // Retrieve connection string from app.config
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString;

            // Sql query 
            string query = "INSERT INTO Users (FullName, Email, Password) VALUES (@FullName, @Email, @Password)";

            // Insert data into database table 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Add values to the sql query parameters
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                try
                { 
                    connection.Open();  // Open the connection to the database.
                    int result = command.ExecuteNonQuery();  // Run the sql query.

                    if (result > 0)
                    {
                        MessageBox.Show("Account Created successfully.");

                        // Redirect to login form
                        Login login = new Login();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create account. Please try again.");
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show($"An error occured: {ex.Message}\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
