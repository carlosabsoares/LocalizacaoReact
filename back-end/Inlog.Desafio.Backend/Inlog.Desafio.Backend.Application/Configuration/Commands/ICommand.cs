using Flunt.Validations;
using Inlog.Desafio.Backend.Application.Configuration.Events;
using MediatR;

namespace Inlog.Desafio.Backend.Application.Configuration.Commands
{
    public interface ICommand : IRequest<IEvent>, IValidatable
    {
    }
}