using System.Data;
using AutoMapper;
using ITP_Cli.Engine.Mapping;

namespace ITP_Cli.Engine.UnitTest.Mappings
{
    public class MappingFixture
    {
        public MappingFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TsvItemProfile>();
            });

            Mapper = ConfigurationProvider.CreateMapper();
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Project", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Start date", typeof(string)));
            dt.Columns.Add(new DataColumn("Category", typeof(string)));
            dt.Columns.Add(new DataColumn("Responsible", typeof(string)));
            dt.Columns.Add(new DataColumn("Savings amount", typeof(string)));
            dt.Columns.Add(new DataColumn("Currency", typeof(string)));
            dt.Columns.Add(new DataColumn("Complexity", typeof(string)));
            TestRow = dt.NewRow();
        }

        public DataRow TestRow { get; set; }
        public IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }
    }
}