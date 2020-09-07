using System.Threading.Tasks;
using ITP_Cli.Infra.Events;
using MediatR;

namespace ITP_Cli.Infra.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Send specific query to its corresponding Query Handler
        public Task<TResponse> ExecuteQuery<T, TResponse>(T query) where T : IRequest<TResponse>
        {
            return _mediator.Send(query);
        }

        //Fire specific event to all listener
        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}