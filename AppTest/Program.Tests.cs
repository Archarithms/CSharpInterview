using System;
using App;
using Xunit;

namespace AppTest
{
    public class ProgramTests
    {
        [Fact]
        public void ConvertToTitleCase_Simple()
        {
            // Given
            var testStr = "TITLE_CASE";

            // When
            var actual = Program.ConvertToTitleCase(testStr);

            // Then
            var expected = "Title Case";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertToTitleCase_Numbers()
        {
            // Given
            var testStr = "NUMBER_3";

            // When
            var actual = Program.ConvertToTitleCase(testStr);

            // Then
            var expected = "Number 3";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertToTitleCase_OtherChars()
        {
            // Given
            var testStr = "  TRUTH-TRACK   ";

            // When
            var actual = Program.ConvertToTitleCase(testStr);

            // Then
            var expected = "Truth Track";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertToTitleCase_OtherChars2()
        {
            // Given
            var testStr = "CASE-THREE_extra[chars]///";

            // When
            var actual = Program.ConvertToTitleCase(testStr);

            // Then
            var expected = "Case Three Extra Chars";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertToTitleCase_Null()
        {
            // Given
            string testStr = null;

            // When
            Action action = () => Program.ConvertToTitleCase(testStr);

            // Then
            Assert.Throws<ArgumentNullException>(action);
        }

        // NOTE: I decided that an empty string should also throw an exception.
        [Fact]
        public void ConvertToTitleCase_Empty()
        {
            // Given
            string testStr = string.Empty;

            // When
            Action action = () => Program.ConvertToTitleCase(testStr);

            // Then
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void ConvertUnixToDateString_Simple()
        {
            // Given
            var testStamp = 1604352245L;

            // When
            var actual = Program.ConvertUnixToDateString(testStamp);

            // Then
            var expected = "November 2, 2020";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertUnixToDateString_Null()
        {
            // Given
            long? testStamp = null;

            // When
            Action action = () => Program.ConvertUnixToDateString(testStamp);

            // Then
            // NOTE: Modified this test to detect ArgumentNullException.
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void ConvertUnixToDateString_Original()
        {
            // Given
            var testStamp = 1499144400;

            // When
            var actual = Program.ConvertUnixToDateString(testStamp);

            // Then
            var expected = "July 4, 2017";
            Assert.Equal(expected, actual);
        }

        // Note: The following tests had their expected results generated using epochconverter.com.  The assumption is that the time zone is GMT.
        [Fact]
        public void ConvertUnixToDateString_Zero()
        {
            // Given
            var testStamp = 0;

            // When
            var actual = Program.ConvertUnixToDateString(testStamp);

            // Then
            var expected = "January 1, 1970";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertUnixToDateString_Negative()
        {
            // Given
            var testStamp = -561600;

            // When
            var actual = Program.ConvertUnixToDateString(testStamp);

            // Then
            var expected = "December 25, 1969";
            Assert.Equal(expected, actual);
        }

        // These datestamps are generated to be one second before and after midnight on May 21, 1982.  This is to demonstrate that even a single digit difference in timestamp can result in a
        // different date string.
        [Fact]
        public void ConvertUnixToDateString_OffByOne_1()
        {
            // Given
            var testStamp = 390787200;

            // When
            var actual = Program.ConvertUnixToDateString(testStamp);

            // Then
            var expected = "May 21, 1982";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertUnixToDateString_OffByOne_2()
        {
            // Given
            var testStamp = 390787199;

            // When
            var actual = Program.ConvertUnixToDateString(testStamp);

            // Then
            var expected = "May 20, 1982";
            Assert.Equal(expected, actual);
        }
    }
}