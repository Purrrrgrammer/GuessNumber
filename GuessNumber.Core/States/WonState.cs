using GuessNumber.Core.Services;

namespace GuessNumber.Core.States;

public class WonState(IUserOutputService userOutputService) : IGameState
{
    public void Handle(IGameService gameService)
    {
        var message = "Вы выиграли";
        userOutputService.Show(message);
        gameService.ChangeState(null);
    }
}