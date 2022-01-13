using Bright.Grammar;

namespace Bright.Parser.Parse {
    public enum TokenTypes {
        VARDEF=1
    }

    public enum Types {
        STRING=1,
        INTEGER=2,
        FLOAT=3
    }

    public static class InterruptTokens {
        public static List<TokenParser.Tokens> toks=new List<TokenParser.Tokens>() {
            TokenParser.Tokens.CloseBrace,
            TokenParser.Tokens.OpenBrace,
            //TokenParser.Tokens.IntType,
            //TokenParser.Tokens.Method,
            //TokenParser.Tokens.Function,
            TokenParser.Tokens.EOF
        };
    }
}