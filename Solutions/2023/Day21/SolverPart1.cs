using Utilities;

namespace Day21
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath, int numberOfSteps)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var builder = new GridBuilder();

            foreach (var line in lines)
            {
                builder.Add(line);
            }

            var grid = builder.Build();

            var stepCounter = new StepCounter(grid);

            return stepCounter.GetReachablePlots(numberOfSteps);
        }
    }
}
