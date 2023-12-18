using Utilities;

namespace Day18
{
    internal class SolverPart1
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            DigPlan digPlan = new DigPlan(lines);

            var circumferenceLenght = digPlan.GetCircumferenceLength();
            var edges = digPlan.GetEdges();
            var area = Shoelace.GetArea(edges);


            // Picks theorem: https://en.wikipedia.org/wiki/Pick's_theorem
            // A = i + b/2 - 1 -> i = A + 1 - b/2

            var interiorPoints = area + 1 - circumferenceLenght / 2;

            return interiorPoints + circumferenceLenght;
        }
    }
}
