using System;
using System.Collections.Generic;
using Bright.Grammar;
using static Bright.Grammar.TokenParser;

namespace Bright.Parser.Parse {
    public static class HasSemi {
        public static bool CheckSemi(Token[] tokens, int nodeIndex) {
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