using System;
using System.Text.RegularExpressions;

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
            catch (Exception)
            {
                returnValue = $"Invalid args \n\n {Help()}";
            }

            return returnValue;
        }

        private static string FirstUpper(string text)
        {
            string ToFirstUpper(string currentText) => $"{currentText.Substring(0, 1).ToUpper()}{currentText.Substring(1).ToLower()}";
            var pattern = @"\.{3}|[!?\.]";
            var regex = new Regex(pattern);
            var punctuationMarks = regex.Matches(text);

            if (punctuationMarks.Count > 1)
            {
                var newText = string.Empty;
                var messages = regex.Split(text);
                for (var i = 0; i < messages.Length; i++)
                {
                    if (!string.IsNullOrEmpty(messages[i]))
                    {
                        newText += $"{ToFirstUpper(messages[i].Trim())}{punctuationMarks[i]} ";
                    }
                }
                return newText.Trim();
            }
            
            return ToFirstUpper(text.Trim());
        }

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