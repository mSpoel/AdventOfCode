using Day20.Modules;

namespace Day20
{
    internal class PulseProcessor
    {
        private readonly Dictionary<string, Module> _modules;

        internal PulseProcessor(Dictionary<string, Module> modules)
        {
            _modules = modules;
        }

        internal (long lowPulses, long highPulses) PushButton(Pulse startPulse)
        {
            var (lowPulses, highPulses) = (0L, 0L);

            Console.WriteLine($"button -{startPulse.ToString().ToLower()}-> broadcaster");

            var broadcaster = _modules[ModuleTypes.Broadcaster] as Broadcaster;

            var queue = new Queue<(string source, string destination, Pulse pulse)>();

            UpdatePulseCount(startPulse, ref lowPulses, ref highPulses);

            foreach (var destination in broadcaster!.Destinations)
            {
                queue.Enqueue((ModuleTypes.Broadcaster, destination, startPulse));

                UpdatePulseCount(startPulse, ref lowPulses, ref highPulses);
            }

            while (queue.Count > 0)
            {
                var (source, destination, pulse) = queue.Dequeue();

                Console.WriteLine($"{source} -{pulse.ToString().ToLower()}-> {destination}");

                var module = _modules[destination];

                Pulse resultPulse = module.Process(pulse, source);

                if (resultPulse == Pulse.None)
                {
                    continue;
                }

                foreach (var resultDestination in module.Destinations)
                {
                    queue.Enqueue((destination, resultDestination, resultPulse));

                    UpdatePulseCount(resultPulse, ref lowPulses, ref highPulses);
                }
            }

            return (lowPulses, highPulses);

            static void UpdatePulseCount(Pulse pulse, ref long lowPulses, ref long highPulses)
            {
                if (pulse == Pulse.Low)
                {
                    lowPulses++;
                }
                else
                {
                    highPulses++;
                }
            }
        }
    }
}
