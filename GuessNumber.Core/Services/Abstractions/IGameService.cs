using GuessNumber.Core.States;
using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public interface IGameService
{
    void StartNewGame(GameSettings gameSettings);
    //TODO: вынести в GameStateContext
    public Game CurrentGame { get;  }
    public IUserInputService UserInputService { get; init; } // TODO: вынести в конструктор 
    public IUserOutputService UserOutputService { get; init; } // TODO: вынести в конструктор 
    public INumberValidator NumberValidator { get; } // TODO: вынести в конструктор 
    void ChangeState(IGameState gameState);
   
}