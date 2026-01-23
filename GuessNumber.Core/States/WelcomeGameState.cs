
using GuessNumber.Core.Services;

namespace GuessNumber.Core.States;

public sealed class WelcomeGameState : IGameState
{
    public void Handle(IGameService gameService)
    {
        var userOutPutService = gameService.UserOutputService;
        var game = gameService.CurrentGame;
        var gameSettings = game.GameSettings;
        var message = $"Игра началась. Угадайте число от {gameSettings.FromNumber} до {gameSettings.ToNumber}. Осталось попыток: {game.TriesCount}\"";
        userOutPutService.Show(message);
        
        IGameState attemptState = new AttemptState();
        gameService.ChangeState(attemptState);
    }
}