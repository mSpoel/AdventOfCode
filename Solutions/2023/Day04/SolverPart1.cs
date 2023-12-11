namespace Day04
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath)
        {
            int result = 0;
            string[] lines = File.ReadAllLines(inputPath);

            foreach (var line in lines)
            {
                var card = new Card(line);
                result += CardCalculator.GetValue(card);
            }

            return result;
        }
    }
}
