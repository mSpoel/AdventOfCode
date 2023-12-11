namespace Day07
{
    public class Hand
    {
        private string _hand;
        private List<IGrouping<char, char>> _groupedChars;

        private Dictionary<char, int> _charValues = new Dictionary<char, int>
        {
            { 'A', 14 },
            { 'K', 13 },
            { 'Q', 12 },
            //{ 'J', 11 }, // for part 1
            { 'J', 1 }, // for part 2
            { 'T', 10 },
            { '9', 9 },
            { '8', 8 },
            { '7', 7 },
            { '6', 6 },
            { '5', 5 },
            { '4', 4 },
            { '3', 3 },
            { '2', 2 }
        };

        public Hand(string hand)
        {
            _hand = hand;
            _groupedChars = _hand.GroupBy(c => c).ToList();
        }

        public string HandAsString()
        {
            return _hand;
        }

        public int CardValue(int index)
        {
            return _charValues[_hand[index]];
        }

        public HandType Type()
        {
            //part 1
            // not feeling to well, so I'm going to leave this as is
            //return _hand switch
            //{
            //    var _ when IsFiveOfAKind() => HandType.FiveOfAKind,
            //    var _ when IsFourOfAKind() => HandType.FourOfAKind,
            //    var _ when IsFullHouse() => HandType.FullHouse,
            //    var _ when IsThreeOfAKind() => HandType.ThreeOfAKind,
            //    var _ when IsTwoPair() => HandType.TwoPair,
            //    var _ when IsOnePair() => HandType.OnePair,
            //    _ => HandType.HighCard
            //};

            //part 2
            if (IsFiveOfAKind())
            {
                return HandType.FiveOfAKind;
            }

            if (IsFourOfAKind())
            {
                if (NumberOfJokers() == 1 || NumberOfJokers() == 4)
                {
                    return HandType.FiveOfAKind;
                }

                return HandType.FourOfAKind;
            }

            if (IsFullHouse())
            {
                if (NumberOfJokers() == 2 || NumberOfJokers() == 3)
                {
                    return HandType.FiveOfAKind;
                }

                return HandType.FullHouse;
            }

            if (IsThreeOfAKind())
            {
                if (NumberOfJokers() == 1 || NumberOfJokers() == 3)
                {
                    return HandType.FourOfAKind;
                }

                if (NumberOfJokers() == 2)
                {
                    return HandType.FiveOfAKind;
                }

                return HandType.ThreeOfAKind;
            }

            if (IsTwoPair())
            {
                if (NumberOfJokers() == 1)
                {
                    return HandType.FullHouse;
                }

                if (NumberOfJokers() == 2)
                {
                    return HandType.FourOfAKind;
                }

                return HandType.TwoPair;
            }

            if (IsOnePair())
            {
                if (NumberOfJokers() == 1 || NumberOfJokers() == 2)
                {
                    return HandType.ThreeOfAKind;
                }

                return HandType.OnePair;
            }

            if (NumberOfJokers() == 1)
            {
                return HandType.OnePair;
            }

            return HandType.HighCard;
        }

        private bool IsFiveOfAKind()
        {
            return _groupedChars.Any(g => g.Count() == 5);
        }

        private bool IsFourOfAKind()
        {
            return _groupedChars.Any(g => g.Count() == 4);
        }

        private bool IsFullHouse()
        {
            return
            _groupedChars.Any(g => g.Count() == 3) &&
            _groupedChars.Any(g => g.Count() == 2);
        }


        private bool IsThreeOfAKind()
        {
            return
            _groupedChars.Any(g => g.Count() == 3) &&
            _groupedChars.Any(g => g.Count() == 1);
        }

        private bool IsTwoPair()
        {
            return _groupedChars.Count == 3 &&
                _groupedChars.Any(g => g.Count() == 2);
        }

        private bool IsOnePair()
        {
            return _groupedChars.Count == 4 &&
                _groupedChars.Any(g => g.Count() == 2);
        }

        private int NumberOfJokers()
        {
            return Math.Max(0, _hand.Split('J').Length - 1);
        }
    }
}
