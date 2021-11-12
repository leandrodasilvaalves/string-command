using System;

namespace LSA.Str
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Process(args));
        }

        public static string Process(string[] args)
        {
            string returnValue = string.Empty;

            switch (args[0])
            {
                case "-f":
                case "--firstUpper":
                    returnValue = FirstUpper(args[1]);
                    break;

                case "-g":
                case "--guid":
                    if (args.Length >= 2 && int.TryParse(args[1], out var amount))
                    {
                        for (var i = 0; i < amount; i++)
                        {
                            returnValue += (i == amount -1) ? GuidNew() : $"{GuidNew()}\n";
                        }
                    }
                    else
                    {
                        returnValue = GuidNew();
                    }
                    break;

                case "-l":
                case "--lower":
                    returnValue = ToLower(args[1]);
                    break;

                case "-u":
                case "--upper":
                    returnValue = ToUpper(args[1]);
                    break;

                default:
                    returnValue = "Invalid args";
                    break;
            }

            return returnValue;
        }

        private static string FirstUpper(string text) => $"{text.Substring(0, 1).ToUpper()}{text.Substring(1).ToLower()}";

        private static string ToLower(string text) => text.ToLower();

        private static string ToUpper(string text) => text.ToUpper();

        private static string GuidNew() => Guid.NewGuid().ToString();
    }
}