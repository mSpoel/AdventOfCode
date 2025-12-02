using System.Text.RegularExpressions;

namespace Day02
{
    internal class SolverPart1
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
                    
                    //skip numbers that have uneven length
                    if (numberStr.Length % 2 != 0)
                    {
                        continue;   
                    }

                    if (numberStr.Substring(0, numberStr.Length / 2) 
                        == numberStr.Substring(numberStr.Length / 2))
                    {
                        Console.WriteLine($"Found matching number: {numberStr}");
                        sumOfDoubles += (Int64)number;
                    }   
                }
            }

            return sumOfDoubles;
        }
    }
}
