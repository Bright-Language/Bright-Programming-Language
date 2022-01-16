namespace Bright.Parser.Parse {
    public class Node {
        public Node(NodeTypes type) {
            Type=type;
            InnerNodes = new List<Node>();
        }
        public NodeTypes Type {get;}
        public object value { get; set; }
        public object right { get; set; }
        public object mid { get; set; }
        public object left { get; set; }
        public int Line { get; set; }
        public int Index { get; set; }
        public List<Node> InnerNodes { get; set; }
    }
}