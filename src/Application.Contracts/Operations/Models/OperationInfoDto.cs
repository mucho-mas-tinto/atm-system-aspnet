namespace AtmSystem.Application.Contracts.Operations.Models;

public record OperationInfoDto(
    DateTime CreatedAt,
    OperationTypeDto OperationType,
    decimal Amount);