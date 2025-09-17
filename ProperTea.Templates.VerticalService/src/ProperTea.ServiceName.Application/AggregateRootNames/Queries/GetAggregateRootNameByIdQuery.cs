using ProperTea.ProperCqrs;
using ProperTea.ServiceName.Application.AggregateRootNames.Models;
using ProperTea.ServiceName.Domain.AggregateRootNames;

namespace ProperTea.ServiceName.Application.AggregateRootNames.Queries;

public record GetAggregateRootNameByIdQuery(Guid Id) : IQuery;

public class GetAggregateRootNameByIdQueryHandler(IAggregateRootNameRepository repository)
    : IQueryHandler<GetAggregateRootNameByIdQuery, AggregateRootNameModel?>
{
    public async Task<AggregateRootNameModel?> HandleAsync(GetAggregateRootNameByIdQuery query,
        CancellationToken ct = default)
    {
        var entity = await repository.GetByIdAsync(query.Id, ct);
        return entity == null ? null : AggregateRootNameModel.FromEntity(entity);
    }
}