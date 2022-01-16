using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class Identifier {
        public static object Parse(List<Token> tokens, int Line) {
            if (WaitFor.HasToken(Tokens.Equals, tokens)) {
                return VarMod.Parse(tokens, Line);
            } else if (WaitFor.HasToken(Tokens.Lparen, tokens)) {
                return FuncCall.Parse(tokens, Line);
            } else {
                Console.WriteLine($"Parser: Error:\nLine {Line}: Unexpected token");
                Environment.Exit(1);
                return null;
            }
        }
    }
}