using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public interface IUserInputService
{
    UserInput GetUserInput();
    UserNumberInput GetUserInputNumber();
}
