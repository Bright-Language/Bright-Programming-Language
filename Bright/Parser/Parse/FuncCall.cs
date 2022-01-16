using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class FuncCall {
        public static object Parse(List<Token> tokens, int Line) {
            string FuncName=tokens[BrightParser.node].TokenValue;
            BrightParser.node++;
            List<Node> nds=ArgsParams.Parse(tokens, Line);
            foreach (Node nd in nds) {
                Console.WriteLine($"VAL {(string)nd.right}");
            }
            //BrightParser.node=(nds.Count>=1 ? nds[nds.Count-1].Index : BrightParser.node+1);
            return new Node(NodeTypes.FUNCCALL){left=FuncName,InnerNodes=nds,Line=Line};
        }
    }
}