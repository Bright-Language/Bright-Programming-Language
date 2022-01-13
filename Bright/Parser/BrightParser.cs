using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;
using Bright.Parser.Parse;

namespace Bright.Parser {
    public class BrightParser {

        List<Node> AST;

        int Line=1;

        public BrightParser() {
            AST=new List<Node>();
        }

        public List<Node> Parse(Token[] tokens) {
            for (int node=0;node<tokens.Length;node++) {
                switch (tokens[node].TokenName) {
                    case Tokens.IntType: AST.Add(IntVar.Parse(tokens, node, Line)); break;
                    case Tokens.Newline: Line++; break;
                }
            }
            return AST;
        }
    }
}