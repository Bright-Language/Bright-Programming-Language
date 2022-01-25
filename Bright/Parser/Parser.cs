using Bright.Parser.Parsing;
using System.Collections.Generic;
using Bright.Lexer;
using static Bright.Lexer.TokenParser;
using Bright.Utils;
using static Bright.Utils._Exit;

namespace Bright.Parser {
    public static class BrightParser{

        public static int node=0;
        public static int line=1;
        public static List<Node> AST=new List<Node>();

        public static List<Node> Parse(List<Token> tokens) {
            while (tokens[node].TokenName!=Tokens.EOF) {
                AST.Add(Peek(tokens, node));
                node++;
            }
            return AST;
        }

        public static Node Peek(List<Token> tokens, int node) {
            switch (tokens[node].TokenName) {
                case Tokens.StringType: return StrDef.Parse(tokens);
                case Tokens.EOF: return new Node(NodeType.EOF);
            }
            //Error.print($"Parser: Something went wrong... (Line {line})");
            return null;
        }
    }
}