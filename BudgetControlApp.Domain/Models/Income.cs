using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.Domain.Models
{
    public class Income:Transaction
    {
        public int? IncomeCategoryId { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
    }
}
