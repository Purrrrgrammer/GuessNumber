using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp;

internal sealed class ConsoleUserInputService : IUserInputService
{
    public bool TryGetUserNumberInput(out NumberUserInput? userNumberInput)
    {
        userNumberInput = null;
        
        try
        {
            var input = Console.ReadLine();

            if (long.TryParse(input, out var result))
            {
                userNumberInput = new NumberUserInput(input, new Number(result));
                return true;
            }
        }
        catch
        {
            return false;
        }
        
        return false;
    }

    public ConfirmationUserInput GetConfirmationUserInput()
    {
        try
        {
            var input = Console.ReadLine();
            var yes = !string.IsNullOrEmpty(input) && input.Equals("y", StringComparison.OrdinalIgnoreCase);
        
            return new ConfirmationUserInput(input, yes);
        }
        catch
        {
            return new ConfirmationUserInput(null, false);
        }
    }
}