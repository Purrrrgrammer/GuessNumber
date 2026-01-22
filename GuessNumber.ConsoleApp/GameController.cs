using System.Net.Mime;
using GuessNumber.Core.Repositories;
using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp;

public class GameController
{
    private IGameRepository _gameRepository;
    private IGenerateNumber _generateNumberService;
    private IUserInputService _userInputService;
    
    public GameController(IGameRepository gameRepository,
        IGenerateNumber generateNumberService, 
        IUserInputService userInputService)
    {
        _gameRepository = gameRepository;
        _generateNumberService = generateNumberService;
        _userInputService = userInputService;
    }

    public void StartGame(GameSettings gameSettings)
    {
        
        //TODO переделать на  конечный автомат
        var game = _gameRepository.AddNewGame(gameSettings, _generateNumberService);
        
        
        while (true)
        {
            Console.WriteLine($"Угадайте число от {gameSettings.FromNumber} до {gameSettings.ToNumber}. Осталось {game.TriesCount} попыток");
            var userInputNumber = _userInputService.GetUserInputNumber();

            switch (userInputNumber.UserInputType)
            {
                case UserInputType.WrongInput:
                    Console.WriteLine("Загаданное число должно быть целым, > 0 и находится в заданном диапазоне");
                    break;
                case UserInputType.Number:
                    var result = game.Move(userInputNumber.Number);

                    switch (result)
                    {
                        case MoveResult.NumberGreater:
                            Console.WriteLine("Загаданное число больше. Введите число:");
                            break;
                        case MoveResult.NumberLess:
                            Console.WriteLine("Загаданное число меньше. Введите число:");
                            break;
                        case MoveResult.Loose:
                            Console.WriteLine("Вы проиграли. Попробовать еще раз? y - начать новую игру, любая другая - закрыть игру");
                            if (_userInputService.GetUserInput().UserInputType == UserInputType.NewGame)
                                StartGame(gameSettings);
                            Environment.Exit(0);
                            break;
                        case MoveResult.Win:
                            Console.WriteLine("Вы выиграли. Попробовать еще раз? y - начать новую игру, любая другая - закрыть игру");
                            if (_userInputService.GetUserInput().UserInputType == UserInputType.NewGame)
                                StartGame(gameSettings);
                            Environment.Exit(0);
                            break;
                    }
                    break;
            }
        }
    }
    
}