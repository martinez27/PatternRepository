using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Service;
using PatternRepository.Core.Services;
using PatternRepository.Infraestructure.Data;
using PatternRepository.Infraestructure.Filters;
using PatternRepository.Infraestructure.Repositories;

namespace PatternRepository.API
{
    public class WebAppHelper
    {
        public static void CreateWebApp(WebApplicationBuilder builder)
        {
            //Controles y filtros

            builder.Services.AddControllers(options =>
                options.Filters.Add<GlobalExceptionFilter>()
            );

            //Filtro de Validacion

            builder.Services.AddMvc(options =>
                options.Filters.Add<ValidationFilter>()                
            )
                .AddFluentValidation(options=>
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            //Base de datos

            string connectionString = builder.Configuration.GetConnectionString("PatronRepositorioDB");

            builder.Services.AddDbContext<AppEntitiesContext>(options =>
            options.UseSqlServer(connectionString));

            //Repositorios

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Servicios

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IMovementService, MovementService>();

            //Unidad de Trabajo

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        
    }
}
