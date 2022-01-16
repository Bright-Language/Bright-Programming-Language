using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class HasSemi {
        public static bool CheckSemi(List<Token> tokens) {
            return WaitFor.HasToken(Tokens.Semicolon, InterruptTokens.toks, tokens);
        }
    }
}