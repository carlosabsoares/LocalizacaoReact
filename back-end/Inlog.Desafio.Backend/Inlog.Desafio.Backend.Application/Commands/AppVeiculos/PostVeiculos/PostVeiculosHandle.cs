using Flunt.Notifications;
using Inlog.Desafio.Backend.Application.Configuration.Commands;
using Inlog.Desafio.Backend.Application.Configuration.Events;
using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Domain.Repositories;

namespace Inlog.Desafio.Backend.Application.Commands
{
    public class PostVeiculosHandle : Notifiable, ICommandHandler<PostVeiculosCommand>
    {
        private ICudRepository _repository;
        private ICoordenadasRepository _coordenadasRepository;

        public PostVeiculosHandle(ICudRepository repository, ICoordenadasRepository coordenadasRepository)
        {
            _repository = repository;
            _coordenadasRepository = coordenadasRepository;
        }

        public async Task<IEvent> Handle(PostVeiculosCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new ResultEvent(false, request.Notifications);

            var coodenadasBase = await _coordenadasRepository.FindByCoordenadas(request.Coordenadas.Latitude,
                                                                                 request.Coordenadas.Longitude);

            var _entity = new Veiculo()
            {
                Chassi = request.Chassi,
                Cor = request.Cor,
                Descricao = request.Descricao,
                Placa = request.Placa,
                TipoVeiculo = request.TipoVeiculo
            };

            if (coodenadasBase != null)
            {
                _entity.CoordenadasId = coodenadasBase.Id;
            }
            else
            {
                _entity.Coordenadas = new Coordenadas
                {
                    Latitude = request.Coordenadas.Latitude,
                    Longitude = request.Coordenadas.Longitude,
                };
            }

            var result = await _repository.Add(_entity);

            return new ResultEvent(true, result);
        }
    }
}