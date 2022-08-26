using BudgetControlApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.Domain.Services.TransactionServices
{
    public interface IAddExpenseService
    {
        Task<Account> AddExpense(Account account, double amount, int categoryId, string comment);
    }
}
