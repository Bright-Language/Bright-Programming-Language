using System;
using System.Collections.Generic;
using Bright.Lexer;
using Bright.Parser;
using static Bright.Lexer.TokenParser;

namespace Bright.Utils {
    public static class WaitFor {
        public static bool WaitForToken(Tokens token, List<Token> tokens, bool ignorenewline, bool ignorecomments) {
            while (tokens[BrightParser.node].TokenName!=token) {
                if (tokens[BrightParser.node].TokenName==token) {
                    return true;
                } else if (tokens[BrightParser.node].TokenName==Tokens.Newline) {
                    if (ignorenewline) {
                        BrightParser.line++;
                        BrightParser.node++;
                    } else {
                        return false;
                    }
                } else if (tokens[BrightParser.node].TokenName==Tokens.Comment) {
                    if (ignorecomments) {
                        BrightParser.node++;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            }
            return false;
        }

        public static bool WaitForToken(List<Tokens> token,  List<Token> tokens, bool ignorenewline, bool ignorecomments) {
            while (!token.Contains(tokens[BrightParser.node].TokenName)) {
                if (token.Contains(tokens[BrightParser.node].TokenName)) {
                    return true;
                } else if (tokens[BrightParser.node].TokenName==Tokens.Newline) {
                    if (ignorenewline) {
                        BrightParser.line++;
                        BrightParser.node++;
                    } else {
                        return false;
                    }
                } else if (tokens[BrightParser.node].TokenName==Tokens.Comment) {
                    if (ignorecomments) {
                        BrightParser.node++;
                    } else {
                        return false;
                    }
                } else {
                    return false;
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