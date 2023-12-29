namespace Day01
{
    internal class SolverPart2
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int count = 0;

            List<int> calories = new List<int>();
            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    calories.Add(count);
                    count = 0;
                    continue;
                }

                count += int.Parse(line);
            }

            calories.Add(count);

            calories.Sort();
            calories.Reverse();

            return calories[0] + calories[1] + calories[2];
        }
    }
}
