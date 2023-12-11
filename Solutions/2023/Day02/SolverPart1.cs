namespace Day02
{
    internal class SolverPart1
    {
        public int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            var checkSet = new CubeSet(12, 13, 14);

            foreach (var line in lines)
            {

                var gameRound = new GameRound(line);

                if (gameRound.IsPossible(checkSet))
                {
                    result += gameRound.Number;
                }
            }

            return result;
        }
    }
}
