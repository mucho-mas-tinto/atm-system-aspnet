using AtmSystem.Application.Abstractions.Persistence.Queries;
using AtmSystem.Application.Abstractions.Persistence.Repositories;
using AtmSystem.Domain.Accounts;

namespace AtmSystem.Infrastructure.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountId, Account> _values = [];

    public Account Add(Account account)
    {
        if (_values.ContainsKey(account.AccountId) is true)
        {
            throw new ArgumentException("Account already exists");
        }

        account = new Account(
            account.AccountId,
            account.PinCode,
            account.Balance);

        _values.Add(account.AccountId, account);

        return account;
    }

    public void Update(Account account)
    {
        if (_values.ContainsKey(account.AccountId) is false)
            throw new InvalidOperationException("Account not found");

        _values[account.AccountId] = account;
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        return _values.Values
            .Where(x => query.Ids.Length == 0 || query.Ids.Contains(x.AccountId.Value));
    }
}