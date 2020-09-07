using System;
using System.Threading;
using System.Threading.Tasks;
using ITP_Cli.Infra.Notifications;
using MediatR;

namespace ITP_Cli.Engine
{
    //Event listener that listen for any domain error notification and take corresponding action
    public class EventHandler : INotificationHandler<DomainErrorNotification>
    {
        public Task Handle(DomainErrorNotification notification, CancellationToken cancellationToken)
        {
            ConsoleWriter.WriteNotification(notification);
            Environment.Exit(-1);
            return Task.CompletedTask;
        }
    }
}