namespace GuessNumber.Core.Values;

public sealed class UserNumberInput : UserInput
{
    public Number Number { get; init; }
    
    public UserNumberInput(string originalInput, Number number) : base(originalInput)
    {
        Number = number;
    }

}