using BillsPaymentSystem.Data.EntityConfigurations;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data
{
    public class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext()
        {

        }

        public BillsPaymentSystemContext(DbContextOptions options)
            : base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BillsPaymentSystem;Integrated security=true",
                    s => s.MigrationsAssembly("BillsPaymentSystem.Data"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());

            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());

            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }
    }
}
