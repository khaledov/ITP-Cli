using System;
using ITP_Cli.Engine.Extensions;
using ITP_Cli.Infra.Notifications;

namespace ITP_Cli.Engine
{
    //Utility console class that prints to the console window
    public static class ConsoleWriter
    {
        public static void WriteWarning(string content)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(content);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteSpecial(string content)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(content);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteResult(ParserQueryResult queryResult)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(queryResult.Headers.ToDelimiterString("\t"));
            Console.ForegroundColor = ConsoleColor.Yellow;
            queryResult.Records.ForEach(record => Console.WriteLine(record.ToString()));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteNotification(DomainErrorNotification domainError)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Message: {domainError.Message}\nAt time: {domainError.Timestamp.ToLocalTime()}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteFailed(TimeSpan? time = null)
        {
            var elapsed = time.HasValue ? " - " + time.Value.TotalSeconds.ToString("F4") + "s" : "";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("FAILED" + elapsed);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        public static void WriteException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t**************** FAILED *******************");
            Console.WriteLine("Exception Type :\t" + ex.GetType());
            Console.WriteLine();
            Console.WriteLine("Exception Message :\t" + ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteExceptionShort(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t**************** FAILED *******************");
            Console.WriteLine();
            Console.WriteLine("(" + ex.GetType() + ") :\t" + ex.Message);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}