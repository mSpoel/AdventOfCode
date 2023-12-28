namespace Day24
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath, long minValue, long maxValue)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            HailStone[] stones = new HailStone[lines.Length];

            int lineIndex = 0;
            foreach (var line in lines)
            {
                stones[lineIndex++] = new HailStone(line);
            }

            for (int i = 0; i < stones.Length; i++)
            {
                for (int j = i + 1; j < stones.Length; j++)
                {
                    if (stones[i].WillCollide2D(stones[j], minValue, maxValue))
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
