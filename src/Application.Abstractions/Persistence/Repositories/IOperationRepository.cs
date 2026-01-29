using AtmSystem.Application.Abstractions.Persistence.Queries;
using AtmSystem.Domain.Operations;

namespace AtmSystem.Application.Abstractions.Persistence.Repositories;

public interface IOperationRepository
{
    Operation Add(Operation operation);

    void Update(Operation operation);

    IEnumerable<Operation> Query(OperationQuery query);
}