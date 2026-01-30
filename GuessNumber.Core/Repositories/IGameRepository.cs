using GuessNumber.Core.Entities;
using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.Core.Repositories;

public interface IGameRepository
{
    public Game GetGameById(long id);
    public Game AddNewGame(GameSettings gameSettings);
    public void DeleteGame(long id);
    public void SetTriesCount(long id, int triesCount);
}