using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public sealed class NumberValidator : INumberValidator
{
    public bool IsValid(Number number, GameSettings gameSettings)
    {
        if (number.Value < 0 || !(number.Value >= gameSettings.FromNumber && number.Value <= gameSettings.ToNumber))
        {
            return false;
        }
        
        return true;
    }
}