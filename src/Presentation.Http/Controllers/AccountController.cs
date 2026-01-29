using AtmSystem.Application.Contracts.Accounts;
using AtmSystem.Application.Contracts.Accounts.Models;
using AtmSystem.Application.Contracts.Accounts.Operations;
using AtmSystem.Application.Contracts.Operations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AtmSystem.Presentation.Http.Controllers;

[ApiController]
[Route("/api/session/user/account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("check-balance")]
    public ActionResult<decimal> CheckAccountBalance(Guid sessionId)
    {
        var request = new CheckAccountBalance.Request(sessionId);
        CheckAccountBalance.Response response = _accountService.CheckAccountBalance(request);

        return response switch
        {
            CheckAccountBalance.Response.Success success => Ok(success.Amount),
            CheckAccountBalance.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("deposit")]
    public ActionResult<AccountDto> Deposit(Guid sessionId, decimal amount)
    {
        var request = new DepositMoney.Request(sessionId, amount);
        DepositMoney.Response response = _accountService.DepositMoney(request);

        return response switch
        {
            DepositMoney.Response.Success success => Ok(success.Account),
            DepositMoney.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withdraw")]
    public ActionResult<AccountDto> Withdraw(Guid sessionId, decimal amount)
    {
        var request = new WithdrawMoney.Request(sessionId, amount);
        WithdrawMoney.Response response = _accountService.WithdrawMoney(request);

        return response switch
        {
            WithdrawMoney.Response.Success success => Ok(success.Account),
            WithdrawMoney.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("get-operation-history")]
    public ActionResult<IEnumerable<OperationDto>> GetOperationHistory(long accountId)
    {
        var request = new GetOperationHistories.Request(accountId);
        GetOperationHistories.Response response = _accountService.GetOperationHistories(request);

        return response switch
        {
            GetOperationHistories.Response.Success success => Ok(success.Operations),
            GetOperationHistories.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}