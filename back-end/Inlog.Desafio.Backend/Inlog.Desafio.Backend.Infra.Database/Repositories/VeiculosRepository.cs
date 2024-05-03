using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Domain.Repositories;
using Inlog.Desafio.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Infra.Database.Repositories
{
    public class VeiculosRepository : CudRepository, IVeiculosRepository
    {
        private readonly DataContext _context;

        public VeiculosRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Veiculo>> FindAll()
        {
            var _return = _context.Veiculos.AsNoTracking().Include(x => x.Coordenadas).ToList();

            return _return;
        }

        public async Task<Veiculo> FindById(int id)
        {
            return _context.Veiculos.AsNoTracking().Include(x => x.Coordenadas).FirstOrDefault(x => x.Id == id);
        }
    }
}