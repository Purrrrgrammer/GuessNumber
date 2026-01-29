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
    private static Dictionary<MoveResult, string> _messages = new Dictionary<MoveResult, string>()
    {
        { MoveResult.NumberGreater, "Загаданное число больше" },
        { MoveResult.NumberLess, "Загаданное число меньше" }
    };
        
    public void Handle(IGameService gameService)
    {
        var game = gameService.CurrentGame;
        var gameSettings = game.GameSettings;
        
        if (!userInputService.TryGetUserNumberInput(out UserNumberInput userInputNumber))
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
            var resultText = _messages[moveResult];
            var message = $"{resultText}. Угадайте число от {gameSettings.FromNumber} до {gameSettings.ToNumber}. Осталось попыток: {game.TriesCount}\"";
            userOutputService.Show(message);
            return;
        }

        if (moveResult == MoveResult.Loose)
        {
            IGameState lost = gameStateFactory.CreateLostState();
            gameService.ChangeState(lost);
        }

        if (moveResult == MoveResult.Win)
        {
            IGameState won = gameStateFactory.CreateWonState();
            gameService.ChangeState(won);
        }
    }
}