using AtmSystem.Application.Abstractions.Persistence.Repositories;

namespace AtmSystem.Application.Abstractions.Persistence;

public interface IPersistenceContext
{
    ISessionRepository Sessions { get; }

    IAccountRepository Accounts { get; }

    IOperationRepository Operations { get; }
}
