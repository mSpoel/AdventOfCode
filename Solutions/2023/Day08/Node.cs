namespace Day08
{
    internal class Node
    {
        private string _nodeAsString;
        private Dictionary<string, string> _nextNodes = new Dictionary<string, string>();

        public Node(string nodeAsString)
        {
            _nodeAsString = nodeAsString;
            Name = nodeAsString.Split(" = ")[0].Trim();
            _nextNodes.Add("L", nodeAsString.Split(" = ")[1].Split(", ")[0].Replace("(", string.Empty).Trim());
            _nextNodes.Add("R", nodeAsString.Split(" = ")[1].Split(", ")[1].Replace(")", string.Empty).Trim());
        }

        public string Name { get; internal set; }

        public string NextNodeName(string direction)
        {
            return _nextNodes[direction];
        }

        public override string ToString()
        {
            return $"{Name} L: {_nextNodes["L"]} R: {_nextNodes["R"]}";
        }
    }
}