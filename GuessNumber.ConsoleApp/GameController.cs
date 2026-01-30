using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp;

public class GameController(
    IGameService gameService,
    IUserOutputService userOutputService,
    IUserInputService userInputService)
{
    private const string PlayAgainMessage = "Хотите сыграть еще? y - да, другое - отказ";
    
    public void StartGame(GameSettings gameSettings)
    {
        while (true)
        {
            gameService.StartNewGame(gameSettings);
            userOutputService.Show(PlayAgainMessage);
            var input = userInputService.GetConfirmationUserInput();
            
            if(!input.IsConfirmed)
              break;  
        }
    }
}