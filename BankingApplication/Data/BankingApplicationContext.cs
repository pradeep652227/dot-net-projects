using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankingApplication.Models;

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
            modelBuilder.Entity<User>()
                .HasCheckConstraint("CHK_User_CurrentBalance", "CurrentBalance >= CASE WHEN AccountType = 'Savings' THEN 5000 ELSE 10000 END");

            //one-to-many
            modelBuilder.Entity<User>()
                        .HasOne(u => u.Role)
                        .WithMany(r => r.Users)
                        .HasForeignKey(u => u.RoleId)
                        .OnDelete(DeleteBehavior.NoAction);
            //one-to-many
            modelBuilder.Entity<User>()
                        .HasOne(u => u.Bank)
                        .WithMany(b => b.Users)
                        .HasForeignKey(u => u.BankId)
                        .OnDelete(DeleteBehavior.NoAction);          
            
            //one-to-many
            modelBuilder.Entity<User>()
                        .HasOne(u => u.UserAccount)
                        .WithMany(b => b.Users)
                        .HasForeignKey(u => u.AccountType)
                        .OnDelete(DeleteBehavior.NoAction);
                        
        }


        public DbSet<BankingApplication.Models.User> User { get; set; } = default!;

        public DbSet<BankingApplication.Models.Bank> Bank { get; set; } = default!;
        public DbSet<BankingApplication.Models.AccountType> AccountType { get; set; } = default!;
        public DbSet<BankingApplication.Models.UserRole> UserRole { get; set; } = default!;

    }
}
