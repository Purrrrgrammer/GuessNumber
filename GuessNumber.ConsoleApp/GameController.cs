using System.Net.Mime;
using GuessNumber.Core.Repositories;
using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp;

public class GameController(
    IGameService gameService,
    IUserOutputService userOutputService,
    IUserInputService userInputService)
{
    public void StartGame(GameSettings gameSettings)
    {
        while (true)
        {
            gameService.StartNewGame(gameSettings);
            userOutputService.Show("Хотите сыграть еще? y - да, другое - отказ");
            var input = userInputService.GetUserYesNoInput();
            
            if(!input.Yes)
              break;  
        }
    }
}