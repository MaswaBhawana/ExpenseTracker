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
    public partial class Form1 : Form
    {
        // List of expense objects

        List<Expense> expenseTable = new List<Expense>(){
            new Expense(new DateTime(2024,3,10), "Grocery shopping", 150.00), // Index 0
            new Expense(new DateTime(2024,3,11), "Gas bill", 75.00), // Index 1
            new Expense(new DateTime(2024,3,12), "Subscription service", 12.00), // Index 2
            new Expense(new DateTime(2024,3,13), "Video game purchase", 59.00), // Index 3
            new Expense(new DateTime(2024,3,14), "Dinner at a restaurant", 60.00), // Index 4
            
        };

        /// <summary>
        ///  Shows the current table in the GUI 
        /// </summary>
        void UpdateTableGUI()
        {
            // Create a new table object
            DataTable dataTable = new DataTable();

            // Add 3 columns
            dataTable.Columns.Add("Date");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Amount");

            // Add 1 row per expense in the table
            for (int index = 0; index < expenseTable.Count; index++)
            {
                // Add a row 
                dataTable.Rows.Add();

                // Change the information in each column of the row
                dataTable.Rows[index][0] = expenseTable[index].GetDate();// Date of the expense                     
                dataTable.Rows[index][1] = expenseTable[index].GetDescription(); // Description of the expense
                dataTable.Rows[index][2] = $"{expenseTable[index].GetAmount():C}"; // Amount of the expense
            }

            // Update the dataGrid
            dataGridView.DataSource = dataTable;

            // Resize the columns
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        
    }

        public Form1()
        {
            InitializeComponent();
            UpdateTableGUI();
        }
        /// <summary>
        /// Find the Expense by description
        /// </summary>
       
        Expense FindExpenseByDescription(string description)
        {
            // Go through all expense in the menu
            foreach (Expense expense in expenseTable)
            {
                // Found expense with that description
                if (expense.GetDescription() == description)
                    // Return that expense object
                    return expense;
            }

            // Did not find a expense with that name
            return null;
        }
        

        /// <summary>
        /// Remove The selected expense from table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            // List is empty, do nothing
            if (expenseTable.Count == 0)
            {
                MessageBox.Show("List is empty !");
                return;
            }
            // Get the selected expense
            string selectedExpense = dataGridView.CurrentRow.Cells[1].Value.ToString();

            // Get the expense object we want to remove
            Expense expense = FindExpenseByDescription(selectedExpense);

            // Remove from the list
            expenseTable.Remove(expense);

            // Update the grid
            UpdateTableGUI();
        }

        /// <summary>
        /// Open a new Add Expense dialog box when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click_1(object sender, EventArgs e)
        {
            AddNewExpense addNewExpense = new AddNewExpense(expenseTable);
            addNewExpense.ShowDialog();
            UpdateTableGUI();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
