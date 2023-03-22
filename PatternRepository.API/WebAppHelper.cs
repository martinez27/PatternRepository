using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Service;
using PatternRepository.Core.Services;
using PatternRepository.Infraestructure.Data;
using PatternRepository.Infraestructure.Filters;
using PatternRepository.Infraestructure.Repositories;

namespace PatternRepository.API
{
    public static class WebAppHelper
    {
        public static WebApplication CreateWebApp(this WebApplicationBuilder builder)
        {
            //Controles y filtros

            builder.Services.AddControllers(options =>
                options.Filters.Add<GlobalExceptionFilter>()
            );

            //Filtro de Validacion

            builder.Services.AddMvc(options =>
                options.Filters.Add<ValidationFilter>()
            )
                .AddFluentValidation(options =>
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

            //Documentacion

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Transacciones",
                    Version = "v1"
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PatternRepository.API.xml"));
            });

            //Construir

            return builder.Build();
        }

        //Configura Middlewares

        public static WebApplication ConfigureWebApp(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json","Transacciones API v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                });


            return app;
        }

    }
}
