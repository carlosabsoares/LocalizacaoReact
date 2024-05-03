using AutoMapper;
using Inlog.Desafio.Backend.Application.Configuration.Mapper;

namespace Inlog.Desafio.Backend.WebApi.DependencyMap
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            var config = AutoMapperConfig.RegisterMapper();

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}