using AtmSystem.Application.Abstractions.Persistence.Queries;
using AtmSystem.Application.Abstractions.Persistence.Repositories;
using AtmSystem.Domain.Sessions;

namespace AtmSystem.Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly Dictionary<Guid, ISession> _values = [];

    public ISession Add(ISession session)
    {
        _values.Add(session.SessionId, session);
        return session;
    }

    public void Update(ISession session)
    {
        if (_values.ContainsKey(session.SessionId) is false)
            throw new InvalidOperationException("Session not found");

        _values[session.SessionId] = session;
    }

    public IEnumerable<ISession> Query(SessionQuery query)
    {
        return _values.Values
            .Where(x => query.Ids is [] || query.Ids.Contains(x.SessionId));
    }
}