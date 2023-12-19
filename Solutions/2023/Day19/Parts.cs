namespace Day19
{
    internal class Parts
    {

        public Parts(string line)
        {
            var cleanLine = line.Replace("{", string.Empty).Replace("}", string.Empty);
            X = int.Parse(cleanLine.Split(',')[0][2..]);
            M = int.Parse(cleanLine.Split(',')[1][2..]);
            A = int.Parse(cleanLine.Split(',')[2][2..]);
            S = int.Parse(cleanLine.Split(',')[3][2..]);
        }

        public int X { get; }

        public int M { get; }

        public int A { get; }

        public int S { get; }
    }
}