using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.Domain.Models
{
    public class ExpenseCategory : TransactionCategory
    {
        public string Name { get; set; }
    }
}
