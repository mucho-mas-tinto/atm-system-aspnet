using AtmSystem.Application.Contracts.Operations.Models;
using AtmSystem.Domain.Operations;

namespace AtmSystem.Application.Mapping;

public static class OperationMappingExtension
{
    public static OperationDto MapToDto(this Operation operation)
        => new OperationDto(
            operation.OperationId.Value,
            operation.AccountId.Value,
            new OperationInfoDto(
                operation.OperationInfo.CreatedAt,
                operation.OperationInfo.OperationType.Type.MapToDto(),
                operation.OperationInfo.Amount.Value));
}