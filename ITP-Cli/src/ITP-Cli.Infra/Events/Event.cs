using System;
using MediatR;

namespace ITP_Cli.Infra.Events
{
    //Base event as base notification
    public abstract class Event : INotification
    {
        protected Event()
        {
            Timestamp = DateTime.Now;
        }

        //Stamp the current fired event with its equivalent execution time
        public DateTime Timestamp { get; }
    }
}