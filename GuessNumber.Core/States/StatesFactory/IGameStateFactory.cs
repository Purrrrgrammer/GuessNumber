namespace GuessNumber.Core.States.StatesFactory;

public interface IGameStateFactory
{
    IGameState CreateWelcomeState();
    IGameState CreateAttemptState();
    IGameState CreateLostState();
    IGameState CreateWonState();
}