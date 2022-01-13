using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class FloatVar {
        public static Node Parse(Token[] tokens, int node, int Line) {
            if (HasSemi.CheckSemi(tokens, node)) {
                node++; //skip int
                string tokname=tokens[node].TokenValue;
                node++; //skip tokname
                node++; //skip equals
                string tokvalue="";
                while (tokens[node].TokenName!=Tokens.Semicolon) {
                    tokvalue+=tokens[node].TokenValue;
                    node++;
                }
                Node Node;
                Node=new Node() {
                    type=TokenTypes.VARDEF,
                    left=Types.FLOAT,
                    right=tokname,
                    value=tokvalue,
                    line=Line
                };
                return Node;
            } else {
                Console.WriteLine($"Parser: Error:\nLine {Line}: Missing Semicolon!");
                Environment.Exit(1);
            }
            return new Node();
        }
    }
}