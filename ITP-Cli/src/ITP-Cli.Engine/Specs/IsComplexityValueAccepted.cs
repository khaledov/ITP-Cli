using System.Linq;
using DomainValidation.Interfaces.Specification;
using ITP_Cli.Engine.Models;
using Microsoft.Extensions.Options;

namespace ITP_Cli.Engine.Specs
{
    public class IsComplexityValueAccepted : ISpecification<TsvItem>
    {
        private readonly IOptions<ComplexitySettings> _configuration;

        public IsComplexityValueAccepted(IOptions<ComplexitySettings> configuration)
        {
            _configuration = configuration;
        }

        public bool IsSatisfiedBy(TsvItem o)
        {
            var valideValues = _configuration.Value?.ValidValues;
            valideValues.ToList().ForEach(item => item.Trim());
            return valideValues.Contains(o.Complexity.Trim());
        }
    }
}