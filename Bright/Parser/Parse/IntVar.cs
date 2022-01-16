using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class IntVar {
        public static object Parse(List<Token> tokens, int Line) {
            if (HasSemi.CheckSemi(tokens)) {
                BrightParser.node++; //skip int
                string tokname=tokens[BrightParser.node].TokenValue;
                BrightParser.node++; //skip tokname
                BrightParser.node++; //skip equals
                string tokvalue="";
                while (tokens[BrightParser.node].TokenName!=Tokens.Semicolon) {
                    tokvalue+=tokens[BrightParser.node].TokenValue;
                    BrightParser.node++;
                }
                Node Node;
                BrightParser.vars.Add(tokname, VarType.INT);
                Node=new Node(NodeTypes.VARDEF){left=Types.INTEGER,right=tokname,value=tokvalue,Line=Line};
                return Node;
            } else {
                Console.WriteLine($"Parser: Error:\nLine {Line}: Missing Semicolon!");
                Environment.Exit(1);
            }
            return null;
        }
    }
}