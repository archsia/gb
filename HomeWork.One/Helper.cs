using System;

namespace Gb.HomeWork.One
{
    public static class Helper
    {
        public static void PrintToCenter(string message)
        {
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
            Console.WriteLine(message);
        }
    }
}