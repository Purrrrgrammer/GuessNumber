namespace GuessNumber.Core.Values;

public abstract class UserInput
{
    public string OriginalInput { get; init; }
    
    protected UserInput(string originalInput)
    {
        OriginalInput = originalInput;
    }
}