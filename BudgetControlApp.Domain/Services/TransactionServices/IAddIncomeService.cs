using BudgetControlApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.Domain.Services.TransactionServices
{
    public interface IAddIncomeService
    {
        Task<Account> AddIncome(Account account, double amount, int categoryId, string comment );
    }
}
