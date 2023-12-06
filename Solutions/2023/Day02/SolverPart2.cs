namespace Day02
{
    internal class SolverPart2
    {
        public int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            foreach (var line in lines)
            {
                var gameRound = new GameRound(line);
                result += gameRound.GetPower();
            }

            return result;
        }
    }
}