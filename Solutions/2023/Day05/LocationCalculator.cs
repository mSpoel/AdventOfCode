namespace Day05
{
    internal class LocationCalculator
    {
        private string[] _lines;

        private List<Mapper> _mappers;

        public LocationCalculator(string[] lines)
        {
            _lines = lines;
            _mappers = new Mappers(lines).GetMappers();
        }

        public long GetLocation(long seed)
        {
            var mappedValue = seed;

            foreach (var mapper in _mappers)
            {
                Console.Write($"Map {mapper.Name} - from {mappedValue} \t");

                var mappings = mapper.Mappings.Where(x => x.Key <= mappedValue);

                if (!mappings.Any())
                {
                    Console.Write($"to {mappedValue} \t");
                    continue;
                }
                else
                {
                    var closestKey = mappings.Max(x => x.Key);
                    var closestMapper = mapper.Mappings.Where(x => x.Key == closestKey).FirstOrDefault();

                    if (closestMapper.Value == null)
                    {
                        Console.Write($"to {mappedValue} \t");
                        continue;
                    }

                    if (mappedValue <= closestMapper.Value.Source + closestMapper.Value.Range)
                    {
                        mappedValue += closestMapper.Value.Destination - closestMapper.Value.Source;
                    }
                }

                Console.Write($"to {mappedValue} \t");
            }

            Console.WriteLine();
            return mappedValue;
        }

        public long GetMinLocationRangeBased(List<(long From, long To)> seedRanges)
        {
            foreach (var mapper in _mappers)
            {
                var orderedMappers = mapper.Mappings.OrderBy(x => x.Key).ToList();
                var newRanges = new List<(long From, long To)>();

                foreach (var seedRange in seedRanges)
                {
                    var range = seedRange;

                    foreach (var mapping in orderedMappers)
                    {
                        var mappingFrom = mapping.Value.Source;
                        var mappingTo = mapping.Value.Source + mapping.Value.Range - 1;
                        var mappingAdjustment = mapping.Value.Destination - mapping.Value.Source;

                        if (range.From < mappingFrom)
                        {
                            newRanges.Add((range.From, Math.Min(range.To, mappingFrom - 1)));
                            range.From = mappingFrom;
                            if (range.From >= range.To)
                            {
                                break;
                            }
                        }

                        if (range.From <= mappingTo)
                        {
                            newRanges.Add((range.From + mappingAdjustment, Math.Min(range.To, mappingTo) + mappingAdjustment));
                            range.From = mappingTo + 1;
                            if (range.From >= range.To)
                            {
                                break;
                            }
                        }
                    }

                    if (range.From < range.To)
                    {
                        newRanges.Add(range);
                    }
                }
                seedRanges = newRanges;
            }

            return seedRanges.Min(sr => sr.From);
        }
    }
}
