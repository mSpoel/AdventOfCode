namespace Day13
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            var patternBuilder = new PatternBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.Length < 1 || i == lines.Length - 1)
                {
                    var pattern = patternBuilder.Build();
                    result += pattern.GetReflectionNumber();

                    patternBuilder = new PatternBuilder();
                    continue;
                }

                patternBuilder.Add(line);
            }

            return result;
        }
    }
}
