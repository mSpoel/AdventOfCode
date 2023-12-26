
namespace Day20.Modules
{
    internal abstract class Module
    {
        private readonly List<string> _destinations = [];

        internal Module(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public IEnumerable<string> Destinations => _destinations;

        public virtual void AddDestination(string destination)
        {
            _destinations.Add(destination);
        }

        internal abstract Pulse Process(Pulse pulse, string input);
    }
}
