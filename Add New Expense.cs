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
    public partial class AddNewExpense : Form
    {

        /// <summary>
        /// opens when the add button is clicked in form
        /// </summary>
        
        // List of Expense is created 

        List<Expense> expenseTable;
        public AddNewExpense(List<Expense> expenseTable)
        {
            InitializeComponent();
            this.expenseTable = expenseTable;
        }

        // Add new expense in the expense table
        private void addButton_Click(object sender, EventArgs e)
        {
            // Select date from calendar
            DateTime date = dateTimePicker.Value;
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            // Get the expense information

            // DateTime expenseDate = ;
            string description = DescriptionTextBox.Text;
            double amount = (double)numericUpDown.Value;

            // Create a new expense object
            Expense newExpense = new Expense(date, description, amount);

            // Add to the expense list
            expenseTable.Add(newExpense);

            // Close the window
            Close();

        }

        /// <summary>
        /// Closes the AddNewExpense window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
