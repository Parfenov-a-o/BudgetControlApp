using BudgetControlApp.Domain.Models;
using BudgetControlApp.Domain.Services;
using BudgetControlApp.UWP.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.UWP.Services
{
    public class AccountDataService : IDataService<Account>
    {
        private readonly BudgetControlAppDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(BudgetControlAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }


        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);


        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts.Include(a=>a.Transactions).FirstOrDefaultAsync(e => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts.Include(a => a.Transactions).ToListAsync();
                return entities;
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
