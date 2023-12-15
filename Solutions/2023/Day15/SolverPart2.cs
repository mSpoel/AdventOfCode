namespace Day15
{
    internal class SolverPart2
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                var boxCollection = new BoxCollection();

                foreach (var part in parts)
                {
                    boxCollection.Process(part);
                }

                return boxCollection.Calculate();
            }

            return 0;
        }
    }
}
