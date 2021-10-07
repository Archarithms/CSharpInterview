using System;
using System.Globalization;
using System.Text.RegularExpressions;

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
            if (inpStr == null)
                throw new Exception("input cannot be null");
            //creates a TextInfo based on the "en-US" culture.
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            //replace all alphanumeric with spaces
            string outStr = Regex.Replace(inpStr, @"[^a-zA-Z0-9]+", " ");
            //convert to titlecase and remove excess spaces at the end
            return myTI.ToTitleCase(outStr.ToLower().Trim());
        }

        public static string ConvertUnixToDateString(long? inpUnixSeconds)
        {
            try
            {
                //convert to DateTimeOffset
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds((long)inpUnixSeconds);
                //return formatted date
                return dateTimeOffset.ToString("MMMM d, yyyy");
            }
            catch
            {
                throw new Exception("invalid input");
            }
        }
    }
}