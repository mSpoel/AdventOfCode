using Day06;
using FluentAssertions;
using Xunit;

namespace AoC2022Tests
{
    public class Day06Tests
    {
        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4, 7)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 4, 5)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 4, 6)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4, 10)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4, 11)]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14, 19)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 14, 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 14, 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14, 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14, 26)]
        public void GetFirstMarkerPosition(string input, int stringToCheckLength, int expectedMarkerPosition)
        {
            var actualMarkerPosition = BufferProcessor.GetFirstMarkerPosition(input, stringToCheckLength);
            actualMarkerPosition.Should().Be(expectedMarkerPosition);
        }
    }
}
