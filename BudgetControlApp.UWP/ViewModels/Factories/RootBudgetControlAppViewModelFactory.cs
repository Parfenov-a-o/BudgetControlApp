using BudgetControlApp.UWP.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.UWP.ViewModels.Factories
{
    public class RootBudgetControlAppViewModelFactory : IRootBudgetControlAppViewModelFactory
    {
        private readonly IBudgetControlAppViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IBudgetControlAppViewModelFactory<TransactionHistoryViewModel> _transactionHistoryViewModelFactory;
        

        public RootBudgetControlAppViewModelFactory(IBudgetControlAppViewModelFactory<HomeViewModel> homeViewModelFactory, 
            IBudgetControlAppViewModelFactory<TransactionHistoryViewModel> transactionHistoryViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _transactionHistoryViewModelFactory = transactionHistoryViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.TransactionHistory:
                    return _transactionHistoryViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
