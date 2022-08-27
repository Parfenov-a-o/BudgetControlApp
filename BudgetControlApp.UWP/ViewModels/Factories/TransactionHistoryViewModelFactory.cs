using BudgetControlApp.Domain.Models;
using BudgetControlApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.UWP.ViewModels.Factories
{
    public class TransactionHistoryViewModelFactory : IBudgetControlAppViewModelFactory<TransactionHistoryViewModel>
    {


        private readonly IDataService<Income> _incomeDataService;
        private readonly IDataService<Expense> _expenseDataService;

        public TransactionHistoryViewModelFactory(IDataService<Income> incomeDataService, IDataService<Expense> expenseDataService)
        {
            _incomeDataService = incomeDataService;
            _expenseDataService = expenseDataService;
        }

        public TransactionHistoryViewModel CreateViewModel()
        {
            return new TransactionHistoryViewModel(_incomeDataService, _expenseDataService);
        }
    }
}
