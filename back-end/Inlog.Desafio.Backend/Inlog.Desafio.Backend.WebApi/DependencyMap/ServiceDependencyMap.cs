using AutoMapper;

namespace Inlog.Desafio.Backend.WebApi.DependencyMap
{
    public static class ServiceDependencyMap
    {
        public static void ServiceMap(this IServiceCollection services, IConfiguration configuration)
        {
            // ----- SERVICES --------
            services.AddHttpClient();

            // Biblioteca para manipulação do JWT
            //services.AddScoped<IJwtService>(sp => new JwtService(configuration.GetValue<string>("APP_KEY")));

            var config = new MapperConfiguration(cfg =>
            {
                //   cfg.CreateMap<PostDriverCommand, DriverEntity>().ReverseMap();
            });
        }
    }
}