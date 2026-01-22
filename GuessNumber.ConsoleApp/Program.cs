using System;
using GuessNumber.ConsoleApp.GameRepositories;
using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController(
                new InMemoryGameRepository(),
                new GenerateNumberService(),
                new ConsoleUserInputService());
            
            Console.WriteLine("GuessNumber Game");
            gameController.StartGame(new GameSettings(0, 100, 5));
        }
    }
}