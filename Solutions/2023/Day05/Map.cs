namespace Day05
{
    internal class Map
    {
        public Map(long destination, long source, long range)
        {
            Destination = destination;
            Source = source;
            Range = range;
        }

        public long Destination { get; }

        public long Source { get; }

        public long Range { get; }

    }
}
