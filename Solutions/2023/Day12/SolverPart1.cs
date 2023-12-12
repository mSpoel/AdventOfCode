namespace Day12
{
    internal class SolverPart1
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            long result = 0;

            Parallel.ForEach(lines, line =>
            {
                var springRow = new SpringRow(line);
                var combinations = springRow.GetNumberOfCombinations();
                Console.WriteLine($"{line} : Combinations: {combinations}");

                Interlocked.Add(ref result, combinations);
            });

            return result;
        }
    }
}
