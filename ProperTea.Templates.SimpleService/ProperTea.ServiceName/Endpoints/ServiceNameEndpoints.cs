namespace ProperTea.ServiceName.Endpoints;

public static class ServiceNameEndpoints
{
    public static void MapServiceNameEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/service-name")
            //.WithTags("tags")
            ;

        HandleServiceEndpoint.Map(app);
    }
}