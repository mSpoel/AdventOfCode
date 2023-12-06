using System.Text.RegularExpressions;

namespace Day01
{
    internal class SolverPart2
    {
        public int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            foreach (var line in lines)
            {
                var formattedLine = GetFormattedLine(line);

                var digits = Regex.Replace(formattedLine, @"\D", "");

                int digit = CalculateDigit(digits);
                result += digit;

                Console.WriteLine($"line: {line} - formattedline: {formattedLine} - digit: {digit}");
            }

            return result;
        }

        private string GetFormattedLine(string line)
        {
            //string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            Dictionary<string, string> numbers = new Dictionary<string, string>
            {
                { "one", "1" },
                { "two", "2" },
                { "three", "3" },
                { "four", "4" },
                { "five", "5" },
                { "six", "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine", "9" }
            };

            int minIndex = int.MaxValue;
            string minValue = string.Empty;

            int maxIndex = -1;
            string maxValue = string.Empty;

            foreach (var number in numbers)
            {
                var firstIndex = line.IndexOf(number.Key);
                if (firstIndex > -1 && firstIndex < minIndex)
                { 
                    minIndex = firstIndex;
                    minValue = number.Key;
                }

                var lastIndex = line.LastIndexOf(number.Key);
                if (lastIndex > -1 && maxIndex < lastIndex) 
                {
                    maxIndex = lastIndex;
                    maxValue = number.Key;
                }
            }

            if (minIndex == maxIndex)
            {
                maxValue = string.Empty;
            }

            if (minValue != string.Empty)
            {
                line = line.Remove(minIndex, minValue.Length);
                line = line.Insert(minIndex, numbers[minValue]);

                if (maxIndex >= minIndex + minValue.Length)
                {
                    maxIndex = maxIndex - minValue.Length + 1;
                }
                else
                {
                    if (maxValue != string.Empty)
                    {
                        line = line.Remove(maxIndex - 1, maxValue.Length-1);
                        line = line.Insert(maxIndex -1 , numbers[maxValue]);
                    }

                    maxValue = string.Empty;
                }
            }

            if (maxValue != string.Empty)
            {
                line = line.Remove(maxIndex, maxValue.Length);
                line = line.Insert(maxIndex, numbers[maxValue]);
            }

            return line;
        }

        private int CalculateDigit(string digits)
        {
            if (digits.Length == 0)
            {
                return 0;
            }

            if (digits.Length == 1)
            {

                var digit = int.Parse(digits);
                return digit * 10 + digit;
            }

            var firstDigit = int.Parse(digits.Substring(0, 1));
            var lastDigit = int.Parse(digits.Substring(digits.Length - 1));

            return 10 * firstDigit + lastDigit;
        }
    }
}
