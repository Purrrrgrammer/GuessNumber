namespace GuessNumber.Core.Values;

public class UserInput
{
    public string UserInputString { get; init; }
    public UserInputType UserInputType { get; init; }

    public UserInput(string userInputString)
    {
        UserInputString = userInputString;

        if (userInputString == "y")
        {
            UserInputType = UserInputType.NewGame;
        }
        else
        {
            UserInputType = UserInputType.CloseGame;
        }
    }
}