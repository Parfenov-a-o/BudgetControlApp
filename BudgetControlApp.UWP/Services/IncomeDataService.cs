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
    public class IncomeDataService : IDataService<Income>
    {
        private readonly BudgetControlAppDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Income> _nonQueryDataService;

        public IncomeDataService(BudgetControlAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Income>(contextFactory);
        }


        public async Task<Income> Create(Income entity)
        {
            return await _nonQueryDataService.Create(entity);


        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Income> Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Income entity = await context.Incomes.Include(a => a.IncomeCategory).FirstOrDefaultAsync(e => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Income>> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Income> entities = await context.Incomes.Include(a => a.IncomeCategory).ToListAsync();
                return entities;
            }
        }

        public async Task<Income> Update(int id, Income entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }


    }
}
