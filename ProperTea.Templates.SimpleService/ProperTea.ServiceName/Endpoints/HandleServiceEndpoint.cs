using Microsoft.AspNetCore.Mvc;
using ProperTea.ProperCqrs;

namespace ProperTea.ServiceName.Endpoints;

public static class HandleServiceEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        // TODO: change
        app.MapPost("/api/service-name", HandleAsync)
            //.WithName("specify name")
            //.WithSummary("specify summary")
            //.WithDescription("specify description")
            //.WithTags("tags")
            .Produces<object>()
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> HandleAsync(
        [FromBody] HandleServiceRequest request,
        ICommandBus commandBus,
        IQueryBus queryBus,
        ILogger<Program> logger)
    {
        try
        {
            // TODO: implement

            return Results.Ok();
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning(ex, "Invalid operation");
            return Results.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error");
            return Results.Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Internal server error");
        }
    }
}

public record HandleServiceRequest();