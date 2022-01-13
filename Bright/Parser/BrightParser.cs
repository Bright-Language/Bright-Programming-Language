using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser {
    public class BrightParser {

        public struct node {
            public TokenTypes type;
            public string value;
            public string right;
            public string left;
            public int line;
        }

        public enum TokenTypes {
            VARDEF=1
        }

        List<node> AST;

        int Line=1;

        public BrightParser() {
            AST=new List<node>();
        }

        public List<node> Parse(Token[] tokens) {
            for (int node=0;node<tokens.Length;node++) {
                switch (tokens[node].TokenName) {
                    case Tokens.IntType:
                        if (HasSemi(tokens, node)) {
                            node++; //skip int
                            string tokname=tokens[node].TokenValue;
                            node++; //skip token name
                            node++; //skip equals
                            string tokvalue="";
                            while (tokens[node].TokenName!=Tokens.Semicolon) {
                                tokvalue+=tokens[node].TokenValue;
                                node++;
                            }
                            node Node;
                            Node=new node() {
                                type=TokenTypes.VARDEF,
                                left=tokname,
                                value=tokvalue,
                                line=this.Line
                            };
                            AST.Add(Node);
                        } else {
                            Console.WriteLine($"Parser: Error:\nLine {Line}: Missing Semicolon!");
                            break;
                        }
                        break;
                    case Tokens.Newline:
                        Line++;
                        break;
                }
            }
            return AST;
        }

        public bool HasSemi(Token[] tokens, int nodeIndex) {
            int ind=nodeIndex;
            while (tokens[ind].TokenName!=Tokens.EOF) {
                if (tokens[ind].TokenName==Tokens.Semicolon) {
                    return true;
                } else if (tokens[ind].TokenName==Tokens.CloseBrace || tokens[ind].TokenName==Tokens.OpenBrace || tokens[ind].TokenName==Tokens.EOF) {
                    return false;
                } else {
                    ind++;
                }
            }
            return false;
        }
    }
}
