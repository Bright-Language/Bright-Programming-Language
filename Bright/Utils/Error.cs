namespace Bright.Utils {
    public static class Error {
        public static void print(string msg) {
            System.Console.ForegroundColor=System.ConsoleColor.Red;
            System.Console.WriteLine($"[Error]: {msg}");
            System.Console.ForegroundColor=System.ConsoleColor.White;
        }
    }
}