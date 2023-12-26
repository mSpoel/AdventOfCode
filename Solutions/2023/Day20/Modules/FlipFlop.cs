namespace Day20.Modules
{
    internal class FlipFlop : Module
    {
        internal FlipFlop(string name) : base(name)
        {
            State = ModuleState.Off;
        }

        public ModuleState State { get; internal set; }

        internal override Pulse Process(Pulse pulse, string input)
        {
            if (pulse == Pulse.High)
            {
                return Pulse.None;
            }

            if (State == ModuleState.On)
            {
                State = ModuleState.Off;
                return Pulse.Low;
            }

            State = ModuleState.On;
            return Pulse.High;
        }
    }
}
