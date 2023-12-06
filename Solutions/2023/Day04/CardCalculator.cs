namespace Day04
{
    internal static class CardCalculator
    {
        public static int GetNumberOfMatches(Card card)
        {
            var numberOfWinningNumbers = 0;

            Console.Write($"Start calculating Card {card} \t Winning numbers:\t");

            foreach (var number in card.OwnNumbers)
            {
                if (card.WinningNumbers.Contains(number))
                {
                    numberOfWinningNumbers++;
                    Console.Write($"{number} \t");
                }
            }

            Console.Write($"Number of matches: {numberOfWinningNumbers} ");
            Console.WriteLine();
            return numberOfWinningNumbers;
        }

        public static int GetValue(Card card)
        {
            var numberOfWinningNumbers = 0;

            Console.Write($"Start calculating Card {card} \t Winning numbers:\t");

            foreach (var number in card.OwnNumbers)
            {
                if (card.WinningNumbers.Contains(number))
                {
                    numberOfWinningNumbers++;
                    Console.Write($"{number} \t");
                }
            }

            var cardValue = 0;
            if (!(numberOfWinningNumbers == 0))
            {
                cardValue = (int)Math.Pow(2, numberOfWinningNumbers - 1);
            }

            Console.Write($"Total value: {cardValue}");
            Console.WriteLine();

            return cardValue;
        }
    }
}
