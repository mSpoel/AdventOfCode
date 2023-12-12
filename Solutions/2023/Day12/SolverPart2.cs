namespace Day12
{
    internal class SolverPart2
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            long result = 0;

            Parallel.ForEach(lines, line =>
            {
                var unfoldedLine = Unfold(line);
                var springRow = new SpringRow(unfoldedLine);
                var combinations = springRow.GetNumberOfCombinations();
                Console.WriteLine($"{unfoldedLine} : Combinations: {combinations}");

                Interlocked.Add(ref result, combinations);
            });

            //foreach (var line in lines)
            //{
            //    var unfoldedLine = Unfold(line);
            //    var springRow = new SpringRow(unfoldedLine);
            //    var combinations = springRow.GetNumberOfCombinations();
            //    Console.WriteLine($"{unfoldedLine} : Combinations: {combinations}");

            //    result += combinations;
            //}

            return result;
        }

        private string Unfold(string line)
        {
            string pattern = line.Split(" ")[0];
            string groups = line.Split(" ")[1];

            return
                string.Concat(Enumerable.Repeat(pattern + '?', 4))
                + pattern
                + " "
                + string.Concat(Enumerable.Repeat(groups + ',', 4))
                + groups;
        }
    }
}
