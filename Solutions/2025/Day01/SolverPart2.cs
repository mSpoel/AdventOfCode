using System;
using System.IO;

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

                // Normalize final position
                int end = ((start + delta) % 100 + 100) % 100;

                int crossings = 0;

                if (delta > 0)
                {
                    // Moving right: first time you hit 0 is after (100 - start), then every +100
                    int firstHit = 100 - start;
                    if (delta >= firstHit)
                    {
                        crossings = 1 + (delta - firstHit) / 100;
                    }
                }
                else if (delta < 0)
                {
                    // Moving left: first time you hit 0 is after 'start' steps, then every +100
                    int m = -delta;

                    if (start == 0)
                    {
                        // Starting at 0 and moving left: don't count the starting position as a hit
                        // You only hit 0 again every full 100 steps
                        crossings = m / 100;
                    }
                    else
                    {
                        if (m >= start)
                        {
                            crossings = 1 + (m - start) / 100;
                        }
                    }
                }
                // delta == 0: crossings = 0

                counter += crossings;
                currentNumber = end;

                Console.WriteLine(
                    $"line: {line} direction: {direction} move: {move} start: {start} end: {end} crossings: {crossings} total: {counter}"
                );
            }

            return counter;
        }
    }
}
