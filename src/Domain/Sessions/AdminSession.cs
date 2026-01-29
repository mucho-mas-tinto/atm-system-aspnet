using AtmSystem.Domain.Accounts;
using AtmSystem.Domain.Accounts.PinCodes;

namespace AtmSystem.Domain.Sessions;

public class AdminSession : ISession
{
    public Guid SessionId { get; }

    public AdminSession(Guid sessionId)
    {
        SessionId = sessionId;
    }

    public Account CreateAccount(AccountId accountId, PinCode pinCode)
    {
        return new Account(accountId, pinCode);
    }
}