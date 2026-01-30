using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.Core.Entities;

public class Game(long id, GameSettings gameSettings, Number targetNumber)
{
    public long Id { get; init; } = id;
    public GameSettings GameSettings { get; init; } = gameSettings;
    public int TriesCount { get; private set; } = gameSettings.TriesCount;

    public MoveResult Move(Number guessNumber)
    {
        TriesCount--;
        
        if (guessNumber == targetNumber)
        {
            return MoveResult.Win;
        }

        if (TriesCount == 0)
        {
            return MoveResult.Loose;
        }
        
        if (targetNumber > guessNumber)
        {
            return MoveResult.NumberGreater;
        }

        return MoveResult.NumberLess;
    }
}