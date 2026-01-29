namespace AtmSystem.Application.Contracts.Sessions.AdminSessions.Operations;

public class GetAdminSession
{
    public readonly record struct Request(string Password);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(Guid SessionId) : Response;

        public sealed record Failure(string Message) : Response;
    }
}