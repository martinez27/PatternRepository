﻿using Microsoft.EntityFrameworkCore;
using PatternRepository.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Infraestructure.Data
{
    public class AppEntitiesContext : DbContext
    {
        public AppEntitiesContext(DbContextOptions<AppEntitiesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movement> Movements { get; set; }
    }
}
