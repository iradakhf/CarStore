﻿
namespace Core.Helpers
{
    public class ConsoleHelper
    {
        public static void WriteTextWithColor(ConsoleColor color,string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
            
        }
    }
}
