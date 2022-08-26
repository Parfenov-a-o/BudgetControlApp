using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.UWP.ViewModels.Factories
{
    public interface IBudgetControlAppViewModelFactory<T> where T:ViewModelBase
    {
        T CreateViewModel();
    }
}
