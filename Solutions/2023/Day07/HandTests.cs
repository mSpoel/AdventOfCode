using FluentAssertions;
using Xunit;

namespace Day07
{
    public class HandTests
    {
        [Theory]
        [InlineData("AAAAA")]
        public void FiveOfAKind(string handAsString)
        {
            var hand = new Hand(handAsString);
            hand.Type().Should().Be(HandType.FiveOfAKind);
        }

        [Theory]
        [InlineData("AKKKK")]
        [InlineData("KAKKK")]
        [InlineData("KKAKK")]
        [InlineData("KKKAK")]
        [InlineData("KKKKA")]
        public void FourOfAKind(string handAsString)
        {
            var hand = new Hand(handAsString);
            hand.Type().Should().Be(HandType.FourOfAKind);
        }

        [Theory]
        [InlineData("AAKKK")]
        [InlineData("AAAKK")]
        [InlineData("AKKKA")]
        [InlineData("KAKAK")]
        public void FullHouse(string handAsString)
        {
            var hand = new Hand(handAsString);
            hand.Type().Should().Be(HandType.FullHouse);
        }

        [Theory]
        [InlineData("AAAKJ")]
        [InlineData("AKAJA")]
        public void ThreeOfAKind(string handAsString)
        {
            var hand = new Hand(handAsString);
            hand.Type().Should().Be(HandType.ThreeOfAKind);
        }

        [Theory]
        [InlineData("AAKKQ")]
        [InlineData("AAQKK")]
        [InlineData("AKQAK")]
        public void TwoPair(string handAsString)
        {
            var hand = new Hand(handAsString);
            hand.Type().Should().Be(HandType.TwoPair);
        }

        [Theory]
        [InlineData("AAKQJ")]
        [InlineData("AKAQJ")]
        [InlineData("AKQAJ")]
        public void OnePair(string handAsString)
        {
            var hand = new Hand(handAsString);
            hand.Type().Should().Be(HandType.OnePair);
        }

        [Theory]
        [InlineData("AKQJT")]
        public void HighCard(string handAsString)
        {
            var hand = new Hand(handAsString);
            hand.Type().Should().Be(HandType.HighCard);
        }
    }
}
