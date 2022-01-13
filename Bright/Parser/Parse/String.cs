namespace Bright.Parser.Parse {
    public static class String {
        public static string Parse(string str) {
            System.Text.StringBuilder sb=new System.Text.StringBuilder(str);
            sb[0]='\'';
            sb[sb.Length-1]='\'';
            return sb.ToString();
        }
    }
}