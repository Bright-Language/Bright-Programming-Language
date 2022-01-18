using Bright.Parser.Parse;
using Bright.Grammar;
using System;

namespace Bright.CodeGen.Gens {
    public static class Vars {
        private static List<string> afcode=new List<string>();

        private static Dictionary<string, Var> vars=new Dictionary<string, Var>();

        private static int CI=0;
        private static int CS=0;

        public static void GenerateVars(List<Node> nodes) {
            foreach (Node node in nodes) {
                try {
                    if (node.Type==NodeTypes.VARDEF) {
                        if ((Types)node.left==Types.STRING) {
                            CS+=8;
                            vars.Add($"{(string)node.right}", new Var() {Loc=CS,type=VarTypes.STRING});
                            CodeGenerator.code.Add($".LC{CI}", new List<string>{$"db {(string)node.value}"});
                            afcode.Add($"mov QWORD [rbp-{CS}], {(string)node.value}");
                        } else if ((Types)node.left==Types.INTEGER) {
                            CS+=4;
                            vars.Add($"{(string)node.right}", new Var() {Loc=CS,type=VarTypes.INT});
                            afcode.Add($"mov DWORD [rbp-{CS}], {(string)node.value}");
                        }
                    }
                } catch {
                    continue;
                }
            }
            CodeGenerator.code["_start"].Add($"push rbp");
            CodeGenerator.code["_start"].Add($"mov rbp, rsp");
            CodeGenerator.code["_start"].Add($"sub rsp, {CS+8}");
            foreach (string code in afcode){
                CodeGenerator.code["_start"].Add(code);
            }
        }
    }
}