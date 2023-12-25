namespace Day25
{
    internal class Node
    {
        internal Node(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public List<string> Children { get; private set; } = [];

        public void AddChild(string child)
        {
            if (Children.Contains(child))
            {
                return;
            }

            Children.Add(child);
        }
    }
}
