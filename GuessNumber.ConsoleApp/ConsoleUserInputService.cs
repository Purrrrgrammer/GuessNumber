using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp;

internal sealed class ConsoleUserInputService : IUserInputService
{
    public bool TryGetUserNumberInput(out UserNumberInput userNumberInput)
    {
        var input = Console.ReadLine();
        userNumberInput = null;
        try
        {
            if (long.TryParse(input, out var result))
            {
                userNumberInput = new UserNumberInput(input, new Number(){ Value = result });
                return true;
            }
        }
        catch (Exception e)
        {
            return false;
        }
        
        return false;
    }

    public UserYesNoInput GetUserYesNoInput()
    {
        var input = Console.ReadLine();
        bool yes = input.Equals("y", StringComparison.OrdinalIgnoreCase);
        
        return new UserYesNoInput(input, yes);
    }
}