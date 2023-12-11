

namespace Day08
{
    internal class Map
    {
        private readonly Dictionary<string, Node> _nodes = new Dictionary<string, Node>();

        public Map(IEnumerable<string> nodes)
        {
            foreach (var nodeAsString in nodes)
            {
                var node = new Node(nodeAsString);
                _nodes.Add(node.Name, node);
            }
        }

        public Node GetNode(string name)
        {
            return _nodes[name];
        }

        internal List<string> GetNodesEndingWith(char character)
        {
            return _nodes.Where(n => n.Key.EndsWith(character)).Select(n => n.Key).ToList();
        }
    }
}
