namespace GuessNumber.Core.Values;

public sealed class UserYesNoInput(string originalInput, bool yes) : UserInput(originalInput)
{
    public bool Yes { get; init; } = yes;
}