namespace AtmSystem.Application.Contracts.Operations.Models;

public record OperationDto(
    long OperationId,
    long AccountId,
    OperationInfoDto Info);