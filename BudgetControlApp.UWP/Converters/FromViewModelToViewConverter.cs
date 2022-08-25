using BudgetControlApp.UWP.ViewModels;
using BudgetControlApp.UWP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BudgetControlApp.UWP.Converters
{
    public class FromViewModelToViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(value is ViewModelBase baseViewModel)
            {
                if (baseViewModel is HomeViewModel)
                {
                    HomeView homeView = new HomeView();
                    homeView.DataContext = baseViewModel;

                    return homeView;
                }
                if(baseViewModel is TransactionHistoryViewModel)
                {
                    TransactionHistoryView transactionHistoryView = new TransactionHistoryView();
                    transactionHistoryView.DataContext = baseViewModel;

                    return transactionHistoryView;
                }
                throw new NotImplementedException();
            }
            else
            {
                return new HomeView();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
