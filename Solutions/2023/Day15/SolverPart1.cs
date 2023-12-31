namespace Day15
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                foreach (var part in parts)
                {
                    var hash = part.CalculateHash();
                    result += hash;

                    Console.WriteLine($"'{part}' hash is {hash}");
                }
            }

            return result;
        }
    }
}
