using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using BankingApplication.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApplication.Data.FluentAPI_Configurations.UserConfigurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureConstraints(builder);
            ConfigureRelations(builder);
        }

        private void ConfigureConstraints(EntityTypeBuilder<User> builder)
        {
            builder
           .HasCheckConstraint("CHK_User_CurrentBalance", "CurrentBalance >= CASE WHEN AccountType = 'Savings' THEN 5000 ELSE 10000 END");

        }

        private void ConfigureRelations(EntityTypeBuilder<User> builder)
        {
            //one-to-many
            builder
           .HasOne(u => u.Role)
           .WithMany(r => r.Users)
           .HasForeignKey(u => u.RoleId)
           .OnDelete(DeleteBehavior.NoAction);

            //one-to-many
            builder
           .HasOne(u => u.Bank)
           .WithMany(b => b.Users)
           .HasForeignKey(u => u.BankId)
           .OnDelete(DeleteBehavior.NoAction);

            //one-to-many
            builder
           .HasOne(u => u.UserAccount)
           .WithMany(b => b.Users)
           .HasForeignKey(u => u.AccountType)
           .OnDelete(DeleteBehavior.NoAction);
        }
    }

}

