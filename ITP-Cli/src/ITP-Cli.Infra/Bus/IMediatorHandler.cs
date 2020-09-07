using System.Threading.Tasks;
using ITP_Cli.Infra.Events;
using MediatR;

namespace ITP_Cli.Infra.Bus
{
    public interface IMediatorHandler
    {
        Task<TResponse> ExecuteQuery<T, TResponse>(T query) where T : IRequest<TResponse>;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}