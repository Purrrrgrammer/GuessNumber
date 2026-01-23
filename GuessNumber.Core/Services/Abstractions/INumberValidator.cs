using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public interface INumberValidator
{
    bool IsValid(Number number, GameSettings gameSettings);
}