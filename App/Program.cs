using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run with `dotnet test` from CSharpInterview/AppTest");
        }

        public static string ConvertToTitleCase(string inpStr)
        {

            if (String.IsNullOrEmpty(inpStr))
            {
                throw new Exception();
            }
            // remove non alphaNum chars
            Regex regex = new Regex("[^a-zA-Z0-9]");
            String outStr = regex.Replace(inpStr, " ");

            //trim pre/post whitespace char
            char[] trimChars = { '*', ' ', '\'' };
            outStr = outStr.Trim(trimChars);

            // convert case to title
            TextInfo locTI = new CultureInfo("en-US", false).TextInfo;
            outStr = locTI.ToLower(outStr);
            outStr = locTI.ToTitleCase(outStr);

            return outStr;
        }

        public static string ConvertUnixToDateString(long? inpUnixSeconds)
        {
            if (inpUnixSeconds.HasValue)// test for null
            {
                DateTimeOffset outDate = DateTimeOffset.FromUnixTimeSeconds(inpUnixSeconds.Value);
                string outDateStr = outDate.ToString("MMMM d, yyyy");
                return outDateStr;//inpUnixSeconds.ToString();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}