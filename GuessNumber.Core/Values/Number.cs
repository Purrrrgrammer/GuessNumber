namespace GuessNumber.Core.Values;

public sealed class Number
{
    public long Value { get; }

    public Number(long value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(
                nameof(value), 
                value, 
                "Number must be non-negative");
        
        Value = value;
    }
    
    public static bool operator ==(Number? left, Number? right)
    {
        if (left is null) return right is null;
        if (right is null) return false;
        return left.Value == right.Value;
    }
    
    public static bool operator !=(Number? left, Number? right)
    {
        return !(left == right);
    }   
    
    public static bool operator < (Number left, Number right)
    {
        return left.Value < right.Value;
    }
    
    public static bool operator >(Number left, Number right)
    {
        return left.Value > right.Value;
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Number)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
    
    private bool Equals(Number other)
    {
        return Value == other.Value;
    }
}