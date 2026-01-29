using AtmSystem.Domain.ValueObjects;

namespace AtmSystem.Domain.Operations.Types;

public class DepositOperationType : IOperationType
{
    public OperationType Type { get; } = OperationType.Deposit;

    public bool CanOperate(Money balance, Money amount) => true;
}