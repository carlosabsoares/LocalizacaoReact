using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Infra.Database.Mapping
{
    public static class MapVeiculoContext
    {
        public static void MapVeiculo(this DataContext context, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>().ToTable("Veiculo");

            modelBuilder.Entity<Veiculo>().HasKey(x => x.Id);
            modelBuilder.Entity<Veiculo>().Property(x => x.Chassi);
            modelBuilder.Entity<Veiculo>().Property(x => x.TipoVeiculo);
            modelBuilder.Entity<Veiculo>().Property(x => x.Cor);
            modelBuilder.Entity<Veiculo>().Property(x => x.Descricao);
            modelBuilder.Entity<Veiculo>().Property(x => x.Placa);
            modelBuilder.Entity<Veiculo>().Property(x => x.CoordenadasId);
            modelBuilder.Entity<Veiculo>().HasIndex(x => x.CoordenadasId);

            modelBuilder.Entity<Veiculo>().HasOne(p => p.Coordenadas).WithMany().HasForeignKey(f => f.CoordenadasId);
        }
    }
}