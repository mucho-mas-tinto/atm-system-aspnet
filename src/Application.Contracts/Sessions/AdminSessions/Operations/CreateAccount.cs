using AtmSystem.Application.Contracts.Accounts.Models;

namespace AtmSystem.Application.Contracts.Sessions.AdminSessions.Operations;

public class CreateAccount
{
    public readonly record struct Request(long AccountId, string PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AccountDto Account) : Response;

        public sealed record Failure(string Message) : Response;
    }
}