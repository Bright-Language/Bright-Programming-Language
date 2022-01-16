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

            #region Logo

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

            #endregion

            #region LEXING

            WriteLine("\n==========LEXING==========\n");

            string code=@"
function levi(string quejo) {
    int b=6;
    if (1==1) {
        b=7;
    }
}";
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
                } catch {
                    break;
                }
            }

            tokens.Add(new Token(TokenParser.Tokens.EOF, "EOF"));
            foreach(Token token in tokens) {
                WriteLine(token.TokenName.ToString() + " - " + token.TokenValue);
            }

            #endregion

            #region PARSING

            WriteLine("\n==========PARSING==========\n");
            List<Node> AST=BrightParser.Parse(tokens);
            foreach(Node node in AST) {
                WriteLine($"TYPE: {node.Type}\nLEFT: {node.left}\nRIGHT: {node.right}\nVALUE: {node.value}\nLINE: {node.Line}");
                if (node.InnerNodes.Count>0) {
                    foreach (Node nod in node.InnerNodes) {
                        WriteLine($"\nInside Node {node.Type}");
                        WriteLine($"\nTYPE: {nod.Type}\nLEFT: {nod.left}\nRIGHT: {nod.right}\nVALUE: {nod.value}\nLINE: {nod.Line}");
                    }
                }
            }

            #endregion

            #region CODE GENERATOR

            /*WriteLine("\n==========CODE GENERATOR==========\n");
            CodeGenerator codegen;
            codegen=new CodeGenerator(AST);
            codegen.Generate();
            WriteLine("Done");
            WriteLine("\n==========LINKING EVERYTHING==========\n");
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/bin/bash", Arguments = "run.sh", }; 
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
            WriteLine("Done running (no messages, because only var works for now)");*/

            #endregion
		}

        #region Text Logo Function
        
        public static void TextLogo(ConsoleColor DefaultColour, ConsoleColor FontColour, ConsoleColor PlanetColour)
        {
            //Line 1
            Console.Write("\n█", Console.BackgroundColor = DefaultColour);
            //Line 2
            Console.Write("███", Console.BackgroundColor = FontColour);
            Console.Write("██████", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = PlanetColour);
            //Line 3
            Console.Write("\n█", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("█████████████", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("█████", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            //Line 4
            Console.Write("\n█", Console.BackgroundColor = DefaultColour);
            Console.Write("████", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("███", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("████", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("████", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("███", Console.BackgroundColor = FontColour);
            //Line 5
            Console.Write("\n█", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("██", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("███", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("██", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("██", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("██", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            //Line 6
            Console.Write("\n█", Console.BackgroundColor = DefaultColour);
            Console.Write("████", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("███", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("████", Console.BackgroundColor = FontColour);
            Console.Write("█", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("██", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            Console.Write("██", Console.BackgroundColor = DefaultColour);
            Console.Write("██", Console.BackgroundColor = FontColour);
            //Line 7
            Console.Write("\n███████████████", Console.BackgroundColor = DefaultColour);
            Console.Write("█", Console.BackgroundColor = FontColour);
            //Line 8
            Console.Write("\n████████████", Console.BackgroundColor = DefaultColour);
            Console.Write("███", Console.BackgroundColor = FontColour);
            //Line 9
            Console.Write("\n", Console.BackgroundColor = DefaultColour);
        }

        #endregion
	}
}
