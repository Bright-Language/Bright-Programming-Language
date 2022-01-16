namespace  Bright.Parser.Parse {
    public class VarType {
        public VarType(string name, Types Type) {
            this.Type=Type;
            this.name=name;
        }
        public Types Type {get;}
        public string name {get;set;}
    }
}