using ProperTea.ServiceName.Domain.AggregateRootNames;
using ProperTea.Shared.Infrastructure.Persistence;

namespace ProperTea.ServiceName.Infrastructure.Persistence;

public class AggregateRootNameRepository(ServiceNameDbContext dbContext)
    : RepositoryBase<AggregateRootName, AggregateRootNameFilter>(dbContext), IAggregateRootNameRepository
{
    protected override IQueryable<AggregateRootName> ApplyFilter(IQueryable<AggregateRootName> query,
        AggregateRootNameFilter filter)
    {
        // TODO: implement filter
        return query;
    }
}