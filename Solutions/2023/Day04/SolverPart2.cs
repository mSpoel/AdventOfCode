namespace Day04
{
    internal class SolverPart2
    {
        internal int GetSolution(string inputPath)
        {
            int result = 0;
            string[] lines = File.ReadAllLines(inputPath);

            Dictionary<int, int> countOfCards = new Dictionary<int, int>();
            Dictionary<int, int> numberOfMatches = new Dictionary<int, int>();

            foreach (var line in lines)
            {
                var card = new Card(line);
                var matches = CardCalculator.GetNumberOfMatches(card);

                numberOfMatches.Add(card.CardNumber, matches);
                countOfCards.Add(card.CardNumber, 1);
            }

            for (int i = 1; i <= countOfCards.Count; i++)
            {
                var matches = numberOfMatches[i];
                var count = countOfCards[i];

                for (int j = i + 1; j <= i + matches; j++)
                {
                    countOfCards[j] += count;
                }
            }

            return countOfCards.Sum(x => x.Value);
        }
    }
}
