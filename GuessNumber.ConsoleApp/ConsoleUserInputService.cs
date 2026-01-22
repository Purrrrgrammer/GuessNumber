using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp;

internal sealed class ConsoleUserInputService : IUserInputService
{
    public UserInput GetUserInput()
    {
        var input = Console.ReadLine();
        
        return new UserInput(input);
    }
    
    public UserNumberInput GetUserInputNumber()
    {
        var input = Console.ReadLine();
        
        return new UserNumberInput(input);
    }
}