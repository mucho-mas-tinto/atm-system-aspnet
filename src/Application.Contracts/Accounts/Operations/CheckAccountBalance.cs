namespace AtmSystem.Application.Contracts.Accounts.Operations;

public class CheckAccountBalance
{
    public readonly record struct Request(Guid SessionId);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(decimal Amount) : Response;

        public sealed record Failure(string Message) : Response;
    }
}