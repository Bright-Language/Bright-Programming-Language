using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class Block {
        public static List<Node> Parse(List<Token> tokens, int Line) {
            List<Node> toks=new List<Node>();
            if (tokens[BrightParser.node].TokenName==Tokens.OpenBrace) {
                int opened=1;
                while (opened>=1) {
                    BrightParser.node++;
                    if (BrightParser.node==tokens.Count) {
                        Console.WriteLine($"Missing close brace: Line {Line}");
                        Environment.Exit(2);
                    }
                    if (tokens[BrightParser.node].TokenName==Tokens.OpenBrace) { opened++; BrightParser.node++; }
                    else if (tokens[BrightParser.node].TokenName==Tokens.CloseBrace) { opened--; BrightParser.node++; }
                    else {
                        if (tokens[BrightParser.node].TokenName==Tokens.Newline) {
                            BrightParser.Line++;
                        } else {
                            Node nod;
                            nod=(Node)BrightParser.Peek(BrightParser.node, tokens, Line);
                            
                            toks.Add(nod);
                        }
                    }
                }
            }
            return toks;
        }
    }
}