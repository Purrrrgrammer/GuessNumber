using System.Runtime.CompilerServices;
using GuessNumber.Core.Services;
using GuessNumber.Core.States;
using GuessNumber.Core.Values;

public class Game
{
    public long Id { get; init; }
    public GameSettings GameSettings { get; init; }
    public Number GuessNumber { get; init; }
    public int TriesCount { get; private set; }

    public Game(long id, GameSettings gameSettings, IGenerateNumber generateNumberService)
    {
        Id = id;
        GameSettings = gameSettings;
        TriesCount = gameSettings.TriesCount;
        GuessNumber = generateNumberService.GenerateNumber(gameSettings.FromNumber, gameSettings.ToNumber);
    }

    public MoveResult Move(Number guessNumber)
    {
        TriesCount--;
        
        if (guessNumber == GuessNumber)
        {
            return MoveResult.Win;
        }

        if (TriesCount == 0)
        {
            return MoveResult.Loose;
        }
        
        if (GuessNumber > guessNumber)
        {
            return MoveResult.NumberGreater;
        }

        return MoveResult.NumberLess;
    }
}