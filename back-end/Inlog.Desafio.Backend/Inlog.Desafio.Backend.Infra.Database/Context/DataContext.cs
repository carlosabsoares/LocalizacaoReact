using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Infra.Database.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Infra.Database.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Coordenadas> Coordenadas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.MapCoordenadas(modelBuilder);
            this.MapVeiculo(modelBuilder);
        }
    }
}