using AtmSystem.Application.Abstractions.Persistence;
using AtmSystem.Application.Abstractions.Persistence.Repositories;
using AtmSystem.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AtmSystem.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        collection.AddSingleton<ISessionRepository, SessionRepository>();
        collection.AddSingleton<IAccountRepository, AccountRepository>();
        collection.AddSingleton<IOperationRepository, OperationRepository>();

        return collection;
    }
}
