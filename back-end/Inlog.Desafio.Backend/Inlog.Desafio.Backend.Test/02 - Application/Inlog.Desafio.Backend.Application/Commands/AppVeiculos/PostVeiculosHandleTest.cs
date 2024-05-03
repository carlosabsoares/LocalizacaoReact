using Inlog.Desafio.Backend.Application.Commands;
using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Domain.Repositories;
using Moq;
using Xunit;

namespace Inlog.Desafio.Backend.Test._02___Application.Inlog.Desafio.Backend.Application.Commands.AppVeiculos
{
    public class PostVeiculosHandleTest
    {
        private readonly Mock<ICudRepository> mockRepository = new();
        private readonly Mock<ICoordenadasRepository> mockCoordenadas = new();

        [Fact]
        public async Task Verifica_PostVeiculosHandle_Command_Valido()
        {
            PostVeiculosCommand validateCommand = new PostVeiculosCommand()
            {
                Chassi = "Chassi",
                Coordenadas = new Coordenadas()
                {
                    Id = 1,
                    Latitude = 2,
                    Longitude = 3
                },
                Cor = "Cor",
                Descricao = "Descricao",
                Placa = "Placa",
                TipoVeiculo = TipoVeiculo.Onibus
            };

            Coordenadas coordenadas = new()
            {
                Id = 1,
                Latitude = 2,
                Longitude = 3
            };

            mockCoordenadas.Setup(x => x.FindByCoordenadas(It.IsAny<float>(), It.IsAny<float>())).ReturnsAsync(coordenadas);
            mockRepository.Setup(x => x.Add<Veiculo>(It.IsAny<Veiculo>())).ReturnsAsync(true);

            var handlerDemo = new PostVeiculosHandle(mockRepository.Object, mockCoordenadas.Object);
            var result = await handlerDemo.Handle(validateCommand, new CancellationToken(true));

            Assert.True(result.Success);
            Assert.True((bool)result.Data);

            mockCoordenadas.Verify(x => x.FindByCoordenadas(It.IsAny<float>(), It.IsAny<float>()), Times.Once);
            mockRepository.Verify(x => x.Add(It.IsAny<Veiculo>()), Times.Once);
        }

        [Fact]
        public async Task Verifica_PostVeiculosHandle_Command_Invalido_Add()
        {
            PostVeiculosCommand validateCommand = new PostVeiculosCommand()
            {
                Chassi = "Chassi",
                Coordenadas = new Coordenadas()
                {
                    Id = 1,
                    Latitude = 2,
                    Longitude = 3
                },
                Cor = "Cor",
                Descricao = "Descricao",
                Placa = "Placa",
                TipoVeiculo = TipoVeiculo.Onibus
            };

            Coordenadas coordenadas = new()
            {
                Id = 1,
                Latitude = 2,
                Longitude = 3
            };

            mockCoordenadas.Setup(x => x.FindByCoordenadas(It.IsAny<float>(), It.IsAny<float>())).ReturnsAsync(coordenadas);
            mockRepository.Setup(x => x.Add<Veiculo>(It.IsAny<Veiculo>())).ReturnsAsync(false);

            var handlerDemo = new PostVeiculosHandle(mockRepository.Object, mockCoordenadas.Object);
            var result = await handlerDemo.Handle(validateCommand, new CancellationToken(true));

            Assert.True(result.Success);
            Assert.False((bool)result.Data);

            mockCoordenadas.Verify(x => x.FindByCoordenadas(It.IsAny<float>(), It.IsAny<float>()), Times.Once);
            mockRepository.Verify(x => x.Add(It.IsAny<Veiculo>()), Times.Once);
        }
    }
}