namespace Day06
{
    internal class Race
    {
        public Race(long time, long record)
        {
            Time = time;
            Record = record;
        }

        public long Time { get; }
        public long Record { get; }
    }
}
