using System.Text.RegularExpressions;

namespace Day03
{
    internal class LineDigits
    {
        private readonly string _line;
        private readonly int _lineNumber;

        public LineDigits(string line, int lineNumber)
        {
            _line = line;
            _lineNumber = lineNumber;
        }

        internal List<Digit> GetDigits()
        {
            var result = new List<Digit>();
            var digits = Regex.EnumerateMatches(_line, @"\d+");
            
            foreach(var digitMatch in digits) 
            {
                var digit = new Digit(
                    int.Parse(_line.Substring(digitMatch.Index, digitMatch.Length)),
                    _lineNumber,
                    digitMatch.Index,
                    digitMatch.Length + digitMatch.Index );

                result.Add(digit);
            }

            return result;
        }
    }
}
