using System.Threading.Tasks;
using ITP_Cli.Engine.Queries;
using ITP_Cli.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace ITP_Cli.Engine.UnitTest.Parsing
{
    public class ParserTest : IClassFixture<ServiceFixture>
    {
        public IMediatorHandler Bus { get; set; }

        public ParserTest(ServiceFixture fixture)
        {
            Bus = fixture.Service.GetService<IMediatorHandler>();
        }

        [Fact]
        public void Valid_TSV_Should_Be_Successfully_Parsed()
        {
            var query = new ParserQuery("Valid.tsv", null, null);
            var status = Task.Run(async () =>
            {
                return await Bus.ExecuteQuery<ParserQuery, ParserQueryResult>(query);
            }).Result;

            status.Records.Count.ShouldBe(8);
        }

        [Fact]
        public void Sort_A_Valid_TSV_Should_Be_Successfully_Sorted()
        {
            var query = new ParserQuery("SortTest.tsv", null, true);
            var status = Task.Run(async () =>
            {
                return await Bus.ExecuteQuery<ParserQuery, ParserQueryResult>(query);
            }).Result;

            status.Records[0].Project.ShouldBe("4");
        }

        [Fact]
        public void Filter_A_Valid_TSV_By_Project_Should_Be_Successfully_Filtered()
        {
            var query = new ParserQuery("Valid.tsv", 4, true);
            var status = Task.Run(async () =>
            {
                return await Bus.ExecuteQuery<ParserQuery, ParserQueryResult>(query);
            }).Result;

            status.Records.Count.ShouldBe(2);
        }
    }
}