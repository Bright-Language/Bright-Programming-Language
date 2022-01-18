using Bright.Grammar;
using Bright.CodeGen.Gens;
using Bright.Parser.Parse;
using System;

namespace Bright.CodeGen {
    public static class CodeGenerator {

        public static List<Node> nodes=new List<Node>();
        public static Dictionary<string, List<string>> code=new Dictionary<string, List<string>>();

        public static void Generate(List<Node> nodes) {
            code.Add("_start", new List<string>(){});
            Vars.GenerateVars(nodes);
            code["_start"].Add("mov	eax,1");
            code["_start"].Add("int	0x80");
            string final="section .text\n\tglobal _start";
            foreach(KeyValuePair<string,List<string>> label in code) {
                if (label.Key=="") {
                    foreach(string poc in label.Value) {
                        final+=$"\n{poc}";
                    }
                } else {
                    final+=$"\n{label.Key}:";
                    foreach(string poc in label.Value) {
                        final+=$"\n\t{poc}";
                    }
                }
            }
            System.IO.File.WriteAllText("file.asm", final);
        }
    }
}