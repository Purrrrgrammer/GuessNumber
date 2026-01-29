
using GuessNumber.Core.Services;
using GuessNumber.Core.States.StatesFactory;

namespace GuessNumber.Core.States;

public sealed class WelcomeGameState(
    IUserOutputService userOutputService, 
    IGameStateFactory gameStateFactory) : IGameState
{
    public void Handle(IGameService gameService)
    {
        var game = gameService.CurrentGame;
        var gameSettings = game.GameSettings;
        var message = $"Игра началась. Угадайте число от {gameSettings.FromNumber} до {gameSettings.ToNumber}. Осталось попыток: {game.TriesCount}\"";
        userOutputService.Show(message);
        IGameState attemptState = gameStateFactory.CreateAttemptState();
        gameService.ChangeState(attemptState);
    }
}