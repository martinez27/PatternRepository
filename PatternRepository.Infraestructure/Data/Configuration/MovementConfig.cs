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
    public class MovementConfig : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable(nameof(Movement));

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.Date)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(m => m.Type)
                .HasMaxLength(10)
                .IsRequired()
                .HasConversion(
                value => value.ToString(),
                value => (MovementType)Enum.Parse(typeof(MovementType), value));

            builder.Property(m => m.Value)
                .HasPrecision(28, 8)
                .IsRequired();

            builder.Property(m => m.Balance)
                .HasPrecision(28, 8)
                .IsRequired();

            builder.Property(m => m.AccountId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();

            builder.HasOne(m => m.Account)
                .WithMany(a => a.Movements)
                .HasForeignKey(m => m.AccountId)
                .HasConstraintName("FK_Movement_To_Account");
        }
    }
}
