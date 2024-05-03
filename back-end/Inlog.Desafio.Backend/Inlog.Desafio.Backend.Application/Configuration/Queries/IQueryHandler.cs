using Inlog.Desafio.Backend.Application.Configuration.Events;
using MediatR;

namespace Inlog.Desafio.Backend.Application.Configuration.Queries
{
    public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, IEvent> where TQuery : IQuery
    {
    }
}