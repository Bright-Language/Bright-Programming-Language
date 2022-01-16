using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class Function {
        public static object Parse(List<Token> tokens, int Line) {
            BrightParser.node++;//skip function
            string funcname=tokens[BrightParser.node].TokenValue;
            BrightParser.node++;//skip func name
            /*while (tokens[BrightParser.node].TokenName!=Tokens.OpenBrace) {
                BrightParser.node++;
            }
            List<Node> block=new List<Node>();
            block=Block.Parse(tokens, BrightParser.node, Line);
            return new Node(NodeTypes.FUNCTIONDEF) {
                InnerNodes=block,
                Index=BrightParser.node
            };*/
            List<Node> args=new List<Node>();
            #region get rid of new lines
            int nod=BrightParser.node;
            while (tokens[BrightParser.node].TokenName!=Tokens.Rparen) {
                if (tokens[BrightParser.node].TokenName==Tokens.EOF) {
                    Console.WriteLine($"Parser: Error:\nLine {Line}: Missing Right Paren!");
                    break;
                } else if (tokens[BrightParser.node].TokenName==Tokens.Rparen) {
                    break;
                } else {
                    if (tokens[BrightParser.node].TokenName==Tokens.Newline) {
                        tokens.RemoveAt(BrightParser.node);
                        nod--;
                    }
                }
                BrightParser.node++;
            }
            BrightParser.node=nod;
            #endregion
            #region get all params
            //Console.WriteLine(tokens[BrightParser.node].TokenName);
            while (tokens[BrightParser.node].TokenName!=Tokens.Rparen) {
                if (tokens[BrightParser.node].TokenName==Tokens.Lparen) {
                    BrightParser.node++;
                    if (tokens[BrightParser.node].TokenName==Tokens.Rparen) {
                        break;
                    } else {
                        if (tokens[BrightParser.node].TokenName==Tokens.StringType) {
                            BrightParser.node++;
                            if (tokens[BrightParser.node].TokenName==Tokens.Identifier) {
                                args.Add(new Node(NodeTypes.PARAM){left=Types.STRING,right=tokens[BrightParser.node].TokenValue});
                            } else {
                                Console.WriteLine($"Parser: Error:\nLine {Line}: Unexpected token {tokens[BrightParser.node].TokenValue}!");
                                Environment.Exit(1);
                            }
                        } else if (tokens[BrightParser.node].TokenName==Tokens.IntType) {
                            BrightParser.node++;
                            if (tokens[BrightParser.node].TokenName==Tokens.Identifier) {
                                args.Add(new Node(NodeTypes.PARAM){left=Types.INTEGER,right=tokens[BrightParser.node].TokenValue});
                            } else {
                                Console.WriteLine($"Parser: Error:\nLine {Line}: Unexpected token {tokens[BrightParser.node].TokenValue}!");
                                Environment.Exit(1);
                            }
                        } else {
                            Console.WriteLine($"Parser: Error:\nLine {Line}: Unexpected token {tokens[BrightParser.node].TokenValue}!");
                            Environment.Exit(1);
                        }
                    }
                } else {
                    Console.WriteLine($"Parser: Error:\nLine {Line}: Unexpected token {tokens[BrightParser.node].TokenValue}!");
                    Environment.Exit(1);
                }
                BrightParser.node++;
            }
            #endregion
            #region Block
            BrightParser.node++;
            List<Node> block=new List<Node>();
            if (tokens[BrightParser.node].TokenName==Tokens.OpenBrace) {
                block=Block.Parse(tokens, Line);
            } else {
                Console.WriteLine($"Parser: Error:\nLine {Line}: Unexpected token {tokens[BrightParser.node].TokenValue}!");
                Environment.Exit(1);
            }
            #endregion
            BrightParser.funcs.Add(funcname);
            Node Node=new Node(NodeTypes.FUNCTIONDEF){left=funcname,right=args,InnerNodes=block,Line=Line,Index=BrightParser.node};
            return Node;
        }
    }
}