

namespace Day03
{
    internal class SolverPart1
    {
        public int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;
            foreach (var line in lines)
            {
                var digits = line.Select(c => int.Parse(c.ToString())).ToList();
                int maxLeft = digits.Take(digits.Count - 1).Max();
                int indexMaxLeft = digits.IndexOf(maxLeft);
                int maxRight = digits.Skip(indexMaxLeft + 1).Max();

                Console.WriteLine($"Max left: {maxLeft}, Max right: {maxRight}");

                result += maxLeft *10 + maxRight;

            }

            return result;
        }
    }
}
