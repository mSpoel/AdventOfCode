using Day08;
using FluentAssertions;
using Xunit;

namespace Day08Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Lcm_Example1()
        {
            var numbers = new long[] { 2, 3, 4 };
            var expected = 12;
            var lcm = Calculator.Lcm(numbers);

            lcm.Should().Be(expected);
        }
    }
}
