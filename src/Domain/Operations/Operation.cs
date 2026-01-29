using AtmSystem.Domain.Accounts;

namespace AtmSystem.Domain.Operations;

public class Operation
{
    public Operation(OperationId id, AccountId accountId, OperationInfo info)
    {
        OperationId = id;
        AccountId = accountId;
        OperationInfo = info;
    }

    public OperationId OperationId { get; }

    public AccountId AccountId { get; }

    public OperationInfo OperationInfo { get; }
}