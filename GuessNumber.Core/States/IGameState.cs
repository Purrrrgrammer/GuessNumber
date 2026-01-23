using GuessNumber.Core.Services;

namespace GuessNumber.Core.States;

public interface IGameState
{
    void Handle(IGameService gameService);
}