using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatternRepository.Core.Entities;

namespace PatternRepository.Infraestructure.Data.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Age)
                .IsRequired();

            builder.Property(c => c.Address)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.State)
                .IsRequired();
        }
    }
}
