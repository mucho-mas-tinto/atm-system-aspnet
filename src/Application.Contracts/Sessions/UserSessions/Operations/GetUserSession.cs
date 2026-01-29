namespace AtmSystem.Application.Contracts.Sessions.UserSessions.Operations;

public class GetUserSession
{
    public readonly record struct Request(long AccountId, string PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(Guid SessionId) : Response;

        public sealed record Failure(string Message) : Response;
    }
}