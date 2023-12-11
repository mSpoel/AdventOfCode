using System.Text.RegularExpressions;

namespace Day03
{
    internal class DigitValidator
    {
        private readonly string[] _lines;

        public DigitValidator(string[] lines)
        {
            _lines = lines;
        }

        internal bool IsValid(Digit digit)
        {
            int lineNumber = digit.LineNumber;

            int beginLineNumber = digit.LineNumber - 1;
            if(beginLineNumber < 0)
            {
                beginLineNumber = 0;
            }

            int endLineNumber = digit.LineNumber + 1;
            if(endLineNumber >= _lines.Length)
            {
                endLineNumber = _lines.Length - 1;
            }

            int startIndex = digit.StartIndex -1;
            if(startIndex < 0)
            {
                startIndex = 0;
            }   

            int endIndex = digit.EndIndex + 1;
            if(endIndex >= _lines[lineNumber].Length)
            {
                endIndex = _lines[lineNumber].Length - 1;
            }
            

            bool matchFound = false;
            for(int i = beginLineNumber; i <= endLineNumber; i++)
            {
                var stringToCheck = _lines[i].Substring(startIndex, endIndex - startIndex);
                Console.Write($"Checking {stringToCheck} \t");

                if (!Regex.IsMatch(stringToCheck, @"^[0-9\.]*$"))
                //if (Regex.IsMatch(stringToCheck, @"[!@#$%^&*()_+=\-<>/?]"))
                {
                    matchFound = true;
                }
            }
            
            return matchFound;

        }
    }
}
