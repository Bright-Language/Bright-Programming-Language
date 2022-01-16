using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class ArgsParams {
        public static List<Node> Parse(List<Token> tokens, int Line) {
            List<Node> ap=new List<Node>();
            //we assume that the current BrightParser.node is (
            BrightParser.node++;
            Console.WriteLine((string)tokens[BrightParser.node].TokenValue);
            while (tokens[BrightParser.node].TokenName!=Tokens.Rparen) {
                if (InterruptTokens.argparam.Contains(tokens[BrightParser.node].TokenName)) {
                    Console.WriteLine($"Parser: Error:\nLine {Line}: Unexpected token {tokens[BrightParser.node].TokenName}");
                    Environment.Exit(1);
                } else if (tokens[BrightParser.node].TokenName==Tokens.StringType || tokens[BrightParser.node].TokenName==Tokens.IntType) {
                    while (tokens[BrightParser.node].TokenName!=Tokens.Rparen) {
                        if (tokens[BrightParser.node].TokenName==Tokens.StringType) {
                            if (tokens[BrightParser.node].TokenName==Tokens.Identifier) {
                                ap.Add(new Node(NodeTypes.PARAM){left=Types.STRING,right=tokens[BrightParser.node].TokenValue,Index=BrightParser.node});
                            } else {
                                Console.WriteLine($"Parser: Error:\nLine {Line}: Expected token {tokens[BrightParser.node].TokenName}");
                                Environment.Exit(1);
                            }
                        } else if (tokens[BrightParser.node].TokenName==Tokens.IntType) {
                            if (tokens[BrightParser.node].TokenName==Tokens.Identifier) {
                                ap.Add(new Node(NodeTypes.PARAM){left=Types.INTEGER,right=tokens[BrightParser.node].TokenValue,Index=BrightParser.node});
                            } else {
                                Console.WriteLine($"Parser: Error:\nLine {Line}: Expected token {tokens[BrightParser.node].TokenName}");
                                Environment.Exit(1);
                            }
                        }
                        BrightParser.node++;
                    }
                } else if (tokens[BrightParser.node].TokenName==Tokens.String || tokens[BrightParser.node].TokenName==Tokens.Integer) {
                    while (tokens[BrightParser.node].TokenName!=Tokens.Rparen) {
                        if (tokens[BrightParser.node].TokenName==Tokens.String) {
                            ap.Add(new Node(NodeTypes.ARG){left=NodeTypes.STRING,right=tokens[BrightParser.node].TokenValue,Index=BrightParser.node});
                        } else if (tokens[BrightParser.node].TokenName==Tokens.IntType) {
                            ap.Add(new Node(NodeTypes.ARG){left=NodeTypes.INT,right=tokens[BrightParser.node].TokenValue,Index=BrightParser.node});
                        }
                        BrightParser.node++;
                    }
                } else if (tokens[BrightParser.node].TokenName==Tokens.Rparen) {
                    break;
                } else {
                    Console.WriteLine($"Parser: Error:\nLine {Line}: Expected token {tokens[BrightParser.node].TokenName}");
                    Environment.Exit(1);
                }
            }
            BrightParser.node++;
            return ap;
        } 
    }
}