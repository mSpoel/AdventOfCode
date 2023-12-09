using System.Text.RegularExpressions;

namespace Day09
{
    internal class HistoryRecord
    {
        private string _line;
        private List<int> _records;

        public HistoryRecord(string line)
        {
            _line = line;
            _records = Regex.Matches(line, @"-?\d+")
                .Select(m => int.Parse(m.Value))
                .ToList();
        }

        public int GetPrediction()
        {
            List<int> lastDifferences = new();
            var differences = _records;
            lastDifferences.Add(differences.Last());

            int counter = 0;
            WriteLine(differences, counter);

            while (differences.Count() > 1 && !ElementsAreZero(differences))
            {
                differences = GetDifferences(differences);
                lastDifferences.Add(differences.Last());

                WriteLine(differences, ++counter);
            }

            var result = lastDifferences.Sum();

            Console.WriteLine($"Prediction: {result}");
            Console.WriteLine();

            return result;
        }

        public int GetPredictedHistoryValue()
        {
            List<int> firstDifferences = new();
            var differences = _records;
            firstDifferences.Add(differences.First());

            int counter = 0;
            WriteLine(differences, counter);

            while (differences.Count() > 1 && !ElementsAreZero(differences))
            {
                differences = GetDifferences(differences);
                firstDifferences.Add(differences.First());

                WriteLine(differences, ++counter);
            }

            int firstCount = firstDifferences.Count() - 1;
            int initial = firstDifferences[firstCount - 1] - firstDifferences[firstCount];
            Console.Write($"initials: {initial} \t");

            while (firstCount > 1)
            {

                firstCount--;
                initial = firstDifferences[firstCount - 1] - initial;
                Console.Write($"{initial} \t");
            }

            Console.Write("\n");

            var result = initial;

            Console.WriteLine($"Prediction: {result}");
            Console.WriteLine();

            return result;
        }

        private void WriteLine(List<int> differences, int numberOfStartingTabs)
        {
            for (int i = 0; i < numberOfStartingTabs; i++)
            {
                Console.Write("\t");
            }
            foreach (var difference in differences)
            {
                Console.Write($"{difference} \t");
            }
            Console.Write("\n");
        }

        private static bool ElementsAreZero(List<int> differences)
        {
            foreach (var difference in differences)
            {
                if (difference != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private List<int> GetDifferences(List<int> records)
        {
            return records.SkipLast(1).Zip(records.Skip(1), (a, b) => (a, b))
                .Select(pair => pair.b - pair.a)
                .ToList();
        }


    }
}