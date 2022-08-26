using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.Domain.Models
{
    public class Account:DomainObject
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
