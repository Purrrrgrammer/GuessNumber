using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.Core.States;

public class AttemptState : IGameState
{
    private static Dictionary<MoveResult, string> _messages = new Dictionary<MoveResult, string>()
    {
        { MoveResult.NumberGreater, "Загаданное число больше" },
        { MoveResult.NumberLess, "Загаданное число меньше" }
    };
        
    public void Handle(IGameService gameService)
    {
        var userOutPutService = gameService.UserOutputService;
        var game = gameService.CurrentGame;
        var gameSettings = game.GameSettings;
        var numberValidator = gameService.NumberValidator;
        
        if (!gameService.UserInputService.TryGetUserNumberInput(out UserNumberInput userInputNumber))
        {
            userOutPutService.Show("Неверно введено число");
            return;
        }

        if (!numberValidator.IsValid(userInputNumber.Number, gameSettings))
        {
            userOutPutService.Show(
                $"Вводимое число должно быть в диапазоне " +
                $"от {gameSettings.FromNumber} до {gameSettings.ToNumber}.");
            return;
        }
        
        var moveResult = game.Move(userInputNumber.Number);
        
        if (moveResult == MoveResult.NumberLess || moveResult == MoveResult.NumberGreater)
        {
            var resultText = _messages[moveResult];
            var message = $"{resultText}. Угадайте число от {gameSettings.FromNumber} до {gameSettings.ToNumber}. Осталось попыток: {game.TriesCount}\"";
            userOutPutService.Show(message);
            return;
        }

        if (moveResult == MoveResult.Loose)
        {
            IGameState lost = new LostState();
            gameService.ChangeState(lost);
        }

        if (moveResult == MoveResult.Win)
        {
            IGameState won = new WonState();
            gameService.ChangeState(won);
        }
    }
}