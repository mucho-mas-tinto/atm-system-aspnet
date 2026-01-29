using AtmSystem.Application.Contracts.Accounts.Models;
using AtmSystem.Domain.Accounts;

namespace AtmSystem.Application.Mapping;

public static class AccountMappingExtensions
{
    public static AccountDto MapToDto(this Account account)
        => new AccountDto(account.AccountId.Value, account.PinCode.Value, account.Balance.Value);
}