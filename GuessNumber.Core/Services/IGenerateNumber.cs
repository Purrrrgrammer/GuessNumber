using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public interface IGenerateNumber
{
    Number GenerateNumber(long from, long to);
}