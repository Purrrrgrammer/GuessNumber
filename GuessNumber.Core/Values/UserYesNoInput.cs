namespace GuessNumber.Core.Values;

public sealed class UserYesNoInput : UserInput
{
    public bool Yes { get; init; }
    
    public UserYesNoInput(string originalInput, bool yes) : base(originalInput)
    {
        Yes = yes;
    }

}