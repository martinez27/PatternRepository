using PatternRepository.API;

WebApplication.CreateBuilder(args)
    .CreateWebApp() //Trae Servicios
    .ConfigureWebApp() // Configura
    .Run();