using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Domain.Repositories
{
    public interface ICoordenadasRepository : ICudRepository
    {
        Task<Coordenadas> FindByCoordenadas(float latitude, float longitude);

        Task<Coordenadas> FindById(int id);

        Task<List<Coordenadas>> FindAll();
    }
}