using ITP_Cli.Infra.Events;

namespace ITP_Cli.Infra.Notifications
{
    //domain notification event
    public class DomainErrorNotification : Event
    {
        public DomainErrorNotification(string msg)
        {
            Message = msg;
        }

        public string Message { get; }
    }
}