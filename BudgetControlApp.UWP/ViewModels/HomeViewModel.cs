using BudgetControlApp.Domain.Models;
using BudgetControlApp.Domain.Services;
using BudgetControlApp.Domain.Services.TransactionServices;
using BudgetControlApp.UWP.Commands;
using BudgetControlApp.UWP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetControlApp.UWP.ViewModels
{
    public class HomeViewModel:ViewModelBase
    {
        public List<string> TransactionTypes { get; } = new List<string>() { "Доходы", "Расходы"};

        private List<TransactionCategory> _transactionCategories = new List<TransactionCategory>();

        public List<TransactionCategory> TransactionCategories
        {
            get { return _transactionCategories; }
            set 
            {
                _transactionCategories = value;
                OnPropertyChanged(nameof(TransactionCategories));
            }
        }

        public void AddTransactionCategory(IEnumerable<TransactionCategory> transactionCategories)
        {
            TransactionCategories = transactionCategories.ToList();
            OnPropertyChanged(nameof(TransactionCategories));
        }



        private TransactionCategory _selectedTransactionCategory;
        public TransactionCategory SelectedTransactionCategory
        {
            get
            {
                return _selectedTransactionCategory;
            }
            set
            {
                _selectedTransactionCategory = value;
                OnPropertyChanged(nameof(SelectedTransactionCategory));
                OnPropertyChanged(nameof(CategoryId));
            }
        }

        private string selectedTransactionType;
        public string SelectedTransactionType
        {
            get
            {
                return selectedTransactionType;
            }
            set
            {
                selectedTransactionType = value;
                OnPropertyChanged(nameof(SelectedTransactionType));
            }
        }

        private double _balance;
        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        private double _amount;
        public double Amount 
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public int CategoryId
        {
            get => SelectedTransactionCategory.Id;
        }

        private string comment;
        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public MessageViewModel StatusMessageViewModel { get; }

        public string StatusMessage
        {
            set => StatusMessageViewModel.Message = value;
        }



        public ICommand AddTransactionCommand { get;}
        public ICommand GetTransactionCategoriesCommand { get; }
        public ICommand GetCurrentAccountBalanceCommand { get; }

        public HomeViewModel(IAddIncomeService addIncomeService, IAddExpenseService addExpenseService,
            IDataService<ExpenseCategory> expenseCategoryDataService,IDataService<IncomeCategory> incomeCategoryDataService,
            IDataService<Account> accountDataService)
        {
            Amount = 0;

            ErrorMessageViewModel = new MessageViewModel();
            StatusMessageViewModel = new MessageViewModel();

            GetTransactionCategoriesCommand = new GetTransactionCategoriesCommand(this, expenseCategoryDataService, incomeCategoryDataService);
            AddTransactionCommand = new AddTransactionCommand(this, addIncomeService, addExpenseService, accountDataService);
            GetCurrentAccountBalanceCommand = new GetCurrentAccountBalanceCommand(this, accountDataService);
        }


    }
}
