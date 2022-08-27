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

        //public BudgetControlAppDbContext()
        //{

        //    var path = Windows.Storage.ApplicationData.Current.RoamingFolder.Path;

        //    DbPath = System.IO.Path.Combine(path, "BudgetControlAppDB.db");

        //    //Database.EnsureCreated();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //var path = Windows.Storage.ApplicationData.Current.SharedLocalFolder.Path;

        //    //var DbPath = System.IO.Path.Combine(path, "BudgetControlAppDB.db");

        //    optionsBuilder.UseSqlite($"Data Source=BudgetControlAppDB.db");

        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
