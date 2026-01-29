using AtmSystem.Domain.ValueObjects;

namespace AtmSystem.Domain.Operations.Types;

public interface IOperationType
{
    OperationType Type { get; }

    bool CanOperate(Money balance, Money amount);
}