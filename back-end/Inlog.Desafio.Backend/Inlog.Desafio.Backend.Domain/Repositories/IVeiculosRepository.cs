using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Domain.Repositories
{
    public interface IVeiculosRepository : ICudRepository
    {
        Task<Veiculo> FindById(int id);

        Task<List<Veiculo>> FindAll();
    }
}