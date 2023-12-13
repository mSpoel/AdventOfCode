



namespace Day13
{
    public class Pattern
    {
        private char[][] _pattern;


        public Pattern(char[][] pattern)
        {
            _pattern = pattern;
        }

        internal int GetReflectionNumber()
        {
            WriteToConsole();

            return GetReflectionNumber(_pattern) + 100 * GetReflectionNumber(Transpose(_pattern), true);
        }

        internal int GetReflectionNumber(int allowedDifference)
        {
            WriteToConsole();

            return GetReflectionNumber(_pattern, allowedDifference) + 100 * GetReflectionNumber(Transpose(_pattern), allowedDifference, true);
        }

        internal void WriteToConsole()
        {
            for (int i = 0; i < _pattern.Length; i++)
            {
                for (int j = 0; j < _pattern[0].Length; j++)
                {
                    Console.Write(_pattern[i][j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private int GetReflectionNumber(char[][] array, bool isTranspose = false)
        {
            // First loop over the columns with i. Then check for each row it is a reflection at position i.
            var result = 0;

            for (int i = 0; i < array[0].Length; i++)
            {
                var isReflection = true;
                for (int j = 0; j < array.Length; j++)
                {
                    if (!IsReflection(array[j], i))
                    {
                        isReflection = false;
                        break;
                    }
                }

                if (isReflection)
                {
                    // If we reach this point, all rows are reflections at position i.
                    result += i + 1;
                }
            }

            return result;
        }

        private int GetReflectionNumber(char[][] array, int allowedDifference, bool isTranspose = false)
        {
            // First loop over the columns with i. Then check for each row it is a reflection at position i.
            var result = 0;

            for (int i = 0; i < array[0].Length; i++)
            {
                var numberOfDifferences = 0;

                for (int j = 0; j < array.Length; j++)
                {


                    numberOfDifferences += GetDifferences(array[j], i);

                    if (numberOfDifferences > allowedDifference)
                    {
                        break;
                    }
                }

                if (numberOfDifferences == allowedDifference)
                {
                    return i + 1;
                }
            }

            return result;
        }

        private int GetDifferences(char[] line, int i)
        {
            int differences = 0;

            int steps = 0;
            while (i - steps > -1 && i + 1 + steps < line.Length)
            {
                if (line[i - steps] != line[i + 1 + steps])
                {
                    differences++;
                }
                steps++;
            }

            return differences;
        }

        private static bool IsReflection(char[] line, int i)
        {
            if (i + 1 == line.Length)
            {
                return false;
            }

            int steps = 0;
            while (i - steps > -1 && i + 1 + steps < line.Length)
            {
                if (line[i - steps] != line[i + 1 + steps])
                {
                    return false;
                }
                steps++;
            }

            return true;
        }

        private static char[][] Transpose(char[][] array)
        {
            var result = new char[array[0].Length][];

            for (int i = 0; i < array[0].Length; i++)
            {
                result[i] = new char[array.Length];
                for (int j = 0; j < array.Length; j++)
                {
                    result[i][j] = array[j][i];
                }
            }

            return result;
        }
    }
}