using DomainValidation.Interfaces.Validation;
using ITP_Cli.Engine.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace ITP_Cli.Engine.UnitTest.Validation
{
   public class ValidatorTesting : IClassFixture<ServiceFixture>
    {
        public IConfiguration Configuration { get; set; }
        public ServiceProvider Service { get; set; }
        private TsvItem _item;

        public ValidatorTesting(ServiceFixture fixture)
        {
            Configuration = fixture.Configuration;
            Service = fixture.Service;
            _item = new TsvItem
            {
                Project = "1",
                Description = "Harmonize Lactobacillus acidophilus sourcing",
                StartDate = "2014-01-01 00:00:00.000",
                Category = "Dairy",
                Responsible = "Daisy Milks",
                SavingAmount = "141415.942696",
                Currency = "EUR",
                Complexity = "VeryHigh"
            };
        }

        [Fact]
        public void Invalid_Complexity_Value_Should_Throw_ErrorNotification()
        {
            var dummy = _item;
            dummy.Complexity = "DUMMY";

            var validator = Service.GetService<IValidator<TsvItem>>();
            var validationResult = validator.Validate(dummy);
            validationResult.IsValid.ShouldBe(false);
        }

        [Fact]
        public void Valid_Complexity_Value_From_AppSettings_Value_List_Should_Throw_ErrorNotification()
        {
            var validator = Service.GetService<IValidator<TsvItem>>();
            var validationResult = validator.Validate(_item);
            validationResult.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Invalid_Money_Value_Should_Throw_ErrorNotification()
        {
            var dummy = _item;
            dummy.SavingAmount = "DUMMY";

            var validator = Service.GetService<IValidator<TsvItem>>();
            var validationResult = validator.Validate(dummy);
            validationResult.IsValid.ShouldBe(false);
        }

        [Fact]
        public void Valid_Money_Value_Should_Pass()
        {
            var dummy = _item;
            var validator = Service.GetService<IValidator<TsvItem>>();
            var validationResult = validator.Validate(dummy);
            validationResult.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Invalid_Date_Value_Should_Throw_ErrorNotification()
        {
            var dummy = _item;
            dummy.StartDate = "2342";

            var validator = Service.GetService<IValidator<TsvItem>>();
            var validationResult = validator.Validate(dummy);
            validationResult.IsValid.ShouldBe(false);
        }

        [Fact]
        public void Valid_Date_Value_Should_Pass()
        {
            var dummy = _item;
            var validator = Service.GetService<IValidator<TsvItem>>();
            var validationResult = validator.Validate(dummy);
            validationResult.IsValid.ShouldBe(true);
        }
    }
}