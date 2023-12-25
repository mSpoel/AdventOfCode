namespace Day25
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            Dictionary<string, Node> nodes = [];

            foreach (var line in lines)
            {
                var parts = line.Split(':');

                var nodeName = parts[0];

                if (!nodes.TryGetValue(nodeName, out Node? node))
                {
                    node = new Node(nodeName);
                    nodes.Add(nodeName, node);
                }

                foreach (var child in parts[1].Trim().Split(' '))
                {
                    node.AddChild(child);

                    if (!nodes.TryGetValue(child, out Node? childNode))
                    {
                        childNode = new Node(child);
                        nodes.Add(child, childNode);
                    }

                    nodes[child] = childNode;
                }

                nodes[nodeName] = node;
            }

            List<(string node1, string node2)> edges = [];
            foreach (var node in nodes.Values)
            {
                foreach (var child in node.Children)
                {
                    var edge = new List<string> { node.Name, child };
                    edge.Sort();

                    var sortedEdge = (edge[0], edge[1]);

                    if (edges.Contains(sortedEdge))
                    {
                        continue;
                    }

                    edges.Add(sortedEdge);
                }

            }

            Console.WriteLine("graph {");
            foreach (var edge in edges)
            {
                Console.WriteLine($"{edge.node1} -- {edge.node2};");
            }
            Console.WriteLine("}");

            return result;
        }
    }
}
