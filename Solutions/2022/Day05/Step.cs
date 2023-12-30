namespace Day05
{
    internal class Step
    {
        public Step(string line)
        {
            var movePart = line.Split(" from ")[0];
            Move = int.Parse(movePart.Remove(0, "move ".Length));

            var fromToPart = line.Split(" from ")[1];
            var fromPart = fromToPart.Split(" to ")[0].Trim();
            var toPart = fromToPart.Split(" to ")[1].Trim();

            From = int.Parse(fromPart);
            To = int.Parse(toPart);
        }

        public int Move { get; }

        public int From { get; }

        public int To { get; }
    }
}