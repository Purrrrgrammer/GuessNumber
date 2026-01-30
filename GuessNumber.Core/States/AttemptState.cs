using GuessNumber.Core.Entities;
using GuessNumber.Core.Services;
using GuessNumber.Core.States.StatesFactory;
using GuessNumber.Core.Values;

namespace GuessNumber.Core.States;

public class AttemptState(
    IUserInputService userInputService,
    IUserOutputService userOutputService,
    INumberValidator numberValidator,
    IGameStateFactory gameStateFactory) : IGameState
{
    private static readonly Dictionary<MoveResult, string> Messages = new()
    {
        { MoveResult.NumberGreater, "Загаданное число больше" },
        { MoveResult.NumberLess, "Загаданное число меньше" }
    };
        
    public void Handle(IGameService gameService)
    {
        var game = gameService.CurrentGame;

        if (game is null)
        {
            throw new InvalidOperationException("AttemptState requires initialized game");
        }
        
        var gameSettings = game.GameSettings;
        
        if (!userInputService.TryGetUserNumberInput(out var userInputNumber))
        {
            userOutputService.Show("Неверно введено число");
            return;
        }

        if (!numberValidator.IsValid(userInputNumber.Number, gameSettings))
        {
            userOutputService.Show(
                $"Вводимое число должно быть в диапазоне " +
                $"от {gameSettings.FromNumber} до {gameSettings.ToNumber}.");
            return;
        }
        
        var moveResult = game.Move(userInputNumber.Number);
        
        if (moveResult == MoveResult.NumberLess || moveResult == MoveResult.NumberGreater)
        {
            var resultText = Messages[moveResult];
            var message = $"{resultText}. " +
                          $"Угадайте число от {gameSettings.FromNumber} до {gameSettings.ToNumber}. " +
                          $"Осталось попыток: {game.TriesCount}\"";
            userOutputService.Show(message);
            return;
        }

        if (moveResult == MoveResult.Loose)
        {
            var lostState = gameStateFactory.CreateLostState();
            gameService.ChangeState(lostState);
        }

        if (moveResult == MoveResult.Win)
        {
            var wonState = gameStateFactory.CreateWonState();
            gameService.ChangeState(wonState);
        }
    }
}