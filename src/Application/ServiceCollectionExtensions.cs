using AtmSystem.Application.Abstractions.Persistence;
using AtmSystem.Application.Contracts.Accounts;
using AtmSystem.Application.Contracts.Sessions;
using AtmSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AtmSystem.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ISessionService, SessionService>(provider =>
        {
            IPersistenceContext context = provider.GetRequiredService<IPersistenceContext>();
            return new SessionService(context, "12345678910");
        });
        collection.AddScoped<IAccountService, AccountService>();

        return collection;
    }
}
