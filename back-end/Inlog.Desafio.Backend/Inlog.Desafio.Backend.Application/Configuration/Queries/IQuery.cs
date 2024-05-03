using Flunt.Validations;
using Inlog.Desafio.Backend.Application.Configuration.Events;
using MediatR;

namespace Inlog.Desafio.Backend.Application.Configuration.Queries
{
    public interface IQuery : IRequest<IEvent>, IValidatable
    {
    }
}