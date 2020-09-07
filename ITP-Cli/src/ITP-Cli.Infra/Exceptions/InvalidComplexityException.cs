using System;

namespace ITP_Cli.Infra.Exceptions
{
    public class InvalidComplexityException : Exception
    {
        public InvalidComplexityException(string itemValue)
            : base(string.Format("{0} is not a valid value for COMPLEXITY property", itemValue))
        {
        }
    }
}