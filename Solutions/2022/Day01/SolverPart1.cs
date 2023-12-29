namespace Day01
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            int count = 0;
            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    result = Math.Max(result, count);
                    count = 0;
                    continue;
                }

                count += int.Parse(line);
            }

            return result;
        }
    }
}
