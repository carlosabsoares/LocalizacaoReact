using Inlog.Desafio.Backend.Application.Commands;
using Inlog.Desafio.Backend.Domain.Models;
using Xunit;

namespace Inlog.Desafio.Backend.Test._02___Application.Inlog.Desafio.Backend.Application.Commands.AppVeiculos
{
    public class PostVeiculosCommandTest
    {
        [Fact]
        public void Verificar_PostCampanhaCommand_Valido()
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

            validateCommand.Validate();

            Assert.True(validateCommand.Valid);
            Assert.False(validateCommand.Invalid);

            Assert.Equal("Chassi", validateCommand.Chassi);
            Assert.Equal("Cor", validateCommand.Cor);
            Assert.Equal("Descricao", validateCommand.Descricao);
            Assert.Equal("Placa", validateCommand.Placa);
            Assert.Equal(TipoVeiculo.Onibus, validateCommand.TipoVeiculo);
        }

        [Fact]
        public void Verificar_PostCampanhaCommand_Invalido_TipoVeiculo()
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
                Placa = "Placa"
            };

            validateCommand.Validate();

            Assert.False(validateCommand.Valid);
            Assert.True(validateCommand.Invalid);

            Assert.True(validateCommand.Notifications.Count == 1);

            var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;

            Assert.Equal("TipoVeiculo não é válido", _notification[0].Message);
            Assert.Equal("TipoVeiculo", _notification[0].Property);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("aasdddddddddddddddddddddddddddddddddddddddddddddddddddddassssssssssssssssssssssssssssssdaasdewfdgsfsdgfregfdgjbfdjgjdanfdnsfjbyuvdsyhbjsad vkasdh")]
        public void Verificar_PostCampanhaCommand_Invalido_Chassi(string param)
        {
            PostVeiculosCommand validateCommand = new PostVeiculosCommand()
            {
                Chassi = param,
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

            validateCommand.Validate();

            Assert.False(validateCommand.Valid);
            Assert.True(validateCommand.Invalid);

            Assert.True(validateCommand.Notifications.Count == 1);

            var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;

            Assert.Equal("Chassi não é valido", _notification[0].Message);
            Assert.Equal("Chassi", _notification[0].Property);
        }
    }
}