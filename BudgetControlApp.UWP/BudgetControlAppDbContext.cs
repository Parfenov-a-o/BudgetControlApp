using BudgetControlApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace BudgetControlApp.UWP
{
    public class BudgetControlAppDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }


        public string DbPath { get; }

        public BudgetControlAppDbContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }

    }
}
