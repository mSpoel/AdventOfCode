
namespace Day08
{
    internal class RouteCalculator
    {
        private Map _map;
        private string _directions;

        public RouteCalculator(Map map, string directions)
        {
            _map = map;
            _directions = directions;
        }

        internal int GetNumberOfSteps(string startNodeName, List<string> endNodes)
        {
            string currentNodeName = startNodeName;
            int count = 0;
            int index = 0;

            while (!endNodes.Contains(currentNodeName))
            {
                var currentNode = _map.GetNode(currentNodeName);
                var nextNodeName = currentNode.NextNodeName(_directions[index].ToString());

                Console.WriteLine($"{count} {currentNode} {_directions[index]} {nextNodeName}");

                currentNodeName = nextNodeName;

                if (index == _directions.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }

                count++;
            }

            return count;
        }
    }
}
