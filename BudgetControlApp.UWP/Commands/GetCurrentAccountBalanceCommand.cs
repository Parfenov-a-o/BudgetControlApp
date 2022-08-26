using BudgetControlApp.Domain.Models;
using BudgetControlApp.Domain.Services;
using BudgetControlApp.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetControlApp.UWP.Commands
{
    public class GetCurrentAccountBalanceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private HomeViewModel _homeViewModel;
        private readonly IDataService<Account> _accountDataService;

        public GetCurrentAccountBalanceCommand(HomeViewModel homeViewModel, IDataService<Account> accountDataService)
        {
            _homeViewModel = homeViewModel;
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
                _homeViewModel.Balance = currentAccount.Balance;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
