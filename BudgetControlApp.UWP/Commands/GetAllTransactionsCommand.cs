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
    public class GetAllTransactionsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private TransactionHistoryViewModel _transactionHistoryViewModel;
        private readonly IDataService<Income> _incomeDataService;
        private readonly IDataService<Expense> _expenseDataService;

        public GetAllTransactionsCommand(TransactionHistoryViewModel transactionHistoryViewModel, 
            IDataService<Income> incomeDataService, 
            IDataService<Expense> expenseDataService)
        {
            _transactionHistoryViewModel = transactionHistoryViewModel;
            _incomeDataService = incomeDataService;
            _expenseDataService = expenseDataService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                var incomes = await _incomeDataService.GetAll();
                var expenses = await _expenseDataService.GetAll();

                _transactionHistoryViewModel.AddIncomes(incomes);
                _transactionHistoryViewModel.AddExpenses(expenses);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
