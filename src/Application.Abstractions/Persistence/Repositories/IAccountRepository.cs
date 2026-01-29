using AtmSystem.Application.Abstractions.Persistence.Queries;
using AtmSystem.Domain.Accounts;

namespace AtmSystem.Application.Abstractions.Persistence.Repositories;

public interface IAccountRepository
{
    Account Add(Account account);

    void Update(Account account);

    IEnumerable<Account> Query(AccountQuery query);
}