using AtmSystem.Domain.Operations.Types;
using AtmSystem.Domain.ValueObjects;

namespace AtmSystem.Domain.Operations;

public class OperationInfo
{
    public DateTime CreatedAt { get; }

    public IOperationType OperationType { get; }

    public Money Amount { get; }

    public OperationInfo(DateTime createdAt, IOperationType operationType, Money amount)
    {
        OperationType = operationType;
        CreatedAt = createdAt;
        Amount = amount;
    }
}