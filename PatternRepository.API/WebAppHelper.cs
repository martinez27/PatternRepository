using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PatternRepository.API.Response;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Repository;
using PatternRepository.Core.Interface.Service;
using PatternRepository.Core.Interface.Utils;
using PatternRepository.Core.Options;
using PatternRepository.Core.Services;
using PatternRepository.Core.Utils;
using PatternRepository.Infraestructure;
using PatternRepository.Infraestructure.Data;
using PatternRepository.Infraestructure.Filters;
using PatternRepository.Infraestructure.Options;
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

            //Opciones de Paginacion

            builder.Services.Configure<PaginationOptions>
                (builder.Configuration.GetSection(nameof(PaginationOptions)));


            //Filtro de Validacion

            builder.Services.AddMvc(options =>
                options.Filters.Add<ValidationFilter>()
            )
                .AddFluentValidation(options =>
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            //Base de datos

            string connectionName = builder.Environment.IsProduction() ? "PatronRepositorioDBProd" : "PatronRepositorioDB";

            builder.Services.AddDbContext<AppEntitiesContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(connectionName)));

            //Repositorios

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IAccountRepository,AccountRepository>();
            builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
            builder.Services.AddScoped<IMovementRepository,MovementRepository>();

            //Servicios

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IMovementService, MovementService>();

            //Unidad de Trabajo

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Opciones de Contraseña

            builder.Services.Configure<PasswordOptions>
                (builder.Configuration.GetSection(nameof(PasswordOptions)));

            //Servicio de Incriptacion

            builder.Services.AddSingleton<IPasswordHasher, PasswordService>();

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

            PrepareDB.Execute(app);

            return app;
        }

    }
}
