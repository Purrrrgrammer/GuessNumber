using GuessNumber.Core.Enities;
using GuessNumber.Core.Repositories;
using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp.GameRepositories;

public class InMemoryGameRepository : IGameRepository
{
    private Dictionary<long, Game> _games = new Dictionary<long, Game>();

    public Game GetGameById(long id)
    {
        if(_games.TryGetValue(id, out Game game))
        {
            return game;
        }
        
        throw new KeyNotFoundException($"User with ID {id} not found");
    }

    public Game AddNewGame(GameSettings gameSettings, IGenerateNumber generateNumberService)
    {
        var newGame = new Game(_games.Count + 1, gameSettings, generateNumberService);
        _games.Add(newGame.Id, newGame);
        
        return newGame;
    }

    public void DeleteGame(long id)
    {
        if (!_games.ContainsKey(id))
            throw new KeyNotFoundException($"User with ID {id} not found");

        _games.Remove(id);
    }

    public void SetTriesCount(long id, int triesCount)
    {
        if (!_games.ContainsKey(id))
            throw new KeyNotFoundException($"User with ID {id} not found");

        //_games[id].TriesCount = triesCount;
    }
}