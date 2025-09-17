namespace ProperTea.ServiceName.Api.Endpoints.AggregateRootNames;

public static class AggregateRootNameEndpoints
{
    public static void MapAggregateRootNameEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/aggregate-root-names")
            //.WithTags("tags")
            ;

        CreateAggregateRootNameEndpoint.Map(app);
    }
}