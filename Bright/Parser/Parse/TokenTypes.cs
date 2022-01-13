using Bright.Grammar;

namespace Bright.Parser.Parse {
    public enum TokenTypes {
        VARDEF=1
    }

    public static class InterruptTokens {
        public static List<TokenParser.Tokens> toks=new List<TokenParser.Tokens>() {
            TokenParser.Tokens.CloseBrace,
            TokenParser.Tokens.OpenBrace,
            TokenParser.Tokens.IntType,
            TokenParser.Tokens.Method,
            TokenParser.Tokens.Function,
            TokenParser.Tokens.EOF
        };
    }
}