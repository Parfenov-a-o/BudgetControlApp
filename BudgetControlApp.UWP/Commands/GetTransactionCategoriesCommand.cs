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
    public class GetTransactionCategoriesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private HomeViewModel _homeViewModel;
        private IDataService<ExpenseCategory> _expenseCategoryDataService;
        private IDataService<IncomeCategory> _incomeCategoryDataService;

        public GetTransactionCategoriesCommand(HomeViewModel homeViewModel, 
            IDataService<ExpenseCategory> expenseCategoryDataService, 
            IDataService<IncomeCategory> incomeCategoryDataService)
        {
            _homeViewModel = homeViewModel;
            _expenseCategoryDataService = expenseCategoryDataService;
            _incomeCategoryDataService = incomeCategoryDataService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                var incomeCategories = await _incomeCategoryDataService.GetAll();
                var expenseCategories = await _expenseCategoryDataService.GetAll();

                if (_homeViewModel.SelectedTransactionType == "Доходы")
                {
                    _homeViewModel.AddTransactionCategory(incomeCategories);

                }
                if (_homeViewModel.SelectedTransactionType == "Расходы")
                {
                    _homeViewModel.AddTransactionCategory(expenseCategories);

                    
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
