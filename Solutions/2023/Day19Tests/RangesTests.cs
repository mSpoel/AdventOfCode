using Day19;
using FluentAssertions;
using Xunit;

namespace Day19Tests
{
    public class RangesTests
    {
        [Theory]
        [InlineData("x>10", 1, 20, 11, 20)]
        [InlineData("x>10", 1, 11, 11, 11)]
        [InlineData("x>10", 14, 20, 14, 20)]
        [InlineData("x<10", 1, 120, 1, 9)]
        [InlineData("x<10", 9, 9, 9, 9)]
        [InlineData("x<10", 1, 4, 1, 4)]
        public void GetPassRanges(string expression, int start, int end, int expectedStart, int expectedEnd)
        {
            var ranges = Ranges.GetPassRanges(expression, new Range(start, end));

            ranges.First().Should().Be(new Range(expectedStart, expectedEnd));
        }

        [Theory]
        [InlineData("x>10", 1, 20, 1, 10)]
        [InlineData("x>10", 1, 9, 1, 9)]
        [InlineData("x>10", 10, 10, 10, 10)]
        [InlineData("x<10", 1, 120, 10, 120)]
        [InlineData("x<10", 11, 11, 11, 11)]
        [InlineData("x<10", 11, 14, 11, 14)]
        public void GetFailRanges(string expression, int start, int end, int expectedStart, int expectedEnd)
        {
            var ranges = Ranges.GetFailRanges(expression, new Range(start, end));

            ranges.First().Should().Be(new Range(expectedStart, expectedEnd));
        }

    }
}
