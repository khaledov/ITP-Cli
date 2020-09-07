using System.Collections.Generic;
using ITP_Cli.Engine.Models;

namespace ITP_Cli.Engine
{
    public class ParserQueryResult
    {
        public string[] Headers { get; set; }
        public List<TsvItem> Records { get; set; }
    }
}