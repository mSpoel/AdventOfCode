using System.Text.RegularExpressions;

namespace Day02
{
    internal class SolverPart2
    {
        public Int64 GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);
            string line = lines[0];
            var ranges = line.Split(',');
            Int64 sumOfDoubles = 0;

            foreach (var range in ranges)
            {
                var bounds = range.Split('-');
                Int64 lowerBound = Int64.Parse(bounds[0]);
                Int64 upperBound = Int64.Parse(bounds[1]);
                Console.WriteLine($"lowerBound: {lowerBound}, upperBound: {upperBound}");

                for (Int64 number = lowerBound; number <= upperBound; number++)
                {
                    string numberStr = number.ToString();
                    
                    for (int i = 0; i < numberStr.Length / 2; i++)
                    {
                        int length = i + 1;
                        string numberToCheck = numberStr.Substring(0, length);
                        //Console.WriteLine($"Checking number: {numberToCheck}");

                        int repetitions = numberStr.Length / length;
                        string constructedNumber = String.Concat(Enumerable.Repeat(numberToCheck, repetitions));
                        if (constructedNumber == numberStr)
                        {
                          Console.WriteLine($"Found matching number: {numberStr}");
                          sumOfDoubles += (Int64)number;
                          break;
                        }
                    }
                   
                }
            }

            return sumOfDoubles;
        }
    }
}
