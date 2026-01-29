using AtmSystem.Application.Contracts.Sessions.AdminSessions.Operations;
using AtmSystem.Application.Contracts.Sessions.UserSessions.Operations;

namespace AtmSystem.Application.Contracts.Sessions;

public interface ISessionService
{
    GetAdminSession.Response GetAdminSession(GetAdminSession.Request request);

    GetUserSession.Response GetUserSession(GetUserSession.Request request);

    CreateAccount.Response CreateAccount(CreateAccount.Request request);
}