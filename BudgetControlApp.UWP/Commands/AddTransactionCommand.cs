using BudgetControlApp.Domain.Exceptions;
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
           
            _homeViewModel.StatusMessage = String.Empty;
            _homeViewModel.ErrorMessage = String.Empty;
            
            if(_homeViewModel.Amount <= 0)
            {
                _homeViewModel.ErrorMessage = "Сумма должна быть положительной!";
                return;
            }

            if(_homeViewModel.SelectedTransactionCategory == null)
            {
                _homeViewModel.ErrorMessage = "Вы не выбрали категорию транзакции!";
                return;
            }
            
            try
            {
                Account currentAccount = await _accountDataService.Get(1);

                if (_homeViewModel.SelectedTransactionType == "Доходы")
                {
                    Account account = await _addIncomeService.AddIncome(currentAccount, 
                        _homeViewModel.Amount,_homeViewModel.CategoryId, 
                        _homeViewModel.Comment);
                    _homeViewModel.Balance += _homeViewModel.Amount;
                    

                    _homeViewModel.StatusMessage =  $"Доходы в размере {_homeViewModel.Amount} рублей успешно добавлены!";

                    _homeViewModel.Amount = 0;
                }
                if (_homeViewModel.SelectedTransactionType == "Расходы")
                {
                    Account account = await _addExpenseService.AddExpense(currentAccount, 
                        _homeViewModel.Amount, _homeViewModel.CategoryId, 
                        _homeViewModel.Comment);
                    _homeViewModel.Balance -= _homeViewModel.Amount;
                    

                    _homeViewModel.StatusMessage = $"Расходы в размере {_homeViewModel.Amount} рублей успешно добавлены!";

                    _homeViewModel.Amount = 0;

                }
            }
            catch (NotEnoughMoneyException)
            {
                _homeViewModel.ErrorMessage = "У вас недостаточно средств на балансе!";
            }
            catch(Exception ex)
            {
                _homeViewModel.ErrorMessage = "Ошибка при добавлении транзакции!";            
            }
        }
    }
}
