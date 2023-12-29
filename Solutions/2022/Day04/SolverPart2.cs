namespace Day04
{
    internal class SolverPart2
    {
        internal static int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                var rangeX1 = int.Parse(parts[0].Split('-')[0]);
                var rangeX2 = int.Parse(parts[0].Split('-')[1]);
                var rangeY1 = int.Parse(parts[1].Split('-')[0]);
                var rangeY2 = int.Parse(parts[1].Split('-')[1]);

                var range = new Range(rangeX1, rangeX2);
                var range2 = new Range(rangeY1, rangeY2);


                if (rangeX2 >= rangeY1 && rangeY2 >= rangeX1)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
