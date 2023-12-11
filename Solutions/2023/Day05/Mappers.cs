namespace Day05
{
    internal class Mappers
    {
        private readonly string[] _lines;

        public Mappers(string[] lines)
        {
            _lines = lines;
        }

        internal List<Mapper> GetMappers()
        {
            var result = new List<Mapper>();

            string name = string.Empty;
            var mappings = new Dictionary<long, Map>();

            for (int i = 1; i < _lines.Length; i++)
            {
                var line = _lines[i];

                if (line.Trim().Length == 0)
                {
                    if (name != string.Empty)
                    {
                        result.Add(new Mapper(name, mappings));
                        name = string.Empty;
                        mappings = new Dictionary<long, Map>();
                    }
                    continue;
                }

                if (line.Contains("map"))
                {
                    // Map line, so this contains the name of the mapping
                    name = line.Split(' ')[0].Trim();
                }
                else
                {
                    // Mapping line, so this contains the mapping
                    var split = line.Split(' ');
                    var map = new Map(
                        long.Parse(split[0].Trim()),
                        long.Parse(split[1].Trim()),
                        long.Parse(split[2].Trim()));

                    mappings.Add(map.Source, map);
                }

                if (i == _lines.Length - 1)
                {
                    result.Add(new Mapper(name, mappings));
                }
            }

            return result;

        }
    }
}
