namespace Day07
{
    internal class GameRound
    {
        public GameRound(string line)
        {
            string[] parts = line.Split(' ');
            Hand = new Hand(parts[0]);
            Bid = int.Parse(parts[1]);
            HandTypeValue = _handTypeValues[Hand.Type()];
        }

        public Hand Hand { get; }

        public int Bid { get; }

        public int HandTypeValue { get; internal set; }

        private Dictionary<HandType, int> _handTypeValues = new()
        {
            { HandType.FiveOfAKind, 1000000 },
            { HandType.FourOfAKind, 100000 },
            { HandType.FullHouse, 10000 },
            { HandType.ThreeOfAKind, 1000 },
            { HandType.TwoPair, 100 },
            { HandType.OnePair, 10 },
            { HandType.HighCard, 1 }
        };
    }
}
