using ProperTea.Shared.Domain;

namespace ProperTea.ServiceName.Domain.AggregateRootNames;

public interface IAggregateRootNameDomainService : IDomainService
{
}

public class AggregateRootNameDomainService(IAggregateRootNameRepository repository) : IAggregateRootNameDomainService
{
}