using System;
using System.Globalization;
using System.Text.RegularExpressions;


namespace App
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run with `dotnet test` from CSharpInterview/AppTest");
        }

        public static string ConvertToTitleCase(string inpStr)
        {

            if(inpStr != null) {
                Regex rgx = new Regex("[^a-zA-Z0-9 ]");
                inpStr = rgx.Replace(inpStr, " "); //Find and replace all non-alphanumeric characters with spaces
                inpStr = inpStr.Trim(); //Remove excess left on str
                inpStr = inpStr.ToLower(); //Change entire string to lower case - easier to do that 
                                        // and convert first letter of each word to capital letter rather than find and replace each capital with a lower case.
                
                inpStr = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inpStr.ToLower());
                return inpStr;
            }
            else{
                throw new ArgumentException("Parameter cannot be null", nameof(inpStr));

            }

            
        }

        

        public static string ConvertUnixToDateString(long? inpUnixSeconds)
        {
            String monthDay = "";
            String year = "";

            if(inpUnixSeconds.HasValue){
                long inpUnixSeconds2 = inpUnixSeconds.GetValueOrDefault();
                DateTime dateTime = (DateTimeOffset.FromUnixTimeSeconds(inpUnixSeconds2)).DateTime;
                monthDay = dateTime.ToString("MMMM d");
                year = dateTime.ToString("yyyy");

                
                // let month = dateObj.toLocaleString('default', { month: 'long' });
                // let day = dateObj.getDate();
                // let year = dateObj.getFullYear();
                // dateStr = month + " " + day + ", " + year;
            }
            else if(inpUnixSeconds == null){
                throw new Exception();
            }
            else if(!inpUnixSeconds.HasValue){
                monthDay = DateTime.Now.ToString("MMMM d");
                year = DateTime.Now.ToString("yyyy");
            }

            return monthDay + ", " + year;
            
        }
    }
}