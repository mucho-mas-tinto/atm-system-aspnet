using AtmSystem.Application.Abstractions.Persistence;
using AtmSystem.Application.Abstractions.Persistence.Queries;
using AtmSystem.Application.Contracts.Accounts;
using AtmSystem.Application.Contracts.Accounts.Operations;
using AtmSystem.Application.Contracts.Operations.Models;
using AtmSystem.Application.Mapping;
using AtmSystem.Domain.Accounts;
using AtmSystem.Domain.Operations;
using AtmSystem.Domain.Operations.Results;
using AtmSystem.Domain.Operations.Types;
using AtmSystem.Domain.Sessions;
using AtmSystem.Domain.ValueObjects;

namespace AtmSystem.Application.Services;

public class AccountService : IAccountService
{
    private readonly IPersistenceContext _context;

    public AccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public DepositMoney.Response DepositMoney(DepositMoney.Request request)
    {
        var sessionQuery = SessionQuery.Build(builder => builder.WithId(request.SessionId));
        ISession? session = _context.Sessions.Query(sessionQuery).SingleOrDefault();

        if (session is not UserSession userSession)
        {
            return new DepositMoney.Response.Failure("Session not found");
        }

        var accountQuery = AccountQuery.Build(builder => builder.WithId(userSession.AccountId.Value));
        Account? account = _context.Accounts.Query(accountQuery).SingleOrDefault();

        if (account is null)
        {
            return new DepositMoney.Response.Failure("Account not found");
        }

        account.Deposit(new Money(request.Amount));
        var operationInfo = new OperationInfo(DateTime.Now, new DepositOperationType(), new Money(request.Amount));
        Operation operation = new(new OperationId(default), account.AccountId, operationInfo);
        _context.Operations.Add(operation);

        return new DepositMoney.Response.Success(account.MapToDto());
    }

    public WithdrawMoney.Response WithdrawMoney(WithdrawMoney.Request request)
    {
        var sessionQuery = SessionQuery.Build(builder => builder.WithId(request.SessionId));
        ISession? session = _context.Sessions.Query(sessionQuery).SingleOrDefault();

        if (session is not UserSession userSession)
        {
            return new WithdrawMoney.Response.Failure("Session not found");
        }

        var accountQuery = AccountQuery.Build(builder => builder.WithId(userSession.AccountId.Value));
        Account? account = _context.Accounts.Query(accountQuery).SingleOrDefault();

        if (account is null)
        {
            return new WithdrawMoney.Response.Failure("Account not found");
        }

        if (account.Withdraw(new Money(request.Amount)) is OperationResult.Failure)
        {
            return new WithdrawMoney.Response.Failure("Insufficient balance");
        }

        var operationInfo = new OperationInfo(DateTime.Now, new WithdrawOperationType(), new Money(request.Amount));
        Operation operation = new(new OperationId(default), account.AccountId, operationInfo);
        _context.Operations.Add(operation);

        return new WithdrawMoney.Response.Success(account.MapToDto());
    }

    public CheckAccountBalance.Response CheckAccountBalance(CheckAccountBalance.Request request)
    {
        var sessionQuery = SessionQuery.Build(builder => builder.WithId(request.SessionId));
        ISession? session = _context.Sessions.Query(sessionQuery).SingleOrDefault();

        if (session is not UserSession userSession)
        {
            return new CheckAccountBalance.Response.Failure("Session not found");
        }

        var accountQuery = AccountQuery.Build(builder => builder.WithId(userSession.AccountId.Value));
        Account? account = _context.Accounts.Query(accountQuery).SingleOrDefault();

        if (account is null)
        {
            return new CheckAccountBalance.Response.Failure("Account not found");
        }

        account.CheckBalance();

        return new CheckAccountBalance.Response.Success(account.Balance.Value);
    }

    public GetOperationHistories.Response GetOperationHistories(GetOperationHistories.Request request)
    {
        var accountQuery = AccountQuery.Build(builder => builder.WithId(request.AccountId));
        Account? account = _context.Accounts.Query(accountQuery).SingleOrDefault();

        if (account is null)
        {
            return new GetOperationHistories.Response.Failure("Account not found");
        }

        var operationQuery = OperationQuery.Build(builder => builder.WithId(request.AccountId));
        IEnumerable<Operation>? operations = _context.Operations.Query(operationQuery);

        IEnumerable<OperationDto> operationDtos = operations.Select(operation => operation.MapToDto());
        return new GetOperationHistories.Response.Success(operationDtos);
    }
}