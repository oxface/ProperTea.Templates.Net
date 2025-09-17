using ProperTea.Shared.Domain;

namespace ProperTea.ServiceName.Domain.AggregateRootNames;

public interface IAggregateRootNameRepository : IRepository<AggregateRootName, AggregateRootNameFilter>
{
}

public record AggregateRootNameFilter
{
}