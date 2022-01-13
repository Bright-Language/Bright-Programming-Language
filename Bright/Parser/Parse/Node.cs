namespace Bright.Parser.Parse {
    public struct Node {
        public TokenTypes type;
        public string value;
        public string right;
        public string left;
        public int line;
    }
}