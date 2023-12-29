namespace Day02
{
    internal class SolverPart2
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            var rockPaperScissorsEngine = new RockPaperScissorsEngine();

            foreach (var line in lines)
            {
                int score = rockPaperScissorsEngine.GetScorePart2(line);

                result += score;
            }

            return result;
        }
    }
}
