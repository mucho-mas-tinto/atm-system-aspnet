namespace AtmSystem.Domain.Sessions;

public readonly record struct SessionId(long Value)
{
    public static readonly SessionId Default = new(default);
}