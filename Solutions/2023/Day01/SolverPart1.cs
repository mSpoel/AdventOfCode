using System.Text.RegularExpressions;

namespace Day01
{
    internal class SolverPart1
    {
        public int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            foreach(var line in  lines) 
            {
                var digits = Regex.Replace(line, @"\D", "");

                int digit = CalculateDigit(digits);
                result += digit;

                Console.WriteLine($"line: {line} - digit: {digit}");
            }

            return result;
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
