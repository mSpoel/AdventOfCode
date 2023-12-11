
using System.Collections.Concurrent;

namespace Day08
{
    internal class SolverPart2
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var directions = lines[0];

            var map = new Map(lines.Skip(2));

            var routeCalculator = new RouteCalculator(map, directions);

            List<string> startingNodes = map.GetNodesEndingWith('A');
            List<string> endNodes = map.GetNodesEndingWith('Z');

            var numberOfSteps = new ConcurrentBag<long>();

            //var steps = routeCalculator.GetNumberOfSteps(startingNodes[0], "ZZZ");

            Parallel.ForEach(startingNodes, node =>
            {
                var steps = routeCalculator.GetNumberOfSteps(node, endNodes);
                numberOfSteps.Add(steps);
            });

            return Calculator.Lcm(numberOfSteps.ToArray());
        }
    }
}
