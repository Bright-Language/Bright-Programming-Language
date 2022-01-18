namespace Bright.Parser.Parsing {
	public struct Node {
		NodeTypes Type;
		object left;
		object mid;
		object right;
		object value;
		int Line;
		List<Node> InnerNodes;
	}
}
