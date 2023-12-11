namespace Day02
{
    internal class GameRound
    {
        public GameRound(string input)
        {
            //Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            var firstSplit = input.Split(": ");

            Number = GetNumber(firstSplit[0]);
            CubeSets = GetCubeSets(firstSplit[1]);

        }

        private List<CubeSet> GetCubeSets(string setsAsString)
        {
            var result = new List<CubeSet>();
            var sets = setsAsString.Split(';');

            foreach(var set in sets) 
            {
                result.Add(new CubeSet(set)); 
            }

            return result;
        }

        private int GetNumber(string gameNumber)
        {
            var number = gameNumber.Remove(0, "Game ".Length);
            return int.Parse(number);
        }

        internal bool IsPossible(CubeSet checkSet)
        {
            foreach(var  cubeSet in CubeSets)
            {
                if (!cubeSet.IsPossible(checkSet))
                {
                    return false;
                }
            }

            return true;
        }

        internal int GetPower()
        {
            int result = 0;
            int red = 0;
            int green = 0;
            int blue = 0;

            foreach (var cubeSet in CubeSets)
            {
                if (cubeSet.NrOfRed > red)
                {
                    red = cubeSet.NrOfRed;
                }

                if(cubeSet.NrOfGreen > green) 
                {
                    green = cubeSet.NrOfGreen;
                }

                if (cubeSet.NrOfBlue > blue)
                {
                    blue = cubeSet.NrOfBlue;
                }
            }

            return red * green * blue;
        }

        public int Number { get; }

        public List<CubeSet> CubeSets { get; }
    }
}
