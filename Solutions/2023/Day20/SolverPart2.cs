using Day20.Modules;
using Utilities;

namespace Day20
{
    internal class SolverPart2
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            Dictionary<string, Module> modules = [];

            foreach (var line in lines)
            {
                var parts = line.Split("->");

                var moduleName = parts[0].Trim();

                Module module;
                if (moduleName.StartsWith(ModuleTypes.Broadcaster))
                {
                    module = new Broadcaster(moduleName);
                }
                else if (moduleName.StartsWith(ModuleTypes.FlipFlop))
                {
                    module = new FlipFlop(moduleName.Substring(1));
                }
                else if (moduleName.StartsWith(ModuleTypes.Conjunction))
                {
                    module = new Conjunction(moduleName.Substring(1));
                }
                else
                {
                    throw new Exception("Unknown module type");
                }

                foreach (var destination in parts[1].Split(','))
                {
                    var destinationName = destination.Trim();
                    module.AddDestination(destinationName);
                }

                modules.Add(module.Name, module);
            }

            foreach (var module in modules.Values.Where(m => m is Conjunction))
            {
                foreach (var mod in modules.Values.Where(n => n.Name != module.Name))
                {
                    if (mod.Destinations.Contains(module.Name))
                    {
                        ((Conjunction)module).AddInput(mod.Name);
                    }
                }
            }

            modules.Add(ModuleTypes.OutPut, new OutPut(ModuleTypes.OutPut));
            modules.Add("rx", new Rx("rx"));

            var pulseProcessor = new PulseProcessor(modules);

            long count = 1;
            bool stop = false;

            while (!stop)
            {
                var (lowPulses, highPulses) = pulseProcessor.PushButton(Pulse.Low, count++);

                if (!modules.Values.Any(m => m is Conjunction && m.GetCount() == long.MaxValue))
                {
                    stop = true;
                }
            }

            List<long> outputs = [];
            foreach (var module in modules.Values.Where(m => m is Conjunction))
            {
                outputs.Add(((Conjunction)module).GetCount());
            }

            return Calculator.Lcm(outputs.ToArray());
        }
    }
}
