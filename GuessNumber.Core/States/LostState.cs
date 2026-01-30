using GuessNumber.Core.Services;

namespace GuessNumber.Core.States;

public class LostState(IUserOutputService userOutputService) : IGameState
{
    public void Handle(IGameService gameService)
    {
        userOutputService.Show("Вы проиграли");
        gameService.ChangeState(null);
    }
}