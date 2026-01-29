using AtmSystem.Application.Abstractions.Persistence;
using AtmSystem.Application.Abstractions.Persistence.Queries;
using AtmSystem.Application.Abstractions.Persistence.Repositories;
using AtmSystem.Application.Contracts.Accounts.Operations;
using AtmSystem.Application.Services;
using AtmSystem.Domain.Accounts;
using AtmSystem.Domain.Sessions;
using AtmSystem.Domain.ValueObjects;
using Moq;
using Xunit;

namespace AtmSystem.Tests;

public class OperationTests
{
    [Fact]
    public void DepositMoney_DepositMoney_ShouldDeposit()
    {
        // Arrange
        var accountId = new AccountId(1);
        var userSession = UserSession.CreateNew(accountId);
        Guid sessionId = userSession.SessionId;

        var account = new Account(accountId, new("123456"));
        decimal initialBalance = account.Balance.Value;
        decimal depositedBalance = 10000;
        decimal newBalance = initialBalance + depositedBalance;

        var sessionRepositoryMock = new Mock<ISessionRepository>();
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var operationRepositoryMock = new Mock<IOperationRepository>();

        sessionRepositoryMock
            .Setup(repo => repo.Query(It.IsAny<SessionQuery>()))
            .Returns(new[] { userSession }.AsQueryable());

        accountRepositoryMock
            .Setup(repo => repo.Query(It.IsAny<AccountQuery>()))
            .Returns(new[] { account }.AsQueryable());

        var contextMock = new Mock<IPersistenceContext>();
        contextMock.Setup(c => c.Sessions).Returns(sessionRepositoryMock.Object);
        contextMock.Setup(c => c.Accounts).Returns(accountRepositoryMock.Object);
        contextMock.Setup(c => c.Operations).Returns(operationRepositoryMock.Object);

        var accountService = new AccountService(contextMock.Object);
        var request = new DepositMoney.Request(sessionId, depositedBalance);

        // Act
        DepositMoney.Response result = accountService.DepositMoney(request);

        // Assert
        Assert.IsType<DepositMoney.Response.Success>(result);
        Assert.Equal(newBalance, account.Balance.Value);
    }

    [Fact]
    public void WithdrawMoney_WithdrawMoney_ShouldWithdraw()
    {
        // Arrange
        var accountId = new AccountId(1);
        var userSession = UserSession.CreateNew(accountId);
        Guid sessionId = userSession.SessionId;

        var account = new Account(accountId, new("123456"), new Money(1000));
        decimal initialBalance = account.Balance.Value;
        decimal amount = 100;
        decimal newBalance = initialBalance - amount;

        var sessionRepositoryMock = new Mock<ISessionRepository>();
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var operationRepositoryMock = new Mock<IOperationRepository>();

        sessionRepositoryMock
            .Setup(repo => repo.Query(It.IsAny<SessionQuery>()))
            .Returns(new[] { userSession }.AsQueryable());

        accountRepositoryMock
            .Setup(repo => repo.Query(It.IsAny<AccountQuery>()))
            .Returns(new[] { account }.AsQueryable());

        var contextMock = new Mock<IPersistenceContext>();
        contextMock.Setup(c => c.Sessions).Returns(sessionRepositoryMock.Object);
        contextMock.Setup(c => c.Accounts).Returns(accountRepositoryMock.Object);
        contextMock.Setup(c => c.Operations).Returns(operationRepositoryMock.Object);

        var accountService = new AccountService(contextMock.Object);
        var request = new WithdrawMoney.Request(sessionId, amount);

        // Act
        WithdrawMoney.Response result = accountService.WithdrawMoney(request);

        // Assert
        Assert.IsType<WithdrawMoney.Response.Success>(result);
        Assert.Equal(newBalance, account.Balance.Value);
    }

    [Fact]
    public void WithdrawMoney_WithdrawMoney_MustNotWithdraw()
    {
        // Arrange
        var accountId = new AccountId(1);
        var userSession = UserSession.CreateNew(accountId);
        Guid sessionId = userSession.SessionId;

        var account = new Account(accountId, new("123456"), new Money(1000));

        var sessionRepositoryMock = new Mock<ISessionRepository>();
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var operationRepositoryMock = new Mock<IOperationRepository>();

        sessionRepositoryMock
            .Setup(repo => repo.Query(It.IsAny<SessionQuery>()))
            .Returns(new[] { userSession }.AsQueryable());

        accountRepositoryMock
            .Setup(repo => repo.Query(It.IsAny<AccountQuery>()))
            .Returns(new[] { account }.AsQueryable());

        var contextMock = new Mock<IPersistenceContext>();
        contextMock.Setup(c => c.Sessions).Returns(sessionRepositoryMock.Object);
        contextMock.Setup(c => c.Accounts).Returns(accountRepositoryMock.Object);
        contextMock.Setup(c => c.Operations).Returns(operationRepositoryMock.Object);

        var accountService = new AccountService(contextMock.Object);
        var request = new WithdrawMoney.Request(sessionId, 1000);

        // Act
        WithdrawMoney.Response result = accountService.WithdrawMoney(request);

        // Assert
        Assert.IsType<WithdrawMoney.Response.Failure>(result);
    }
}
