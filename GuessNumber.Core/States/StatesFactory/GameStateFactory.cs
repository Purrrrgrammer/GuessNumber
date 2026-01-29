using GuessNumber.Core.Services;

namespace GuessNumber.Core.States.StatesFactory;

public sealed class GameStateFactory(
    INumberValidator numberValidator,
    IUserOutputService userOutputService,
    IUserInputService userInputService)
    : IGameStateFactory
{
    public IGameState CreateWelcomeState()
    {
        return new WelcomeGameState(userOutputService, this);
    }

    public IGameState CreateAttemptState()
    {
        return new AttemptState(userInputService, userOutputService, numberValidator, this);
    }

    public IGameState CreateLostState()
    {
        return new LostState(userOutputService);
    }

    public IGameState CreateWonState()
    {
        return new WonState(userOutputService);
    }
}