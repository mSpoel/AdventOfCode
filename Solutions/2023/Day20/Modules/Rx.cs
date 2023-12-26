namespace Day20.Modules
{
    internal class Rx : Module
    {
        internal Rx(string name) : base(name)
        {
        }

        internal override Pulse Process(Pulse pulse, string input)
        {
            if (pulse == Pulse.Low)
            {
                return Pulse.Rx;
            }

            return Pulse.None;
        }
    }
}
