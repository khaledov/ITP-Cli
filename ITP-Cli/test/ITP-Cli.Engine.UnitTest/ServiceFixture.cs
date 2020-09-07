using System.IO;
using System.Reflection;
using ITP_Cli.Engine.Extensions;
using ITP_Cli.Infra.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITP_Cli.Engine.UnitTest
{
    public class ServiceFixture
    {
        public IMediatorHandler Bus { get; set; }
        public IConfiguration Configuration { get; set; }
        public ServiceProvider Service { get; set; }

        public ServiceFixture()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            Service = new ServiceCollection()
                .AddParserSystem(config, Assembly.GetExecutingAssembly().GetType())
                .BuildServiceProvider();
            Configuration = Service.GetService<IConfiguration>();
        }
    }
}