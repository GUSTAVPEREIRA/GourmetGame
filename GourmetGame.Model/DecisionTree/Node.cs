namespace GourmetGame.Model.BinaryTree
{
    public class Node
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Node YesNode { get; set; }
        public Node NoNode { get; set; }
        public Node Parent { get; set; }

        public Node(string name, Node parent)
        {
            Name = name;
            Parent = parent;
        }

        public Node(string name) : this(name, null)
        {
        }
    }
}