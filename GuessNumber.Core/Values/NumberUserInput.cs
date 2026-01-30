namespace GuessNumber.Core.Values;

public sealed class NumberUserInput(string? originalInput, Number number) : UserInput(originalInput)
{
    public Number Number { get; init; } = number;
}