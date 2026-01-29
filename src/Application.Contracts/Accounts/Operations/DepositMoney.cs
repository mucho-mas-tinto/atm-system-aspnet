using AtmSystem.Application.Contracts.Accounts.Models;

namespace AtmSystem.Application.Contracts.Accounts.Operations;

public class DepositMoney
{
    public readonly record struct Request(Guid SessionId, decimal Amount);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AccountDto Account) : Response;

        public sealed record Failure(string Message) : Response;
    }
}