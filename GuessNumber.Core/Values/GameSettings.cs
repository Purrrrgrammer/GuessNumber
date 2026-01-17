namespace GuessNumber.Core.Values;

public class GameSettings
{
    public long FromNumber { get; init; }
    public long ToNumber { get; init; }
    public int TriesCount { get; init; }

    public GameSettings(long fromNumber, long toNumber, int triesCount)
    {
        if (fromNumber < 0 || fromNumber >= toNumber)
        {
            throw new ArgumentException(
                $"{nameof(fromNumber)} must be > 0 and < {nameof(toNumber)}");
        }
        
        if (triesCount < 0)
        {
            throw new ArgumentException(
                $"{nameof(triesCount)} must be > 0");
        }
        
        FromNumber = fromNumber;
        ToNumber = toNumber;
        TriesCount = triesCount;
    }

    public override string ToString()
    {
        return $"game settings: numbers from {FromNumber} to {ToNumber}, tries count - {TriesCount}";
    }
}