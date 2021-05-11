using System;

namespace AblyDemoUtils
{
    public static class Application
    {
        public enum ExitCode {
            Success = 0,
            InvalidArguments = 1
        }
        
        private static string GetKey(string[] args)
        {
            if (args.Length != 1) {
                Console.WriteLine("Missing Ably key: dotnet run -- <ably key>");
                Console.WriteLine("for example     : dotnet run -- AbCdEf.GhIjKl:MnOpQrStUvWxYz01");
                return null;
            }
            return args[0];
        }
        
        public static int Run(string[] args, Func<string, int> yourMain)
        {
            string key = GetKey(args);
            if (key == null) {
                return (int) ExitCode.InvalidArguments;
            }
            
            return yourMain(key);
        }
    }
}
