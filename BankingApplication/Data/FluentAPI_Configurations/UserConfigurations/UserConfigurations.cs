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
           .WithMany(r => r.users)
           .HasForeignKey(u => u.roleId)
           .OnDelete(DeleteBehavior.NoAction);

            //one-to-many
            builder
           .HasOne(u => u.Bank)
           .WithMany(b => b.users)
           .HasForeignKey(u => u.bankId)
           .OnDelete(DeleteBehavior.NoAction);

            //one-to-many
            builder
           .HasOne(u => u.UserAccount)
           .WithMany(b => b.users)
           .HasForeignKey(u => u.accountType)
           .OnDelete(DeleteBehavior.NoAction);

            //one-to-many
            builder
            .HasOne(u => u.Address)
            .WithMany(a => a.users)
            .HasForeignKey(u => u.addressId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }

}

