using System;
using System.Text;
using System.Text.RegularExpressions;

namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run with `dotnet test` from CSharpInterview/AppTest");
        }

        /// <summary>
        /// Challenge 1
        /// Create a function that takes in a constant-formatted (all caps, words separated by underscores) string and returns the string in "title case" (see examples below). The function should
        /// remove all non alphanumeric characters and replace them with spaces. But no spaces at the end of the result. A null input should throw an error.
        ///
        /// If you so choose feel free to leverage third party libraries to complete your solution.
        ///
        /// For example: "THIS_INPUT" should return "This Input" "CASE-THREE_extra[chars]///" should return "Case Three Extra Chars"
        /// </summary>
        public static string ConvertToTitleCase(string input)
        {

            if (string.IsNullOrEmpty(input))                                                        // Check for invalid input.
            {
                throw new ArgumentNullException("The input to this function cannot be null.");
            }

            Regex Expression = new Regex("[^a-zA-Z0-9]");
            string[] Words = Expression.Replace(input, " ").Split(new char[] { ' ' });              // Use the regular expression to replace non-alphanumeric characters with space, and split into an array.
            StringBuilder Result = new StringBuilder();
            foreach (string Word in Words)                                                          // Iterate through the words of the array.
            {
                if (!string.IsNullOrEmpty(Word))                                                    // Only take action on words that are not empty.
                {
                    Result.Append(Word[0].ToString().ToUpper() + Word.Substring(1).ToLower() + " ");        // Append the capitalized first letter of the word, and the lowercase rest of the word.
                }
            }
            return Result.ToString().Trim();                                                        // Output the formatted list of words, trimmed to remove the trailing space.
        }

        /// <summary>
        /// Challenge 2
        /// Create a function that takes in a unix epoch time in seconds(long data type) and returns a String that is the input timestamp converted and formatted as month day, year (see below).
        /// If no timestamp is given the function should return today’s date.  If the input is null or has an incorrect type, an error should be thrown.
        ///
        /// If you so choose feel free to leverage third party libraries to complete your solution.
        ///
        /// For example, passing a unix epoch time 1499144400 in seconds (long data type) would return "July 4, 2017" in this date format(string data type).
        /// </summary>
        /// <remarks>
        /// I decided to omit checks for no timestamp given, since the unix epoch time is the number of seconds since 1-1-1970 (00:00 GMT), there is no such thing as a missing timestamp.  All values
        /// for the long data type, including negative and zero values, are valid unix timestamps, and this function will convert them accordingly.
        /// </remarks>
        public static string ConvertUnixToDateString(long? unixTime)
        {
            if (unixTime == null)                                                    // Check for invalid input.
            {
                throw new ArgumentNullException("The input to this function cannot be null.");
            }

            // Using DateTimeOffset, generate a DateTime object from the unixTime paramter.  This is then converted to a string using a format code to get the desired format, and returned.
            return DateTimeOffset.FromUnixTimeSeconds((long)unixTime).DateTime.ToString("MMMM d, yyyy");
        }
    }
}