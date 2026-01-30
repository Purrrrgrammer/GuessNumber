namespace GuessNumber.Core.Values;

public abstract class UserInput(string? originalInput)
{
    public string? OriginalInput { get; init; } = originalInput;
}