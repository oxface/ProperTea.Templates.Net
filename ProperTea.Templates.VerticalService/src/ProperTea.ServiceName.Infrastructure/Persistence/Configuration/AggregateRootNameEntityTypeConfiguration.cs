using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperTea.ServiceName.Domain.AggregateRootNames;

namespace ProperTea.ServiceName.Infrastructure.Persistence.Configuration;

public class AggregateRootNameEntityTypeConfiguration : IEntityTypeConfiguration<AggregateRootName>
{
    public void Configure(EntityTypeBuilder<AggregateRootName> builder)
    {
        // TODO: implement entity configuration
    }
}