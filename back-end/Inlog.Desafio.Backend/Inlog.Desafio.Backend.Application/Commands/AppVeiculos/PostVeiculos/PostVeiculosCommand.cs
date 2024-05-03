using Flunt.Notifications;
using Flunt.Validations;
using Inlog.Desafio.Backend.Application.Configuration.Commands;
using Inlog.Desafio.Backend.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Inlog.Desafio.Backend.Application.Commands
{
    public class PostVeiculosCommand : Notifiable, ICommand
    {
        [MinLength(2)]
        [MaxLength(50)]
        public string Chassi { get; set; }

        public TipoVeiculo TipoVeiculo { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string Cor { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        public string Descricao { get; set; }

        [MinLength(2)]
        [MaxLength(70)]
        public string Placa { get; set; }

        public Coordenadas Coordenadas { get; set; } = null!;

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Chassi, "Chassi", "Chassi não é valido")
                    .IsTrue((Chassi.Length > 2), "Chassi", "Chassi não é valido")
                    .IsTrue((Chassi.Length < 50), "Chassi", "Chassi não é valido")
                    .IsNotNullOrEmpty(Cor, "Cor", "Cor não é valida")
                    .IsNotNullOrEmpty(Descricao, "Descricao", "Descricao não é valida")
                    .IsNotNullOrEmpty(Placa, "Placa", "Placa não é valida")
                    .IsTrue(OperationTypeValidation(TipoVeiculo), "TipoVeiculo", "TipoVeiculo não é válido")
                    .IsTrue((Coordenadas != null), "Coordenadas", "Coordenadas não são válidas")
            );
        }

        private bool OperationTypeValidation(TipoVeiculo tipoVeiculo)
        {
            bool _return = false;

            if ((int)tipoVeiculo >= Enum.GetValues(typeof(TipoVeiculo)).Cast<int>().Min() &&
               (int)tipoVeiculo <= Enum.GetValues(typeof(TipoVeiculo)).Cast<int>().Max())
                _return = true;

            return _return;
        }
    }
}