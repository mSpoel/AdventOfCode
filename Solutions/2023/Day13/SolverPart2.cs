namespace Day13
{
    internal class SolverPart2
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
                    bool stop = false;

                    for (int row = 0; row < patternBuilder.NumberOfRows; row++)
                    {
                        if (stop)
                        {
                            break;
                        }

                        var originalPattern = patternBuilder.Build();
                        var originalReflectionNumber = originalPattern.GetReflectionNumber();
                        var originalRows = originalPattern.GetReflectionRows();
                        var originalColumns = originalPattern.GetReflectionColumns();

                        Console.WriteLine($"Original reflection number {originalReflectionNumber} at row {row}.");

                        for (int column = 0; column < patternBuilder.NumberOfColumns; column++)
                        {
                            patternBuilder.Replace(row, column);
                            patternBuilder.Ignore(originalRows, originalColumns);
                            var pattern = patternBuilder.Build();

                            var reflectionNumber = pattern.GetReflectionNumber();
                            var rows = pattern.GetReflectionRows();
                            var columns = pattern.GetReflectionColumns();

                            if (reflectionNumber > 0)
                            {
                                Console.WriteLine($"Found reflection number {reflectionNumber} at replaced row {row} and column {column}.");
                                result += reflectionNumber;
                                stop = true;
                                break;
                            }
                        }
                    }

                    patternBuilder = new PatternBuilder();
                    continue;
                }

                patternBuilder.Add(line);
            }

            return result;
        }
    }
}
