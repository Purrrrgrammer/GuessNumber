using System;
using GuessNumber.ConsoleApp.GameRepositories;
using GuessNumber.Core.Services;
using GuessNumber.Core.States.StatesFactory;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputService = new ConsoleUserInputService();
            var outputService = new ConsoleUserOutputService();
            var gameStateFactory = new GameStateFactory(new NumberValidator(), outputService, inputService);
            
            GameController gameController = new GameController(
                new GameService(
                    new InMemoryGameRepository(),
                    new GenerateNumberService(),
                    gameStateFactory), 
                outputService,
                inputService);
            
            Console.WriteLine("GuessNumber Game");
            gameController.StartGame(new GameSettings(0, 100, 5));
        }
    }
}