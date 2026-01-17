namespace GuessNumber.Core.Values;

public class Number
{
    private long _guessNumber;
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Number)obj);
    }

    public override int GetHashCode()
    {
        return _guessNumber.GetHashCode();
    }

    public long Value
    {
        get => _guessNumber;
        init
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException($"{nameof(GuessNumber)} must be > 0");
            
            _guessNumber = value;
        }
    }
    
    public static bool operator ==(Number guessNumber1, Number guessNumber2)
    {
        return guessNumber1 == guessNumber2;
    }
    
    public static bool operator !=(Number guessNumber1, Number guessNumber2)
    {
        return guessNumber1 != guessNumber2;
    }   
    
    public static bool operator < (Number guessNumber1, Number guessNumber2)
    {
        return guessNumber1 < guessNumber2;
    }
    
    public static bool operator >(Number guessNumber1, Number guessNumber2)
    {
        return guessNumber1 > guessNumber2;
    }
    
    protected bool Equals(Number other)
    {
        return _guessNumber == other._guessNumber;
    }
}