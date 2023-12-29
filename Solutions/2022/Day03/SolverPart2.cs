namespace Day03
{
    internal class SolverPart2
    {
        internal static int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;
            int groupSize = 3;
            int steps = lines.Length / groupSize;

            for (int i = 0; i < steps; i++)
            {
                var firstLine = lines[i * groupSize];
                var secondLine = lines[i * groupSize + 1];
                var thirdLine = lines[i * groupSize + 2];

                foreach (char c in firstLine)
                {
                    if (secondLine.Contains(c) && thirdLine.Contains(c))
                    {
                        result += CharCalculator.GetValue(c);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
