using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Entities.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Infraestructure.Data.Configuration
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));

            builder.HasKey(a => a.AccountNumber);
            builder.Property(a => a.AccountNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(a => a.AccounType)
                .HasMaxLength(10)
                .IsRequired()
                .HasConversion(
                value => value.ToString(),
                value => (AccountType)Enum.Parse(typeof(AccountType), value));

            builder.Property(a => a.Balance)
                .HasPrecision(28, 8)
                .IsRequired();

            builder.Property(a => a.State)
                .IsRequired();

            builder.Property(a => a.CustomerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.HasOne(a => a.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CustomerId)
                .HasConstraintName("FK_Account_To_Customer");
        }
    }
}
