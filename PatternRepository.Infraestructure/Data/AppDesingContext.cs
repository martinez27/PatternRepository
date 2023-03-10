using Microsoft.EntityFrameworkCore;
using PatternRepository.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Infraestructure.Data
{
    public class AppDesingContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=PatronRepositorio; Integrated Security= True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        DbSet<Account> Accounts { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Movement> Movements { get; set; }

    }
}
