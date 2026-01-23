using GuessNumber.Core.Services;

namespace GuessNumber.Core.States;

public class WonState : IGameState
{
    public void Handle(IGameService gameService)
    {
        var userOutPutService = gameService.UserOutputService;
        var message = "Вы выиграли";
        userOutPutService.Show(message);
        gameService.ChangeState(null);
    }
}