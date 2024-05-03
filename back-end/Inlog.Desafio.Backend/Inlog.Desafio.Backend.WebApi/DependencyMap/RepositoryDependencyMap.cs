//using Imperium.Api.Infra.Repositories.Product;

using Inlog.Desafio.Backend.Domain.Repositories;
using Inlog.Desafio.Backend.Infra.Database.Repositories;

namespace Inlog.Desafio.Backend.WebApi.DependencyMap
{
    public static class RepositoryDependencyMap
    {
        public static void RepositoryMap(this IServiceCollection services)
        {
            services.AddScoped<ICudRepository, CudRepository>();
            services.AddScoped<ICoordenadasRepository, CoordenadasRepository>();
            services.AddScoped<IVeiculosRepository, VeiculosRepository>();
        }
    }
}