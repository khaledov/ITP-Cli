using System;
using DomainValidation.Interfaces.Specification;
using ITP_Cli.Engine.Models;

namespace ITP_Cli.Engine.Specs
{
    public class IsStartDateFormatAccepted : ISpecification<TsvItem>
    {
        public bool IsSatisfiedBy(TsvItem o)
        {
            DateTime dt;
            return DateTime.TryParse(o.StartDate, out dt);
        }
    }
}