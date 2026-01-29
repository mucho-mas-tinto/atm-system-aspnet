using AtmSystem.Application.Contracts.Operations.Models;

namespace AtmSystem.Application.Contracts.Accounts.Operations;

public class GetOperationHistories
{
    public readonly record struct Request(long AccountId);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(IEnumerable<OperationDto> Operations) : Response;

        public sealed record Failure(string Message) : Response;
    }
}