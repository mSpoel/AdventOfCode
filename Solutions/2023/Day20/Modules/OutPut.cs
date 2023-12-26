namespace Day20.Modules
{
    internal class OutPut(string name) : Module(name)
    {
        internal override Pulse Process(Pulse pulse, string input)
        {
            return Pulse.None;
        }
    }
}