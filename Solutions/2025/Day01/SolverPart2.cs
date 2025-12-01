namespace Day01
{
    internal class SolverPart2
    {
        public int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int currentNumber = 50;
            int counter = 0;

            foreach (var line in lines)
            {
                var direction = line[0];
                int move = int.Parse(line.Substring(1));
                int delta = direction == 'L' ? -move : move;

                int start = currentNumber;
                int newValue = start + delta;

                // DivRem uses truncating division; adjust to floor division for negatives
                int remainder;
                int quotient = Math.DivRem(newValue, 100, out remainder);
                if (remainder < 0)
                {
                    remainder += 100;
                    quotient--; // convert truncating quotient to floor quotient
                }

                // Wraps are the absolute floor-quotient (how many times we passed 0)
                int crossings = Math.Abs(quotient);

                // Normalize final position to [0..99]
                int end = remainder;

                // Landing exactly on 0 also counts
                if (end == 0)
                {
                    crossings++;
                }

                // Edge case: starting at 0 and moving left
                // DivRem floor logic would count one wrap immediately,
                // but leaving 0 should NOT be counted as "passing 0".
                if (start == 0 && delta < 0 && end != 0)
                {
                    crossings = Math.Max(0, crossings - 1);
                }

                counter += crossings;
                currentNumber = end;

                Console.WriteLine($"line: {line} direction: {direction} move: {move} currentNumber: {currentNumber} counter: {counter}");
            }

            return counter;
        }
    }
}
