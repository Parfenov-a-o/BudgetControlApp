using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.Domain.Models
{
    public class Transaction:DomainObject
    {
        public double Amount { get; set; }
        public string Comment { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
