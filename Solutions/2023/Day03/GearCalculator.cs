namespace Day03
{
    internal class GearCalculator
    {
        private readonly string[] _lines;
        private readonly List<Digit> _digits;

        public GearCalculator(string[] lines, List<Digit> digits)
        {
            _lines = lines;
            _digits = digits;
        }

        public int GetValue(Gear gear)
        {
            int lineNumber = gear.LineNumber;

            int beginLineNumber = gear.LineNumber - 1;
            if (beginLineNumber < 0)
            {
                beginLineNumber = 0;
            }

            int endLineNumber = gear.LineNumber + 1;
            if (endLineNumber >= _lines.Length)
            {
                endLineNumber = _lines.Length - 1;
            }

            List<int> numbers = new List<int>();
            foreach (var digit in _digits)
            {
                if (digit.LineNumber >= beginLineNumber && digit.LineNumber <= endLineNumber)
                {
                    // it should actually be EndIndex -1 but I made a mistake in the Digit class
                    if (digit.EndIndex  >= gear.Index 
                        && digit.StartIndex -1  <= gear.Index)
                    {
                        numbers.Add(digit.Value);
                        Console.Write($"digit: {digit.Value} \t");
                    }
                }
            }

            if(numbers.Count == 2)
            {
                return numbers[0] * numbers[1];
            } 

            return 0;
        }
    }
}
