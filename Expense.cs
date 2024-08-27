using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
  
    public class Expense
    {
        /// <summary>
        ///  Variables
        /// </summary>
        private DateTime date;
        private string description;
        private double amount;


        /// <summary>
        /// Constructor of Expense
        /// </summary>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="amount"></param>
        public Expense(DateTime date, string description, double amount)
        {
            this.date = date;
            this.description = description;
            this.amount = amount;
        }

        // Getter method

        /// <summary>
        /// Get the date the expense is made
        /// </summary>
        /// <returns></returns>
        public DateTime GetDate()
        {
            return date;
        }

        /// <summary>
        /// Get the description of the expense
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return description;
        }

        /// <summary>
        /// Gets the amount of expense made
        /// </summary>
        /// <returns></returns>
        public double GetAmount()
        {
            return amount;
        }
    }
}
