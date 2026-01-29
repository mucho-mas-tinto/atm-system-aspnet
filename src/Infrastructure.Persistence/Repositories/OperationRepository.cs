using AtmSystem.Application.Abstractions.Persistence.Queries;
using AtmSystem.Application.Abstractions.Persistence.Repositories;
using AtmSystem.Domain.Operations;

namespace AtmSystem.Infrastructure.Persistence.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly Dictionary<OperationId, Operation> _values = [];

    public Operation Add(Operation operation)
    {
        var newOperationId = new OperationId(_values.Count + 1);
        var newOperation = new Operation(newOperationId, operation.AccountId, operation.OperationInfo);

        _values.Add(
            newOperationId,
            newOperation);

        return operation;
    }

    public void Update(Operation operation)
    {
        if (_values.ContainsKey(operation.OperationId) is false)
            throw new InvalidOperationException("Account not found");

        _values[operation.OperationId] = operation;
    }

    public IEnumerable<Operation> Query(OperationQuery query)
    {
        return _values.Values
            .Where(x => query.Id.Equals(x.AccountId.Value));
    }
}