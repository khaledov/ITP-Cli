using MediatR;

namespace ITP_Cli.Engine.Queries
{
    public class ParserQuery : IRequest<ParserQueryResult>
    {
        public ParserQuery(string filePath, int? project, bool? sort)
        {
            FilePath = filePath;
            Project = project;
            Sort = sort;
        }

        public string FilePath { get; }
        public int? Project { get; }
        public bool? Sort { get; }
    }
}