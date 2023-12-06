using System.Text.RegularExpressions;

namespace Day02
{
    internal class CubeSet
    {
        public CubeSet(int red, int green, int blue)
        {
            NrOfRed = red;
            NrOfGreen = green;
            NrOfBlue = blue;
        }

        public CubeSet(string set)
        {
            var colors = set.Split(',');

            foreach (var color in colors)
            {
                if (color.Contains("blue"))
                {
                    NrOfBlue = GetNumber(color);
                }

                if (color.Contains("red"))
                {
                    NrOfRed = GetNumber(color);
                }

                if (color.Contains("green"))
                {
                    NrOfGreen = GetNumber(color);
                }
            }
        }

        private int GetNumber(string color)
        {
            var digits = Regex.Replace(color, @"\D", "");
            return int.Parse(digits);
        }

        public int NrOfGreen { get; }
        public int NrOfRed { get; }
        public int NrOfBlue { get; }

        public bool IsPossible(CubeSet cubeSet) 
        {
            if (cubeSet.NrOfRed < NrOfRed)
            {
                return false;
            }

            if (cubeSet.NrOfBlue < NrOfBlue) 
            {
                return false;
            }

            if (cubeSet.NrOfGreen < NrOfGreen)
            {
                return false;
            }

            return true;
        }
    }
}
