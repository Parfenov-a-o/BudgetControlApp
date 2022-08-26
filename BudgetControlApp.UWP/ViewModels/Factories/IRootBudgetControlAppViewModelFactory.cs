using BudgetControlApp.UWP.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.UWP.ViewModels.Factories
{
    public interface IRootBudgetControlAppViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
