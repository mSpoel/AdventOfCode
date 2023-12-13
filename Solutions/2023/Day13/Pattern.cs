
namespace Day13
{
    public class Pattern
    {
        private char[][] _pattern;
        private readonly List<int> _rowsToIgnore;
        private readonly List<int> _columnsToIgnore;
        private List<int> _reflectionRows = [];
        private List<int> _reflectionColumns = [];

        public Pattern(char[][] pattern, List<int> rowsToIgnore, List<int> columnsToIgnore)
        {
            _pattern = pattern;
            _rowsToIgnore = rowsToIgnore;
            _columnsToIgnore = columnsToIgnore;
        }

        internal int GetReflectionNumber()
        {
            WriteToConsole();

            return GetReflectionNumber(_pattern) + 100 * GetReflectionNumber(Transpose(_pattern), true);
        }

        internal List<int> GetReflectionRows()
        {
            return _reflectionRows;
        }

        internal List<int> GetReflectionColumns()
        {
            return _reflectionColumns;
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

                    if (isTranspose)
                    {
                        if (!_columnsToIgnore.Contains(i))
                        {
                            result += i + 1;
                            _reflectionColumns.Add(i);
                        }
                    }
                    else
                    {
                        if (!_rowsToIgnore.Contains(i))
                        {
                            result += i + 1;
                            _reflectionRows.Add(i);
                        }
                    }
                }
            }

            return result;
        }

        public void WriteToConsole()
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