using GuessNumber.Core.Services;

namespace GuessNumber.Core.States;

public class LostState(IUserOutputService userOutputService) : IGameState
{
    public void Handle(IGameService gameService)
    {
        var message = "Вы проиграли";
        userOutputService.Show(message);
        gameService.ChangeState(null);
    }
}