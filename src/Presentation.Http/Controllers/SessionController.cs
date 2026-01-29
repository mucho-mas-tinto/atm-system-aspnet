using AtmSystem.Application.Contracts.Accounts.Models;
using AtmSystem.Application.Contracts.Sessions;
using AtmSystem.Application.Contracts.Sessions.AdminSessions.Operations;
using AtmSystem.Application.Contracts.Sessions.UserSessions.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AtmSystem.Presentation.Http.Controllers;

[ApiController]
[Route("/api/session")]
public sealed class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("admin")]
    public ActionResult<Guid> GetAdminSession(string password)
    {
        var request = new GetAdminSession.Request(password);
        GetAdminSession.Response response = _sessionService.GetAdminSession(request);

        return response switch
        {
            GetAdminSession.Response.Success success => Ok(success.SessionId),
            GetAdminSession.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("admin/create-account")]
    public ActionResult<AccountDto> CreateAccount(long accountId, string pinCode)
    {
        var request = new CreateAccount.Request(accountId, pinCode);
        CreateAccount.Response response = _sessionService.CreateAccount(request);

        return response switch
        {
            CreateAccount.Response.Success success => Ok(success.Account),
            CreateAccount.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("user")]
    public ActionResult<Guid> GetUserSession(long accountId, string pinCode)
    {
        var request = new GetUserSession.Request(accountId, pinCode);
        GetUserSession.Response response = _sessionService.GetUserSession(request);

        return response switch
        {
            GetUserSession.Response.Success success => Ok(success.SessionId),
            GetUserSession.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}