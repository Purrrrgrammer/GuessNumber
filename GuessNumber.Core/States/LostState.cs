using GuessNumber.Core.Services;

namespace GuessNumber.Core.States;

public class LostState : IGameState
{
    public void Handle(IGameService gameService)
    {
        var userOutPutService = gameService.UserOutputService;
        var message = "Вы проиграли";
        userOutPutService.Show(message);
        gameService.ChangeState(null);
    }
}