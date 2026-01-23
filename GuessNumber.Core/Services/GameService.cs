using GuessNumber.Core.Repositories;
using GuessNumber.Core.States;
using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public sealed class GameService : IGameService
{
    public Game CurrentGame { get; private set; }
    public IUserInputService UserInputService { get; init; }
    public IUserOutputService UserOutputService { get; init; }
    public INumberValidator NumberValidator { get; private set; }
    private readonly IGameRepository _gameRepository;
    private readonly IGenerateNumber _generateNumberService;
    private IGameState _gameState;
    
    public GameService(IGameRepository gameRepository,
        IGenerateNumber generateNumberService,
        IUserInputService userInputService,
        IUserOutputService userOutputService, 
        INumberValidator numberValidator)
    {
        _gameRepository = gameRepository;
        _generateNumberService = generateNumberService;
        UserInputService = userInputService;
        UserOutputService = userOutputService;
        NumberValidator = numberValidator;
    }

    public void ChangeState(IGameState gameState)
    {
        _gameState = gameState;
    }
    
    public void StartNewGame(GameSettings gameSettings)
    {
        _gameState = new WelcomeGameState();
        CurrentGame = _gameRepository.AddNewGame(gameSettings, _generateNumberService);
        
        while (_gameState != null)
        {
            _gameState.Handle(this);
        }
    }
}