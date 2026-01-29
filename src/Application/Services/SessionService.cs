using AtmSystem.Application.Abstractions.Persistence;
using AtmSystem.Application.Abstractions.Persistence.Queries;
using AtmSystem.Application.Contracts.Sessions;
using AtmSystem.Application.Contracts.Sessions.AdminSessions.Operations;
using AtmSystem.Application.Contracts.Sessions.UserSessions.Operations;
using AtmSystem.Application.Mapping;
using AtmSystem.Domain.Accounts;
using AtmSystem.Domain.Accounts.PinCodes;
using AtmSystem.Domain.Sessions;

namespace AtmSystem.Application.Services;

public class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;
    private readonly string _adminPassword;

    public SessionService(IPersistenceContext context, string adminPassword)
    {
        _context = context;
        _adminPassword = adminPassword;
    }

    public GetAdminSession.Response GetAdminSession(GetAdminSession.Request request)
    {
        if (request.Password != _adminPassword)
        {
            return new GetAdminSession.Response.Failure("Passwords do not match");
        }

        var sessionId = Guid.NewGuid();
        ISession adminSession = new AdminSession(sessionId);

        _context.Sessions.Add(adminSession);

        return new GetAdminSession.Response.Success(sessionId);
    }

    public GetUserSession.Response GetUserSession(GetUserSession.Request request)
    {
        var accountId = new AccountId(request.AccountId);
        var accountQuery = AccountQuery.Build(builder => builder.WithId(accountId.Value));
        Account? account = _context.Accounts.Query(accountQuery).SingleOrDefault();

        if (account is null)
        {
            return new GetUserSession.Response.Failure("Account not found");
        }

        if (account.PinCode.Value != request.PinCode)
        {
            return new GetUserSession.Response.Failure("Pin code does not match");
        }

        var session = UserSession.CreateNew(accountId);
        _context.Sessions.Add(session);

        return new GetUserSession.Response.Success(session.SessionId);
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        var accountId = new AccountId(request.AccountId);
        var pinCode = new PinCode(request.PinCode);
        var accountQuery = AccountQuery.Build(builder => builder.WithId(accountId.Value));
        Account? account = _context.Accounts.Query(accountQuery).SingleOrDefault();

        if (account is not null)
        {
            return new CreateAccount.Response.Failure("Account exists");
        }

        account = new Account(accountId, pinCode);
        _context.Accounts.Add(account);

        return new CreateAccount.Response.Success(account.MapToDto());
    }
}