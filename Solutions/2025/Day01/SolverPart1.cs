using System.Text.RegularExpressions;

namespace Day01
{
    internal class SolverPart1
    {
        public int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int currentNumber = 50;
            int counter = 0;

            foreach(var line in  lines) 
            {
                var direction = line[0];
                int move = int.Parse(line.Substring(1));

                if (direction == 'L')
                {
                    currentNumber = (currentNumber - move + 100) % 100;
                }
                else
                {
                    currentNumber = (currentNumber + move) % 100;
                }

               if (currentNumber == 0)
               {
                  counter++;
               }


               Console.WriteLine($"line: {line} direction: {direction} move: {move} currentNumber: {currentNumber}");
            }

            return counter;
        }
    }
}
