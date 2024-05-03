using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Domain.Repositories;
using Inlog.Desafio.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Infra.Database.Repositories
{
    public class CoordenadasRepository : CudRepository, ICoordenadasRepository
    {
        private readonly DataContext _context;

        public CoordenadasRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Coordenadas>> FindAll()
        {
            var _return = _context.Coordenadas.AsNoTracking().ToList();

            return _return;
        }

        public async Task<Coordenadas> FindByCoordenadas(float latitude, float longitude)
        {
            return await _context.Coordenadas.AsNoTracking()
                                                .FirstOrDefaultAsync(x => x.Longitude == longitude
                                                                       && x.Latitude.Equals(latitude));
        }

        public async Task<Coordenadas> FindById(int id)
        {
            return await _context.Coordenadas.AsNoTracking()
                                                   .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}