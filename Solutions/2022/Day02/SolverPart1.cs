namespace Day02
{
    internal class SolverPart1
    {
        internal static int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            var rockPaperScissorsEngine = new RockPaperScissorsEngine();

            foreach (var line in lines)
            {
                int score = rockPaperScissorsEngine.GetScore(line);

                result += score;
            }

            return result;
        }
    }
}
