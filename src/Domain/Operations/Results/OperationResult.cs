using AtmSystem.Domain.Operations.Types;
using AtmSystem.Domain.ValueObjects;

namespace AtmSystem.Domain.Operations.Results;

public abstract record OperationResult
{
    public sealed record Success(OperationType OperationType, Money Amount) : OperationResult;

    public sealed record Failure(string Message) : OperationResult;
}