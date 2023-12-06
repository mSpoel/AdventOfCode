namespace Day03
{
    internal class Gear
    {
        public Gear(int index, int _lineNumber)
        {
            Index = index;
            LineNumber = _lineNumber;
        }

        public int Index { get; }

        public int LineNumber { get; }
    }
}