using System.Net.Mime;
using GuessNumber.Core.Repositories;
using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp;

public class GameController
{
    private readonly IGameService _gameService;
    private readonly IUserOutputService _userOutputService;
    private readonly IUserInputService _userInputService;

    public GameController(IGameService gameService, 
        IUserOutputService userOutputService,
        IUserInputService userInputService)
    {
        _gameService = gameService;
        _userOutputService = userOutputService;
        _userInputService = userInputService;
    }

    public void StartGame(GameSettings gameSettings)
    {
        while (true)
        {
            _gameService.StartNewGame(gameSettings);
            _userOutputService.Show("Хотите сыграть еще? y - да, другое - отказ");
            var input = _userInputService.GetUserYesNoInput();
            
            if(!input.Yes)
              break;  
        }
    }
}