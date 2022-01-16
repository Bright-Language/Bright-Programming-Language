using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;
using Bright.Parser.Parse;

namespace Bright.Parser {
    public static class BrightParser {

        public static int node=0;
        public static int Line=1;
        public static List<string> funcs=new List<string>();
        public static Dictionary<string, VarType> vars=new Dictionary<string, VarType>();

        public static List<Node> Parse(List<Token> tokens) {
            List<Node> AST=new List<Node>();
            Node cnode;
            while(node<tokens.Count) {
                if (tokens[node].TokenName==Tokens.Newline) {
                    Line++;
                    node++;
                } else {
                    cnode=(Node)Peek(node, tokens, Line);
                    AST.Add(cnode);
                    node++;
                }
            }
            return AST;
        }

        public static object Peek(int Index, List<Token> tokens, int Line) {
            switch (tokens[Index].TokenName) {
                case Tokens.IntType: return (Node)IntVar.Parse(tokens, Line);
                case Tokens.StringType: return (Node)StrVar.Parse(tokens, Line);
                case Tokens.FloatType: return (Node)FloatVar.Parse(tokens, Line);
                case Tokens.Function: return (Node)Function.Parse(tokens, Line);
                case Tokens.Identifier: return (Node)Identifier.Parse(tokens, Line);
                case Tokens.If: return (Node)IfStmt.Parse(tokens, Line);
                case Tokens.Newline: Line++; break;
                case Tokens.EOF: break;
                default: Console.WriteLine($"Parser: Error:\nLine: {Line}: Unexpected token {tokens[Index].TokenName} - {tokens[Index].TokenValue}"); Environment.Exit(1); break;
            }
            return null;
        }
    }
}