namespace Bright.CodeGen.Gens {
    public struct Var {
        public int Loc;
        public VarTypes type;
    }
    public enum VarTypes {
        STRING=1,
        INT=2
    }
}