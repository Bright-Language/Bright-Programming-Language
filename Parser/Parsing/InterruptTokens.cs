using static Bright.Lexer.TokenParser;

namespace Bright.Parser.Parsing {
	public static class InterruptTokens {
		public static List<Tokens> VarDef=new List<Tokens>() {
			Tokens.Newline,
			Tokens.If,
			Tokens.Div,
			Tokens.EOF,
			Tokens.Mul,
			Tokens.Else,
			Tokens.EQEQ,
			Tokens.Plus,
			Tokens.Float,
			Tokens.Minus,
			Tokens.Equals,
			Tokens.Lparen,
			Tokens.Method,
			Tokens.Rparen,
			Tokens.String,
			Tokens.Integer,
			Tokens.IntType,
			Tokens.Function,
			Tokens.FloatType,
			Tokens.OpenBrace,
			Tokens.Semicolon,
			Tokens.UNDEFINED,
			Tokens.CloseBrace,
			Tokens.StringType
		};
	}
}
