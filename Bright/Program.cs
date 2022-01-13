using System;                                                  
using static System.Console;
using Bright.Grammar;
using Bright.Parser;
using Bright.Parser.Parse;

namespace Bright {
    public class Program {
        public static void Main() {
            string code=@"int variable=5;
int var2=10;";
            TokenParser lexer;
            lexer=new TokenParser();
            lexer.InputString=code;
            List<Token> tokens = new List<Token>();
            while (true) {
                try {
                    Token t=lexer.GetToken();
                    //&& t.TokenName.ToString()!="Newline"
                    if (t.TokenName.ToString()!="Whitespace" && t.TokenName.ToString() != "Undefined") {
                        tokens.Add(t);
                    }
                } catch (Exception ex) {
                    break;
                }
            }
            WriteLine("LEXING");
            tokens.Add(new Token(TokenParser.Tokens.EOF, "EOF"));
            foreach(Token token in tokens) {
                WriteLine(token.TokenName.ToString() + " - " + token.TokenValue);
            }
            WriteLine("PARSING");
            BrightParser Parser;
            Parser=new BrightParser();
            List<Node> AST=Parser.Parse(tokens.ToArray());
            foreach(Node node in AST) {
                WriteLine($"TYPE: {node.type}\nLEFT: {node.left}\nVALUE: {node.value}\nLINE: {node.line}");
            }
		}
	}
}
