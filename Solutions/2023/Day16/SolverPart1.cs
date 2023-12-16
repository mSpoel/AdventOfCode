using Utilities;

namespace Day16
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var gridBuilder = new GridBuilder();
            foreach (var line in lines)
            {
                gridBuilder.Add(line);
            }

            var grid = gridBuilder.Build();
            var beamTracer = new BeamTracer(grid);

            return beamTracer.NumberOfPointsAffectedByBeam(0, 0, [Direction.Right]);
        }
    }
}
