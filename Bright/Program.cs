using System;                                                  
using static System.Console;
using Bright.Grammar;
using Bright.Parser;
using Bright.Parser.Parse;
using Bright.CodeGen;
using System.Diagnostics;

namespace Bright {
    public class Program {
        public static void Main() {
            string code=@"int variable=5;
string var2="+"\"compiler strings\";\n";
            TokenParser lexer;
            lexer=new TokenParser();
            lexer.InputString=code;
            List<Token> tokens = new List<Token>();
            while (true) {
                try {
                    Token t=lexer.GetToken();
                    if (t.TokenName.ToString()!="Whitespace" && t.TokenName.ToString() != "Undefined") {
                        tokens.Add(t);
                    }
                } catch (Exception ex) {
                    break;
                }
            }
            WriteLine("\n==========LEXING==========\n");
            tokens.Add(new Token(TokenParser.Tokens.EOF, "EOF"));
            foreach(Token token in tokens) {
                WriteLine(token.TokenName.ToString() + " - " + token.TokenValue);
            }
            WriteLine("\n==========PARSING==========\n");
            BrightParser Parser;
            Parser=new BrightParser();
            List<Node> AST=Parser.Parse(tokens.ToArray());
            foreach(Node node in AST) {
                WriteLine($"TYPE: {node.type}\nLEFT: {node.left}\nRIGHT: {node.right}\nVALUE: {node.value}\nLINE: {node.line}");
            }
            WriteLine("\n==========CODE GENERATOR==========\n");
            CodeGenerator codegen;
            codegen=new CodeGenerator(AST);
            codegen.Generate();
            WriteLine("Done");
            WriteLine("\n==========LINKING EVERYTHING==========\n");
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/bin/bash", Arguments = "run.sh", }; 
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
            WriteLine("Done running (no messages, because only var works for now)");
		}
	}
}
