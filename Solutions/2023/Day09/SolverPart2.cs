namespace Day09
{
    internal class SolverPart2
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            foreach (var line in lines)
            {
                var historyRecord = new HistoryRecord(line);
                result += historyRecord.GetPredictedHistoryValue();
            }

            return result;
        }
    }
}
