using BudgetControlApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetControlApp.Domain.Exceptions;

namespace BudgetControlApp.Domain.Services.TransactionServices
{
    public class AddIncomeService : IAddIncomeService
    {
        private readonly IDataService<Account> _accountService;

        public AddIncomeService(IDataService<Account> accountService)
        {
            _accountService = accountService;
        }

        public async Task<Account> AddIncome(Account account, double amount, int categoryId, string comment)
        {

            Income incomeTransaction = new Income()
            {
                Account = account,
                AccountId = account.Id,
                Amount = amount,
                Comment = comment,
                IncomeCategoryId = categoryId,

            };

            account.Transactions.Add(incomeTransaction);
            account.Balance += amount;

            await _accountService.Update(account.Id, account);

            return account;

        }
    }
}
