namespace AtmSystem.Domain.Sessions;

public interface ISession
{
    Guid SessionId { get; }
}