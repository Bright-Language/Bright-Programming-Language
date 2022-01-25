using System.Collections.Generic;

namespace Bright.Parser.Parsing {
    public class Node {
        public Node(NodeType Type) {
            this.Type=Type;
        }

        public NodeType Type { get; }
        public object Left { get; set; }
        public object Mid { get; set; }
        public object Right { get; set; }
        public object Value { get; set; }
        public List<Node> InnerNodes { get; set; }
    }
}
