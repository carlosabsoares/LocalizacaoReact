using AutoMapper;

namespace Inlog.Desafio.Backend.Application.Configuration.Mapper
{
    public class DomainToDtoMap : Profile
    {
        public DomainToDtoMap()
        {
            // Usar o .ReverseMap apenas quando necessário
            //CreateMap<User, UserDto>();
        }
    }
}