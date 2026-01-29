using AtmSystem.Application.Contracts.Operations.Models;
using AtmSystem.Domain.Operations.Types;

namespace AtmSystem.Application.Mapping;

public static class OperationTypeMappingExtension
{
    public static OperationTypeDto MapToDto(this OperationType operationType)
    {
        return operationType switch
        {
            OperationType.Deposit => OperationTypeDto.Deposit,
            OperationType.Withdraw => OperationTypeDto.Withdraw,
            _ => throw new AggregateException("Unsupported operation"),
        };
    }
}