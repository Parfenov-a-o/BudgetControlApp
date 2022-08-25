using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.Domain.Models
{
    public class Expense:Transaction
    {
        public int? ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
    }
}
