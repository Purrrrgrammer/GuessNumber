using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public class GenerateNumberService : IGenerateNumber
{
    private static readonly Random Random = new();
    
    public Number GenerateNumber(long from, long to)
    {
        if (from >= to)
        {
            throw new ArgumentException("from must be less than to");
        }
        
        return new Number(Random.NextInt64(from, to));
    }
}