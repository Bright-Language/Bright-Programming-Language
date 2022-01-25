using Bright.Lexer;
using static Bright.Lexer.TokenParser;
using System.Collections.Generic;
using Bright.Utils;

namespace Bright.Parser.Parsing {
    public static class StrDef {
        public static Node Parse(List<Token> tokens) {
            BrightParser.node++;
            WaitFor.WaitForToken(Tokens.Identifier, tokens, true, true);
            string VarName=tokens[BrightParser.node].TokenValue;
            BrightParser.node++;
            WaitFor.WaitForToken(Tokens.Equals, tokens, false, true);
            BrightParser.node++;
            WaitFor.WaitForToken(Tokens.String, tokens, false, true);
            string VarValue=tokens[BrightParser.node].TokenValue;
            WaitFor.WaitForToken(Tokens.Semicolon, tokens, false, true);
            return new Node(NodeType.vardef) { Left=VarType.str, Right=VarName, Value=VarValue };
        } 
    }
}