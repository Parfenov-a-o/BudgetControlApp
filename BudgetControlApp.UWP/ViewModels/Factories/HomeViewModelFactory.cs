using BudgetControlApp.Domain.Models;
using BudgetControlApp.Domain.Services;
using BudgetControlApp.Domain.Services.TransactionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.UWP.ViewModels.Factories
{
    public class HomeViewModelFactory : IBudgetControlAppViewModelFactory<HomeViewModel>
    {
        //private IBudgetControlAppViewModelFactory<HomeViewModel> _homeViewModelFactory;

        //public HomeViewModelFactory(IBudgetControlAppViewModelFactory<HomeViewModel> homeViewModelFactory)
        //{
        //    _homeViewModelFactory = homeViewModelFactory;
        //}

        private readonly IAddIncomeService _addIncomeService;
        private readonly IAddExpenseService _addExpenseService;
        private readonly IDataService<ExpenseCategory> _expenseCategoryDataService;
        private readonly IDataService<IncomeCategory> _incomeCategoryDataService;
        private readonly IDataService<Account> _accountDataService;

        public HomeViewModelFactory(IAddIncomeService addIncomeService, 
            IAddExpenseService addExpenseService, 
            IDataService<ExpenseCategory> expenseCategoryDataService, 
            IDataService<IncomeCategory> incomeCategoryDataService,
            IDataService<Account> accountDataService)
        {
            _addIncomeService = addIncomeService;
            _addExpenseService = addExpenseService;
            _expenseCategoryDataService = expenseCategoryDataService;
            _incomeCategoryDataService = incomeCategoryDataService;
            _accountDataService = accountDataService;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_addIncomeService, _addExpenseService,_expenseCategoryDataService,_incomeCategoryDataService, _accountDataService);
        }
    }
}
