using ProperTea.ServiceName.Domain.AggregateRootNames;

namespace ProperTea.ServiceName.Application.AggregateRootNames.Models;

public record class AggregateRootNameModel(
    Guid Id)
{
    public static AggregateRootNameModel FromEntity(AggregateRootName entity)
    {
        return new AggregateRootNameModel(
            entity.Id);
    }
}