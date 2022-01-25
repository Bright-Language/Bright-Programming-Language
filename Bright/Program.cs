using static System.Console;
using System.IO;
using System.Collections.Generic;
using Bright.Lexer;
using Bright.Parser;
using Bright.Parser.Parsing;

namespace Bright
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor=System.ConsoleColor.White;
            List<Token> toks=BrightLexer.Lex(File.ReadAllText("Program.bri"));
            List<Node> AST=BrightParser.Parse(toks);
            foreach (Node node in AST) {
                try {
                    WriteLine($"====={node.Type}=====");
                    WriteLine($"     {node.Left}     ");
                    WriteLine($"     {node.Mid}      ");
                    WriteLine($"     {node.Right}    ");
                    WriteLine($"     {node.Value}    ");
                } catch {
                    continue;
                }
            }
            Utils._Exit.Exit(0);
        }
    }
}
