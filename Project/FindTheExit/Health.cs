using System;
using System.Threading;

namespace FindTheExit
{
    public class HealthPrinter
{
    public static void PrintPlayerHealth(int health)
    {
        string healthString = $"Health: {health}";
    }

    public static string Health1 = @"
░█░█░█▀▀░█▀█░█░░░▀█▀░█░█░░░▀█░
░█▀█░█▀▀░█▀█░█░░░░█░░█▀█░░░░█░
░▀░▀░▀▀▀░▀░▀░▀▀▀░░▀░░▀░▀░░░▀▀▀
";
    public static string Health2 = @"
░█░█░█▀▀░█▀█░█░░░▀█▀░█░█░░░▀▀▄
░█▀█░█▀▀░█▀█░█░░░░█░░█▀█░░░▄▀░
░▀░▀░▀▀▀░▀░▀░▀▀▀░░▀░░▀░▀░░░▀▀▀
";
    public static string Health3 = @"
░█░█░█▀▀░█▀█░█░░░▀█▀░█░█░░░▀▀█
░█▀█░█▀▀░█▀█░█░░░░█░░█▀█░░░░▀▄
░▀░▀░▀▀▀░▀░▀░▀▀▀░░▀░░▀░▀░░░▀▀░
";
    public static string Health4 = @"
░█░█░█▀▀░█▀█░█░░░▀█▀░█░█░░░█░█
░█▀█░█▀▀░█▀█░█░░░░█░░█▀█░░░░▀█
░▀░▀░▀▀▀░▀░▀░▀▀▀░░▀░░▀░▀░░░░░▀
";
    public static string Health5 = @"
░█░█░█▀▀░█▀█░█░░░▀█▀░█░█░░░█▀▀
░█▀█░█▀▀░█▀█░█░░░░█░░█▀█░░░▀▀▄
░▀░▀░▀▀▀░▀░▀░▀▀▀░░▀░░▀░▀░░░▀▀░
";
}

}
