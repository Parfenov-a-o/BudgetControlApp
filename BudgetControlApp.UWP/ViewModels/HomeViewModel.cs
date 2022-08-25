using BudgetControlApp.Domain.Models;
using BudgetControlApp.Domain.Services;
using BudgetControlApp.UWP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.UWP.ViewModels
{
    public class HomeViewModel:ViewModelBase
    {
        private Transaction _transaction { get; set; }

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

        public HomeViewModel()
        {


            Amount = GetAmount().Result;

            //accountService.GetAll().result.count();
            //accountService.create(new account { name = "user", balance = 200 });
            //var item = accountService.getall().result.count();
        }

        public async Task<double> GetAmount()
        {
            IDataService<Account> accountService = new GenericDataService<Account>(new BudgetControlAppDbContextFactory());

            var entity = await accountService.Get(1);
            
            return entity.Balance;
        }


    }
}
