using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class IfStmt {
        public static object Parse(List<Token> tokens, int Line) {
            WaitFor.WaitForToken(Tokens.Lparen, tokens, Line);
            BrightParser.node++;
            WaitFor.WaitForToken(new Tokens[]{Tokens.Identifier, Tokens.Integer, Tokens.String, Tokens.Float}, tokens, Line);
            object left=tokens[BrightParser.node].TokenValue;
            BrightParser.node++;
            WaitFor.WaitForToken(new Tokens[]{Tokens.EQEQ}, tokens, Line);
            object mid=tokens[BrightParser.node].TokenValue;
            BrightParser.node++;
            WaitFor.WaitForToken(new Tokens[]{Tokens.Identifier, Tokens.Integer, Tokens.String, Tokens.Float}, tokens, Line);
            object right=tokens[BrightParser.node].TokenValue;
            BrightParser.node++;
            WaitFor.WaitForToken(Tokens.OpenBrace, tokens, Line);
            List<Node> block=new List<Node>();
            block=Block.Parse(tokens, Line);
            return new Node(NodeTypes.IFSTMT){left=left,mid=mid,right=right,InnerNodes=block};
        }
    }
}