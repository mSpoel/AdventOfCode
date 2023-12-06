namespace Day05
{
    internal class Mapper
    {
        public Mapper(string name, Dictionary<long, Map> mappings)
        {
            Name = name;
            Mappings = mappings;
        }

        public string Name { get; }
        public Dictionary<long, Map> Mappings { get; }
    }
}
