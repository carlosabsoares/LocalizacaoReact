using Inlog.Desafio.Backend.Application.Configuration.Events;
using Inlog.Desafio.Backend.Application.Configuration.Queries;
using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Domain.Repositories;

namespace Inlog.Desafio.Backend.Application.Commands.AppVeiculos.GetVeiculos
{
    public class GetListarVeiculosHandler : IQueryHandler<GetListarVeiculosQuery>
    {
        private readonly IVeiculosRepository _repository;

        public GetListarVeiculosHandler(IVeiculosRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEvent> Handle(GetListarVeiculosQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.FindAll();

            if (result.Any())
            {
                return new ResultEvent(true, result);
            }
            else
            {
                return new ResultEvent(true, new List<Veiculo>());
            }
        }
    }
}