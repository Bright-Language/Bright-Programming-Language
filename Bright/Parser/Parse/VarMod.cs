using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class VarMod {
        public static object Parse(List<Token> tokens, int Line) {
            if (HasSemi.CheckSemi(tokens)) {
                string VarName=tokens[BrightParser.node].TokenValue;
                WaitFor.WaitForToken(Tokens.Equals, tokens, Line); //the result: =
                BrightParser.node++;
                WaitFor.WaitForToken(new Tokens[]{Tokens.Integer, Tokens.String, Tokens.Float}, tokens, Line);
                List<Token> Value=new List<Token>();
                while (tokens[BrightParser.node].TokenName!=Tokens.Semicolon) {
                    Value.Add(tokens[BrightParser.node]);
                    BrightParser.node++;
                }
                BrightParser.node++;
                return new Node(NodeTypes.VARMOD){left=VarName,right=Value,Line=Line};
            } else {
                Console.WriteLine($"Parser: Error:\nLine {Line}: Expected SemiColon (;)");
                Environment.Exit(1);
                return null;
            }
        }
    }
}