using CommandLine;
using SimpleImpersonation;
using System;
using System.Diagnostics;

namespace WayneLabs.Impersonator
{
    static class Program
    {
        static void Main(string[] args)
        {
            var parsedResult = Parser.Default.ParseArguments<Options>(args);
            parsedResult.WithParsed(options =>
            {
                try
                {
                    using (Impersonation.LogonUser(options.Domain, options.Username, options.Password, LogonType.Interactive))
                    {
                        var process = new Process();
                        process.StartInfo.FileName = options.Command;
                        process.StartInfo.Arguments = options.Arguments;
                        process.Start();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            });

            parsedResult.WithNotParsed((error) =>
            {
                Console.ReadKey();
            });
        }
    }
}
