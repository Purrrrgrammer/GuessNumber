using System;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameSettings gameSettings = new GameSettings(0, 100, 3);
            Console.WriteLine(gameSettings.ToString());
        }
    }
}