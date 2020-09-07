using DomainValidation.Interfaces.Specification;
using ITP_Cli.Engine.Models;

namespace ITP_Cli.Engine.Specs
{
    public class IsMoneyFormatAccepted : ISpecification<TsvItem>
    {
        public bool IsSatisfiedBy(TsvItem entity)
        {
            if (entity.SavingAmount == string.Empty)
                return true;

            float money;
            return float.TryParse(entity.SavingAmount, out money);
        }
    }
}