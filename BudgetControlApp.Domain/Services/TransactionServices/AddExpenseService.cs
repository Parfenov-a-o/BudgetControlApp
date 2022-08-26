using BudgetControlApp.Domain.Exceptions;
using BudgetControlApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.Domain.Services.TransactionServices
{
    public class AddExpenseService : IAddExpenseService
    {

        private readonly IDataService<Account> _accountService;

        public AddExpenseService(IDataService<Account> accountService)
        {
            _accountService = accountService;
        }
        public async Task<Account> AddExpense(Account account, double amount, int categoryId, string comment)
        {
            if(amount>account.Balance)
            {
                throw new NotEnoughMoneyException(account.Balance, amount);
            }

            Expense expenseTransaction = new Expense()
            {
                Account = account,
                AccountId = account.Id,
                Amount = amount,
                Comment = comment,
                ExpenseCategoryId = categoryId,

            };

            account.Transactions.Add(expenseTransaction);
            account.Balance -= amount;

            await _accountService.Update(account.Id, account);

            return account;
        }
    }
}
