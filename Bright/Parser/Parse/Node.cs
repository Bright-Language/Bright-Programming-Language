namespace Bright.Parser.Parse {
    public struct Node {
        public TokenTypes type;
        public object value;
        public object right;
        public object left;
        public int line;
    }
}