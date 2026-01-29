namespace GuessNumber.Core.Values;

public sealed class UserNumberInput(string originalInput, Number number) : UserInput(originalInput)
{
    public Number Number { get; init; } = number;
}