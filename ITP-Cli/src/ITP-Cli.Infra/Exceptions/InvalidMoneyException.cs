using System;

namespace ITP_Cli.Infra.Exceptions
{
    public class InvalidMoneyException : Exception
    {
        public InvalidMoneyException(string msg)
            : base(msg)
        {
        }
    }
}