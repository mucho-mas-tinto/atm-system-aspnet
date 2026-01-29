using AtmSystem.Domain.Accounts;

namespace AtmSystem.Domain.Sessions;

public class UserSession : ISession
{
    public Guid SessionId { get; }

    public AccountId AccountId { get; }

    private UserSession(AccountId accountId, Guid sessionId)
    {
        AccountId = accountId;
        SessionId = sessionId;
    }

    public static UserSession CreateNew(AccountId accountId)
    {
        return new UserSession(accountId, Guid.NewGuid());
    }
}