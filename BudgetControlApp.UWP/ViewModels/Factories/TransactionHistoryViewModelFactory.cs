using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.UWP.ViewModels.Factories
{
    public class TransactionHistoryViewModelFactory : IBudgetControlAppViewModelFactory<TransactionHistoryViewModel>
    {
        public TransactionHistoryViewModel CreateViewModel()
        {
            return new TransactionHistoryViewModel();
        }
    }
}
