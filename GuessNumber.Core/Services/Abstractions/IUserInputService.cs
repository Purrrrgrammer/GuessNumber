using GuessNumber.Core.Values;

namespace GuessNumber.Core.Services;

public interface IUserInputService
{
    bool TryGetUserNumberInput(out NumberUserInput? userNumberInput);
    ConfirmationUserInput GetConfirmationUserInput();
}
