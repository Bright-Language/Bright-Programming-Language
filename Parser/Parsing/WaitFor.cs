using System;
using System.Collections.Generic;
using Bright.Lexer;
using static Bright.Lexer.TokenParser;

namespace Bright.Parser.Parsing {
    public static class WaitFor {
        public static bool WaitForToken(Tokens token, List<Tokens> InterruptTokens, List<Token> tokens, int Line) {
            while (tokens[BrightParser.node].TokenName!=token) {
                if (InterruptTokens.Contains(tokens[BrightParser.node].TokenName)) {
                    return false;
                } else if (tokens[BrightParser.node].TokenName==token) {
                    return true;
                } else if (tokens[BrightParser.node].TokenName==Tokens.Newline) {
                    BrightParser.Line++;
                    BrightParser.node++;
                } else {
                    BrightParser.node++;
                }
            }
            return false;
        }

        public static bool WaitForToken(Tokens[] token, List<Tokens> InterruptTokens, List<Token> tokens, int Line) {
            while (!token.Contains(tokens[BrightParser.node].TokenName)) {
                if (InterruptTokens.Contains(tokens[BrightParser.node].TokenName)) {
                    return false;
                } else if (token.Contains(tokens[BrightParser.node].TokenName)) {
                    return true;
                } else if (tokens[BrightParser.node].TokenName==Tokens.Newline) {
                    BrightParser.Line++;
                    BrightParser.node++;
                } else {
                    BrightParser.node++;
                }
            }
            return false;
        }

        public static bool HasToken(Tokens token, List<Tokens> InterruptTokens, List<Token> tokens) {
            int ind=BrightParser.node;
            while (tokens[ind].TokenName!=Tokens.EOF) {
                if (tokens[ind].TokenName==token) {
                    return true;
                } else if (InterruptTokens.Contains(tokens[ind].TokenName)) {
                    return false;
                } else {
                    ind++;
                }
            }
            return false;
        }
    }
}
