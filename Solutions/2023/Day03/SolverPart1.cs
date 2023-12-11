namespace Day03
{
    internal class SolverPart1
    {
        public int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            List<Digit> digits = new List<Digit>();

            for (int i = 0; i < lines.Length; i++)
            {
                var lineDigits = new LineDigits(lines[i], i);
                digits.AddRange(lineDigits.GetDigits());
            }

            var digitValidator = new DigitValidator(lines);
            int result = 0;
            foreach (var digit in digits)
            {
                if (digitValidator.IsValid(digit))
                {
                    Console.Write($"Valid digit: {digit.Value}");
                    result += digit.Value;
                }
                else
                { 
                    Console.Write($"Invalid digit: {digit.Value}");
                }
                Console.WriteLine();
            }

            return result;
        }

        private bool IsValidDigit(Digit digit, string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
