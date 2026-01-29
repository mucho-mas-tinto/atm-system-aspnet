using AtmSystem.Application.Abstractions.Persistence;
using AtmSystem.Application.Abstractions.Persistence.Repositories;

namespace AtmSystem.Infrastructure.Persistence;

internal sealed class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(ISessionRepository sessions, IAccountRepository accounts, IOperationRepository operations)
    {
        Sessions = sessions;
        Accounts = accounts;
        Operations = operations;
    }

    public ISessionRepository Sessions { get; }

    public IAccountRepository Accounts { get; }

    public IOperationRepository Operations { get; }
}