using Bright.Lexer;
using static Bright.Lexer.TokenParser;

namespace Bright.Parser.Parsing {
	public static class IntVar {
		public static Node Parse(List<Token> tokens) {
			BrightParser.node++;
			WaitFor.WaitForToken(Tokens.Identifier, InterruptTokens.VarDef, tokens, BrightParser.Line);
			string VarName=tokens[BrightParser.node].TokenValue;
			//
		}
	}
}
