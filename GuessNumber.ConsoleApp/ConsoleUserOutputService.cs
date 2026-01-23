using GuessNumber.Core.Services;

namespace GuessNumber.ConsoleApp;

internal class ConsoleUserOutputService : IUserOutputService
{
    public void Show(string message)
    {
        Console.WriteLine(message);
    }
}