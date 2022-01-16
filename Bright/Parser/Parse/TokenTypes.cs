using Bright.Grammar;

namespace Bright.Parser.Parse {
    public enum NodeTypes {
        NULL=0,
        UNDEFINED=1,
        VARDEF=2,
        FUNCTIONDEF=3,
        METHODDEF=4,
        PARAM=5,
        ARG=6,
        STRING=7,
        INT=8,
        FLOAT=9,
        FUNCCALL=10,
        IFSTMT=11,
        VARMOD=12
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

        public static List<TokenParser.Tokens> ifm=new List<TokenParser.Tokens>() {
            TokenParser.Tokens.Method,
            TokenParser.Tokens.Function,
            TokenParser.Tokens.IntType,
            TokenParser.Tokens.StringType,
            TokenParser.Tokens.FloatType,
            TokenParser.Tokens.If,
            TokenParser.Tokens.Else,
            TokenParser.Tokens.Identifier,
            TokenParser.Tokens.Plus,
            TokenParser.Tokens.Minus,
            TokenParser.Tokens.Div,
            TokenParser.Tokens.Mul,
            TokenParser.Tokens.String,
            TokenParser.Tokens.Integer,
            TokenParser.Tokens.Float,
            TokenParser.Tokens.Lparen,
            TokenParser.Tokens.Rparen,
            TokenParser.Tokens.EQEQ,
            TokenParser.Tokens.Equals,
            TokenParser.Tokens.EOF
        };

        public static List<TokenParser.Tokens> argparam=new List<TokenParser.Tokens>() {
            TokenParser.Tokens.CloseBrace,
            TokenParser.Tokens.OpenBrace,
            TokenParser.Tokens.EOF
        };
    }
}