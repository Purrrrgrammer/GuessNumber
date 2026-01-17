using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public class GenerateNumberService : IGenerateNumber
{
    public Number GenerateNumber(long from, long to)
    {
        Random random = new Random();
        
        return new Number()
        {
            Value = random.NextInt64(from, to)
        };
    }
}