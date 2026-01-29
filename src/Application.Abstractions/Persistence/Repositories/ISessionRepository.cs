using AtmSystem.Application.Abstractions.Persistence.Queries;
using AtmSystem.Domain.Sessions;

namespace AtmSystem.Application.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    ISession Add(ISession session);

    void Update(ISession session);

    IEnumerable<ISession> Query(SessionQuery query);
}