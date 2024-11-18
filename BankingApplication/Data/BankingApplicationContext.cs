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
        public BankingApplicationContext (DbContextOptions<BankingApplicationContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasCheckConstraint("CHK_User_CurrentBalance", "CurrentBalance >= CASE WHEN AccountType = 'Savings' THEN 5000 ELSE 10000 END");
        }


        public DbSet<BankingApplication.Models.User> User { get; set; } = default!;
    }
}
