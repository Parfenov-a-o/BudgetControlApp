using BudgetControlApp.Domain.Models;
using BudgetControlApp.Domain.Services;
using BudgetControlApp.Domain.Services.TransactionServices;
using BudgetControlApp.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace BudgetControlApp.UWP.Commands
{
    public class AddTransactionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private HomeViewModel _homeViewModel;
        private readonly IAddIncomeService _addIncomeService;
        private readonly IAddExpenseService _addExpenseService;
        private readonly IDataService<Account> _accountDataService;

        public AddTransactionCommand(HomeViewModel homeViewModel, 
            IAddIncomeService addIncomeService, 
            IAddExpenseService addExpenseService, 
            IDataService<Account> accountDataService)
        {
            _homeViewModel = homeViewModel;
            _addIncomeService = addIncomeService;
            _addExpenseService = addExpenseService;
            _accountDataService = accountDataService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                Account currentAccount = await _accountDataService.Get(1);

                if (_homeViewModel.SelectedTransactionType == "Доходы")
                {
                    Account account = await _addIncomeService.AddIncome(currentAccount, 
                        _homeViewModel.Amount,_homeViewModel.CategoryId, 
                        _homeViewModel.Comment);
                    _homeViewModel.Balance += _homeViewModel.Amount;
                }
                if (_homeViewModel.SelectedTransactionType == "Расходы")
                {
                    Account account = await _addExpenseService.AddExpense(currentAccount, 
                        _homeViewModel.Amount, _homeViewModel.CategoryId, 
                        _homeViewModel.Comment);
                    _homeViewModel.Balance -= _homeViewModel.Amount;
                    
                }
            }
            catch(Exception ex)
            {
                                
            }
        }
    }
}
