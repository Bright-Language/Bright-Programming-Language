namespace Bright.Utils {
    public static class Info {
        public static void print(string msg) {
            System.Console.ForegroundColor=System.ConsoleColor.Blue;
            System.Console.WriteLine($"[Info]: {msg}");
            System.Console.ForegroundColor=System.ConsoleColor.White;
        }
    }
}