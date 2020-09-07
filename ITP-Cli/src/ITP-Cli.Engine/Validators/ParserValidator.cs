using DomainValidation.Validation;
using ITP_Cli.Engine.Models;
using ITP_Cli.Engine.Specs;
using Microsoft.Extensions.Options;

namespace ITP_Cli.Engine.Validators
{
    public class ParserValidator : Validator<TsvItem>
    {
        public ParserValidator(IOptions<ComplexitySettings> configuration)
        {
            Add("ComplexityInRange",
                new Rule<TsvItem>(new IsComplexityValueAccepted(configuration),
                    "Complexity value is not within the accepted list of values"));
            Add("StartDateFormatAcceptance",
                new Rule<TsvItem>(new IsStartDateFormatAccepted(), "Start date is not in a correct format"));
            Add("MoneyFormatAcceptance",
                new Rule<TsvItem>(new IsMoneyFormatAccepted(), "Saving amount is not in a correct format"));
        }
    }
}