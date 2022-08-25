using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.UWP
{
    public class BudgetControlAppDbContextFactory
    {
        public BudgetControlAppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<BudgetControlAppDbContext>();
            options.UseSqlite("Data Source=BudgetControlAppDB.db");

            return new BudgetControlAppDbContext(options.Options);
        }
    }
}
