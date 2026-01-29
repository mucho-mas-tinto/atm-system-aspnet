namespace AtmSystem.Application.Contracts.Accounts.Models;

public record AccountDto(long AccountId, string PinCode, decimal Balance);