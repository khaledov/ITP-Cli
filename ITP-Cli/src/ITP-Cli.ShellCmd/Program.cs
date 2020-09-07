using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using ITP_Cli.Engine;
using ITP_Cli.Engine.Extensions;
using ITP_Cli.Engine.Queries;
using ITP_Cli.Infra.Bus;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITP_Cli.ShellCmd
{
    internal class Program
    {
        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        [Option("--file")]
        [Required]
        public string FilePath { get; }

        [Option("--sortByStartDate")]
        public bool? Sort { get; }

        [Option("--project")]
        public int? Project { get; }

        public void OnExecute()
        {
            try
            {
                IConfiguration config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", true, true)
                   .Build();

                var serviceProvider = new ServiceCollection()
                    .AddParserSystem(config, Assembly.GetExecutingAssembly().GetType())
                    .BuildServiceProvider();

                var bus = serviceProvider.GetService<IMediatorHandler>();
                var query = new ParserQuery(FilePath, Project, Sort);

                var queryResult = Task.Run(async () => await bus.ExecuteQuery<ParserQuery, ParserQueryResult>(query)).Result;
                ConsoleWriter.WriteResult(queryResult);
            }
            catch (System.Exception ex)
            {

                ConsoleWriter.WriteException(ex);
            }

        }
    }
}