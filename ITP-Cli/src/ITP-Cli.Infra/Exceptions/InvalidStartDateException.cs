using System;

namespace ITP_Cli.Infra.Exceptions
{
    public class InvalidStartDateException : Exception
    {
        public InvalidStartDateException(string msg)
            : base(msg)
        {
        }
    }
}