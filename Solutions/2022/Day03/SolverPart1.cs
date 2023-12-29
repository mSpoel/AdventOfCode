namespace Day03
{
    internal class SolverPart1
    {
        internal static int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            foreach (var line in lines)
            {
                var part1 = line[..(line.Length / 2)];
                var part2 = line[(line.Length / 2)..];

                foreach (var c in part1)
                {
                    if (part2.Contains(c))
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
