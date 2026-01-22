namespace GuessNumber.Core.Values;

public sealed class UserNumberInput : UserInput
{
    public Number Number { get; init; }
    
    public UserNumberInput(string userInputString) : base(userInputString)
    {
        try
        {
            Number = new Number() { Value = long.Parse(userInputString) };
            UserInputType = UserInputType.Number;
        }
        catch (Exception e)
        {
            
            UserInputType = UserInputType.WrongInput;
        }
    }
}