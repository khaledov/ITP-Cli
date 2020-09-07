using System.Text;

namespace ITP_Cli.Engine.Models
{
    public class TsvItem
    {
        public string Project { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string Category { get; set; }
        public string Responsible { get; set; }
        public string SavingAmount { get; set; }
        public string Currency { get; set; }
        public string Complexity { get; set; }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.AppendFormat($"{Project}" +
                             $"\t{Description}" +
                             $"\t{StartDate}" +
                             $"\t{Category}" +
                             $"\t{Responsible}" +
                             $"\t{SavingAmount}" +
                             $"\t{Currency}" +
                             $"\t{Complexity}\n");
            return str.ToString();
        }
    }
}