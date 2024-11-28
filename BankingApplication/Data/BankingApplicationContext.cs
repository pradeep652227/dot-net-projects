using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankingApplication.Models;
using BankingApplication.Data.FluentAPI_Configurations.UserConfigurations;

namespace BankingApplication.Data
{
    public class BankingApplicationContext : DbContext
    {
        public BankingApplicationContext(DbContextOptions<BankingApplicationContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
        }


        public DbSet<BankingApplication.Models.User> Users { get; set; } = default!;

        public DbSet<BankingApplication.Models.Bank> Banks { get; set; } = default!;
        public DbSet<BankingApplication.Models.AccountType> AccountTypes { get; set; } = default!;
        public DbSet<BankingApplication.Models.UserRole> UserRoles { get; set; } = default!;
        public DbSet<BankingApplication.Models.TransactionType> TransactionTypes { get; set; } = default!;
        public DbSet<BankingApplication.Models.Transaction> Transactions { get; set; } = default!;
        public DbSet<BankingApplication.Models.Address> Addresses { get; set; } = default!;
    }


}
