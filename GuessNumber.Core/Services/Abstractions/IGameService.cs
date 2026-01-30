using GuessNumber.Core.Entities;
using GuessNumber.Core.States;
using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public interface IGameService
{
    void StartNewGame(GameSettings gameSettings);
    public Game? CurrentGame { get;  }
    void ChangeState(IGameState? gameState);
   
}