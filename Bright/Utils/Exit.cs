namespace Bright.Utils {
    public static class _Exit {
        public static void Exit(int code) {
            System.Console.ForegroundColor=System.ConsoleColor.Gray;
            System.Environment.ExitCode=code;
            System.Environment.Exit(code);
        }
    }
}