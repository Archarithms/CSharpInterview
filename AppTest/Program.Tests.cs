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
            Assert.Throws<Exception>(action);
        }
    }
}