

namespace Day03
{
    internal class SolverPart2
    {
        public long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            long result = 0;
            foreach (var line in lines)
            {
                var digits = line.Select(c => int.Parse(c.ToString())).ToList();

                long lineResult = 0;
                int skipIndex = 0;

                Console.WriteLine($"Processing line: {line} with number of digits: {digits.Count}");
                int digitsCount = digits.Count;
                int takeIndex = digitsCount-11;
                int count = 0;
                for(int i= 11; i > -1; i--)
                {
                    takeIndex = Math.Max(takeIndex - count, 1);
                    count++;
                    var tempDigits = digits.Skip(skipIndex).Take(takeIndex).ToList();
                    Console.WriteLine($"Taking digits from index {skipIndex} count {takeIndex}");
                    Console.WriteLine("Temp digits: " + string.Join(",", tempDigits));
                    int max = tempDigits.Max();
                    skipIndex = skipIndex + tempDigits.IndexOf(max)+1;

                    lineResult += (long)Math.Pow(10, i) * max;
                   
                    Console.WriteLine($"Max for position {i}: {max} at index {skipIndex-1} lineResult: {lineResult}");
                }

                Console.WriteLine($"Line result: {lineResult}");
                result += lineResult;
            }

            return result;
        }
    }
}
