using System;
using System.Data;
using AutoMapper;
using ITP_Cli.Engine.Models;
using Xunit;
using Shouldly;
namespace ITP_Cli.Engine.UnitTest.Mappings
{
      public class MappingTest : IClassFixture<MappingFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;
        private DataRow _dataRow;

        public MappingTest(MappingFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
            _dataRow = fixture.TestRow;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(DataRow), typeof(TsvItem))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            _mapper.Map(_dataRow, source, destination);
        }

        [Fact]
        public void SavingAmountsShouldConvert_Null_ToEmptyString()
        {
            var instance = _dataRow;
            instance["Project"] = 3;
            instance["Description"] = "Harmonize Lactobacillus acidophilus sourcing";
            instance["Start date"] = "2014-01-01 00:00:00.000";
            instance["Category"] = "Dairy";
            instance["Responsible"] = "Daisy Milks";
            instance["Savings amount"] = "NULL";
            instance["Currency"] = "EUR";
            instance["Complexity"] = "Simple";
            var item = _mapper.Map<TsvItem>(instance);
            item.SavingAmount.ShouldBe("");
        }

        [Fact]
        public void CurrencyShouldConvert_Null_ToEmptyString()
        {
            var instance = _dataRow;
            instance["Project"] = 3;
            instance["Description"] = "Harmonize Lactobacillus acidophilus sourcing";
            instance["Start date"] = "2014-01-01 00:00:00.000";
            instance["Category"] = "Dairy";
            instance["Responsible"] = "Daisy Milks";
            instance["Savings amount"] = "11689.322459";
            instance["Currency"] = "NULL";
            instance["Complexity"] = "Simple";
            var item = _mapper.Map<TsvItem>(instance);
            item.Currency.ShouldBe("");
        }
    }
}