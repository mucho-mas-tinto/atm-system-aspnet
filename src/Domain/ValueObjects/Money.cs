namespace AtmSystem.Domain.ValueObjects;

public sealed record Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Value cannot be negative");

        Value = value;
    }

    public static Money operator -(Money left, Money right) => new(left.Value - right.Value);

    public static Money operator +(Money left, Money right) => new(left.Value + right.Value);

    public static bool operator >(Money left, long right) => left.Value > right;

    public static bool operator <(Money left, long right) => left.Value < right;
}