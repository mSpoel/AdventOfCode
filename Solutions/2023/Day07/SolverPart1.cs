namespace Day07
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);


            List<GameRound> gameRounds = new List<GameRound>();
            foreach (var line in lines)
            {
                var gameRound = new GameRound(line);
                gameRounds.Add(gameRound);
            }

            int result = 0;
            int rank = gameRounds.Count;

            var sortedList = gameRounds
                .OrderByDescending(x => x.HandTypeValue)
                .ThenByDescending(x => x.Hand.CardValue(0))
                .ThenByDescending(x => x.Hand.CardValue(1))
                .ThenByDescending(x => x.Hand.CardValue(2))
                .ThenByDescending(x => x.Hand.CardValue(3))
                .ThenByDescending(x => x.Hand.CardValue(4)).ToList();

            foreach (var gameRound in sortedList)
            {
                result += gameRound.Bid * rank;

                Console.WriteLine($"{gameRound.Hand.HandAsString()} \t  \t {gameRound.Hand.Type()} \t Bid {gameRound.Bid} \t Rank {rank} \t {result}");

                rank--;
            }

            return result;
        }
    }
}
