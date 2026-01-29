using AtmSystem.Domain.ValueObjects;

namespace AtmSystem.Domain.Operations.Types;

public class WithdrawOperationType : IOperationType
{
    public OperationType Type { get; } = OperationType.Withdraw;

    public bool CanOperate(Money balance, Money amount) => (balance - amount) > 0;
}