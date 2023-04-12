using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatternRepository.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Infraestructure
{
    public static class PrepareDB
    {
        public static void Execute(IApplicationBuilder app) 
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedDate(serviceScope.ServiceProvider.GetRequiredService<AppEntitiesContext>());
            }
        }

        private static void SeedDate(AppEntitiesContext context)
        {

            if (context.Database.GetPendingMigrations().Any())
            {
                Console.WriteLine("---> Appling Migration");
                context.Database.Migrate();
            }

            if (!context.Customers.Any())
            {
                Console.WriteLine("---> Adding daata - seeding ...");
                context.Customers.Add(new Core.Entities.Customer { 
                Id = "123",
                Name = "Martin",
                Gender = "Masculino",
                Age = 21,
                Address = "Cra 53",
                Phone = "3158718020",
                Password = "1234",
                State = true
                });

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> Already have data - not seeding");
            }
        }
    }
}
