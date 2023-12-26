namespace Day20.Modules
{
    internal class Broadcaster : Module
    {
        internal Broadcaster(string name) : base(name)
        {
        }

        internal override Pulse Process(Pulse pulse, string input)
        {
            return pulse;
        }
    }
}
