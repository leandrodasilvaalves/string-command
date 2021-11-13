using System;

namespace LSA.StringCommand
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
            try
            {
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
                                returnValue += (i == amount - 1) ? GuidNew() : $"{GuidNew()}\n";
                            }
                        }
                        else
                        {
                            returnValue = GuidNew();
                        }
                        break;
                    case "-h":
                    case "--help":
                        returnValue = Help();
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
                        returnValue = $"Invalid args \n\n {Help()}";
                        break;
                }
            }
            catch (Exception ex)
            {
                returnValue = $"ERROR: {ex.Message} \n\n {Help()}";
            }

            return returnValue;
        }

        private static string FirstUpper(string text) => $"{text.Substring(0, 1).ToUpper()}{text.Substring(1).ToLower()}";

        private static string ToLower(string text) => text.ToLower();

        private static string ToUpper(string text) => text.ToUpper();

        private static string GuidNew() => Guid.NewGuid().ToString();

        private static string Help() =>
            @"str [OPTION] [TEXT]
              -f --firstUpper -> Primeira letra em maiúsculo 
              -g --guid [NUMBER, Default=1] -> Returns one or more guids as specified by arguments. The default quantity returned is 1.
              -l --lower -> Return all lowercase letters.  
              -u --upper -> Return all uppercase letters.  
            ";
    }
}