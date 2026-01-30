using GuessNumber.Core.Entities;
using GuessNumber.Core.Repositories;
using GuessNumber.Core.Services;
using GuessNumber.Core.Values;

namespace GuessNumber.ConsoleApp.GameRepositories;

public class InMemoryGameRepository(IGenerateNumber numberGenerator) : IGameRepository
{
    private readonly Dictionary<long, Game> _games = new();
    private long _nextId = 1;
    
    public Game GetGameById(long id)
    {
        return _games.TryGetValue(id, out var game) 
            ? game 
            : throw new KeyNotFoundException($"Game with ID {id} not found");
    }

    public Game AddNewGame(GameSettings gameSettings)
    {
        var id = _nextId++;
        var newGame = new Game(
            id, 
            gameSettings, 
            numberGenerator.GenerateNumber(gameSettings.FromNumber, gameSettings.ToNumber));
        _games.Add(newGame.Id, newGame);
        
        return newGame;
    }

    public void DeleteGame(long id)
    {
        if (!_games.Remove(id))
            throw new KeyNotFoundException($"Game with ID {id} not found");
    }

    public void SetTriesCount(long id, int triesCount)
    {
        if (!_games.ContainsKey(id))
            throw new KeyNotFoundException($"Game with ID {id} not found");
        
        // Заглушка для будущей реализации с БД
        // В InMemory-репозитории не нужно сохранять попытки,
    }
}