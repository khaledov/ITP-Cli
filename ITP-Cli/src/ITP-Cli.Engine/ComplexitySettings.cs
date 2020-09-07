namespace ITP_Cli.Engine
{
    //Typed AppSettings, to read all valid values for Complexity field
    //To extend current valid values of Complexity field, you just enter the new list in app setting file
    public class ComplexitySettings
    {
        public string[] ValidValues { get; set; }
    }
}