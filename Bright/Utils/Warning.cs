namespace Bright.Utils {
    public static class Warning {
        public static void print(string msg) {
            System.Console.ForegroundColor=System.ConsoleColor.Yellow;
            System.Console.WriteLine($"[Warning]: {msg}");
            System.Console.ForegroundColor=System.ConsoleColor.White;
        }
    }
}