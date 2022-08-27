using BudgetControlApp.Domain.Models;
using BudgetControlApp.Domain.Services;
using BudgetControlApp.UWP.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.UWP.Services
{
    public class ExpenseDataService : IDataService<Expense>
    {
        private readonly BudgetControlAppDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Expense> _nonQueryDataService;

        public ExpenseDataService(BudgetControlAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Expense>(contextFactory);
        }


        public async Task<Expense> Create(Expense entity)
        {
            return await _nonQueryDataService.Create(entity);


        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Expense> Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Expense entity = await context.Expenses.Include(a => a.ExpenseCategory).FirstOrDefaultAsync(e => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Expense> entities = await context.Expenses.Include(a => a.ExpenseCategory).ToListAsync();
                return entities;
            }
        }

        public async Task<Expense> Update(int id, Expense entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }


    }
}

