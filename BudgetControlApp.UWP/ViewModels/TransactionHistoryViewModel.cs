using BudgetControlApp.Domain.Models;
using BudgetControlApp.Domain.Services;
using BudgetControlApp.UWP.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetControlApp.UWP.ViewModels
{
    public class TransactionHistoryViewModel : ViewModelBase
    {

        private IEnumerable<Income> _incomes;

        public IEnumerable<Income> Incomes
        {
            get { return _incomes; }
            set
            {
                _incomes = value;
                OnPropertyChanged(nameof(Incomes));
            }
        }

        private IEnumerable<Expense> _expenses;

        public IEnumerable<Expense> Expenses
        {
            get { return _expenses; }
            set
            {
                _expenses = value;
                OnPropertyChanged(nameof(Expenses));
            }
        }

        public void AddIncomes(IEnumerable<Income> incomes)
        {
            Incomes = incomes.ToList();
            OnPropertyChanged(nameof(Incomes));
        }

        public void AddExpenses(IEnumerable<Expense> expenses)
        {
            Expenses = expenses.ToList();
            OnPropertyChanged(nameof(Expenses));
        }

        public ICommand GetAllTransactionsCommand { get; }

        public TransactionHistoryViewModel(IDataService<Income> incomeDataService, 
            IDataService<Expense> expenseDataService)
        {
            GetAllTransactionsCommand = new GetAllTransactionsCommand(this, incomeDataService, expenseDataService);
        }

    }
}
