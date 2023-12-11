namespace Day03
{
    internal class Digit
    {
        public Digit(int value, int lineNumber, int startIndex, int endIndex)
        {
            Value = value;
            LineNumber = lineNumber;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        public int Value { get; }

        public int LineNumber { get; }

        public int StartIndex { get; }

        public int EndIndex { get; }
    }
}
