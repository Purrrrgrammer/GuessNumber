using GuessNumber.Core.Entities;
using GuessNumber.Core.Repositories;
using GuessNumber.Core.States;
using GuessNumber.Core.States.StatesFactory;
using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public sealed class GameService(
    IGameRepository gameRepository,
    IGameStateFactory gameStateFactory)
    : IGameService
{
    public Game? CurrentGame { get; private set; }

    private IGameState? _gameState;

    public void ChangeState(IGameState? gameState)
    {
        _gameState = gameState;
    }
    
    public void StartNewGame(GameSettings gameSettings)
    {
        _gameState = gameStateFactory.CreateWelcomeState();
        CurrentGame = gameRepository.AddNewGame(gameSettings) ??
                      throw new InvalidOperationException("Failed to create game");
        
        while (_gameState != null)
        {
            _gameState.Handle(this);
        }
    }
}