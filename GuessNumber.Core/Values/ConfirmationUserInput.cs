namespace GuessNumber.Core.Values;

public sealed class ConfirmationUserInput(string? originalInput, bool isConfirmed) : UserInput(originalInput)
{
    public bool IsConfirmed { get; init; } = isConfirmed;
}