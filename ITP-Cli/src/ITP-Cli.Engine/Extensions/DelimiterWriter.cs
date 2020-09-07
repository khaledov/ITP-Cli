using System.Linq;
using System.Text;

namespace ITP_Cli.Engine.Extensions
{
    public static class DelimiterWriter
    {
        //Extension method that convert an array of string to delimiter string according to the specified delimiter character
        public static string ToDelimiterString(this string[] source, string delimiter)
        {
            var str = new StringBuilder();
            source.ToList().ForEach(item => str.Append($"{item}{delimiter}"));
            return str.ToString();
        }
    }
}