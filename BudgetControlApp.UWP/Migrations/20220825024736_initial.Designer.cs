using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BudgetControlApp.UWP;

namespace BudgetControlApp.UWP.Migrations
{
    [DbContext(typeof(BudgetControlAppDbContext))]
    [Migration("20220825024736_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.3");

            modelBuilder.Entity("BudgetControlApp.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balance");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BudgetControlApp.Domain.Models.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ExpenseCategories");
                });

            modelBuilder.Entity("BudgetControlApp.Domain.Models.IncomeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("IncomeCategories");
                });

            modelBuilder.Entity("BudgetControlApp.Domain.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<double>("Amount");

                    b.Property<string>("Comment");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Transaction");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Transaction");
                });

            modelBuilder.Entity("BudgetControlApp.Domain.Models.Expense", b =>
                {
                    b.HasBaseType("BudgetControlApp.Domain.Models.Transaction");

                    b.Property<int?>("ExpenseCategoryId");

                    b.HasIndex("ExpenseCategoryId");

                    b.ToTable("Expense");

                    b.HasDiscriminator().HasValue("Expense");
                });

            modelBuilder.Entity("BudgetControlApp.Domain.Models.Income", b =>
                {
                    b.HasBaseType("BudgetControlApp.Domain.Models.Transaction");

                    b.Property<int?>("IncomeCategoryId");

                    b.HasIndex("IncomeCategoryId");

                    b.ToTable("Income");

                    b.HasDiscriminator().HasValue("Income");
                });

            modelBuilder.Entity("BudgetControlApp.Domain.Models.Transaction", b =>
                {
                    b.HasOne("BudgetControlApp.Domain.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BudgetControlApp.Domain.Models.Expense", b =>
                {
                    b.HasOne("BudgetControlApp.Domain.Models.ExpenseCategory", "ExpenseCategory")
                        .WithMany()
                        .HasForeignKey("ExpenseCategoryId");
                });

            modelBuilder.Entity("BudgetControlApp.Domain.Models.Income", b =>
                {
                    b.HasOne("BudgetControlApp.Domain.Models.IncomeCategory", "IncomeCategory")
                        .WithMany()
                        .HasForeignKey("IncomeCategoryId");
                });
        }
    }
}
