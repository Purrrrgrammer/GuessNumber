using GuessNumber.Core.Services;

namespace GuessNumber.Core.States;

public class WonState(IUserOutputService userOutputService) : IGameState
{
    public void Handle(IGameService gameService)
    {
        userOutputService.Show("Вы выиграли");
        gameService.ChangeState(null);
    }
}