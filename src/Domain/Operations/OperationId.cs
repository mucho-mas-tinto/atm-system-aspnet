namespace AtmSystem.Domain.Operations;

public readonly record struct OperationId(long Value)
{
    public static readonly OperationId Default = new(default);
}