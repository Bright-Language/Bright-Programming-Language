namespace Bright.Utils {
    public static class Success {
        public static void print(string msg) {
            System.Console.ForegroundColor=System.ConsoleColor.Green;
            System.Console.WriteLine($"[Success]: {msg}");
            System.Console.ForegroundColor=System.ConsoleColor.White;
        }
    }
}