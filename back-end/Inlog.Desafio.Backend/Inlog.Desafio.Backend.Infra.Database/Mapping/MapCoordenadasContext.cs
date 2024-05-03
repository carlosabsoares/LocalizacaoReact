using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Infra.Database.Mapping
{
    public static class MapCoordenadasContext
    {
        public static void MapCoordenadas(this DataContext context, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coordenadas>().ToTable("Coordenadas");

            modelBuilder.Entity<Coordenadas>().HasKey(x => x.Id);
            modelBuilder.Entity<Coordenadas>().Property(x => x.Latitude);
            modelBuilder.Entity<Coordenadas>().Property(x => x.Longitude);
        }
    }
}