using SourceKit.Generators.Builder.Annotations;

namespace AtmSystem.Application.Abstractions.Persistence.Queries;

[GenerateBuilder]
public partial record OperationQuery(long Id);