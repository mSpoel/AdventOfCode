

namespace Day20.Modules
{
    internal abstract class Module
    {
        private readonly List<string> _destinations = [];

        private long _count = long.MaxValue;

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

        internal void SetCount(long count)
        {
            if (count < _count)
            {
                _count = count;
            }
        }

        internal long GetCount()
        {
            return _count;
        }
    }
}
