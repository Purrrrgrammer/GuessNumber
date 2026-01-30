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
            var gameController = CreateGameController();
            
            Console.WriteLine("GuessNumber Game");
            gameController.StartGame(new GameSettings(0, 100, 7));
        }

        private static GameController CreateGameController()
        {
            var inputService = new ConsoleUserInputService();
            var outputService = new ConsoleUserOutputService();
            var gameStateFactory = new GameStateFactory(new NumberValidator(), outputService, inputService);
            var repository = new InMemoryGameRepository(new GenerateNumberService());
            var gameService = new GameService(repository, gameStateFactory);
            return new GameController(gameService,  outputService, inputService);
        }
    }
}