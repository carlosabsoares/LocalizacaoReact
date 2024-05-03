using Inlog.Desafio.Backend.Application.Configuration.Events;
using MediatR;

namespace Inlog.Desafio.Backend.Application.Configuration.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, IEvent> where TCommand : ICommand
    {
    }
}