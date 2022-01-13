using Bright.Parser.Parse;
using Bright.Grammar;

namespace Bright.CodeGen.Gens {
    public class Var {
        private List<string> afcode;

        private List<string> vars;

        public Var() {
            afcode=new List<string>();
            vars=new List<string>();
        }

        public void GenerateVars(List<Node> nodes, Dictionary<string, List<string>> code) {
            foreach (Node node in nodes) {
                if (node.type==TokenTypes.VARDEF) {
                    if ((Types)node.left==Types.STRING) {
                        afcode.Add($"{(string)node.right} db {(string)node.value},0xa");
                        vars.Add((string)node.right);
                    } else if ((Types)node.left==Types.INTEGER) {
                        afcode.Add($"{(string)node.right} dd {(string)node.value}");
                    }
                }
            }
            code.Add("",afcode);
        }
    }
}