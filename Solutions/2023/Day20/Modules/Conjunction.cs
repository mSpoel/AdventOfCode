namespace Day20.Modules
{
    internal class Conjunction : Module
    {
        private readonly Dictionary<string, Pulse> _inputs = [];

        internal Conjunction(string name) : base(name)
        {
        }

        internal void AddInput(string input)
        {
            _inputs.Add(input, Pulse.Low);
        }

        internal override Pulse Process(Pulse pulse, string input)
        {
            _inputs[input] = pulse;

            if (_inputs.Values.Any(p => p == Pulse.Low))
            {
                return Pulse.High;
            }

            return Pulse.Low;
        }
    }
}
