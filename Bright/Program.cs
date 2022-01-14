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


            //Main section
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


            //Logo section

            //Get background colour
            ConsoleColor DefaultColour = new ConsoleColor();
            DefaultColour = Console.BackgroundColor;
            //Get colour pallete
            ConsoleColor FontColour = new ConsoleColor();
            FontColour = ConsoleColor.Yellow;
            ConsoleColor PlanetColour = new ConsoleColor();
            PlanetColour = ConsoleColor.Red;
            //Print fancy logo
            TextLogo(DefaultColour, FontColour, PlanetColour);
            //Fancy logo finished yay!


            //Lexing section

            WriteLine("\n==========LEXING==========\n");
            tokens.Add(new Token(TokenParser.Tokens.EOF, "EOF"));
            foreach(Token token in tokens) {
                WriteLine(token.TokenName.ToString() + " - " + token.TokenValue);
            }


            //Parsing section

            WriteLine("\n==========PARSING==========\n");
            BrightParser Parser;
            Parser=new BrightParser();
            List<Node> AST=Parser.Parse(tokens.ToArray());
            foreach(Node node in AST) {
                WriteLine($"TYPE: {node.type}\nLEFT: {node.left}\nRIGHT: {node.right}\nVALUE: {node.value}\nLINE: {node.line}");
            }


            //Code gen section

            WriteLine("\n==========CODE GENERATOR==========\n");
            CodeGenerator codegen;
            codegen=new CodeGenerator(AST);
            codegen.Generate();
            WriteLine("Done");


            //Linking section

            WriteLine("\n==========LINKING EVERYTHING==========\n");
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/bin/bash", Arguments = "run.sh", }; 
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
            WriteLine("Done running (no messages, because only var works for now)");
		}

        public static void TextLogo(ConsoleColor DefaultColour, ConsoleColor FontColour, ConsoleColor PlanetColour)
        {
            //Line 1
            Console.Write("\n ", Console.BackgroundColor = DefaultColour);
            //Line 2
            Console.Write("   ", Console.BackgroundColor = FontColour);
            Console.Write("      ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = PlanetColour);
            //Line 3
            Console.Write("\n ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write("             ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write("     ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            //Line 4
            Console.Write("\n ", Console.BackgroundColor = DefaultColour);
            Console.Write("    ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write("   ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write("    ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write("    ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write("   ", Console.BackgroundColor = FontColour);
            //Line 5
            Console.Write("\n ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write("  ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write("   ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write("  ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write("  ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write("  ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            //Line 6
            Console.Write("\n ", Console.BackgroundColor = DefaultColour);
            Console.Write("    ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write("   ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write("    ", Console.BackgroundColor = FontColour);
            Console.Write(" ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write("  ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            Console.Write("  ", Console.BackgroundColor = DefaultColour);
            Console.Write("  ", Console.BackgroundColor = FontColour);
            //Line 7
            Console.Write("\n               ", Console.BackgroundColor = DefaultColour);
            Console.Write(" ", Console.BackgroundColor = FontColour);
            //Line 8
            Console.Write("\n            ", Console.BackgroundColor = DefaultColour);
            Console.Write("   ", Console.BackgroundColor = FontColour);
            //Line 9
            Console.Write("\n", Console.BackgroundColor = DefaultColour);
        }
	}
}
