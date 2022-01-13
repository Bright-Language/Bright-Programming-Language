using Bright.Grammar;
using Bright.CodeGen.Gens;
using Bright.Parser.Parse;
using System;

namespace Bright.CodeGen {
    public class CodeGenerator {

        List<Node> nodes;
        Dictionary<string, List<string>> code;
        Var vars;
        public CodeGenerator(List<Node> nodes) {
            this.nodes=nodes;
            this.code=new Dictionary<string, List<string>>();
            vars=new Var();
        }

        public void Generate() {
            vars.GenerateVars(nodes, code);
            code.Add("_start", new List<string>(){});
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