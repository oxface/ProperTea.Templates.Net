using Microsoft.AspNetCore.Mvc;
using ProperTea.ProperCqrs;
using ProperTea.ServiceName.Application.AggregateRootNames.Commands;
using ProperTea.Shared.Api.Models;

namespace ProperTea.ServiceName.Api.Endpoints.AggregateRootNames;

public static class CreateAggregateRootNameEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/aggregate-root-names", HandleAsync)
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
        [FromBody] CreateAggregateRootNameRequest request,
        ICommandBus commandBus,
        IQueryBus queryBus,
        ILogger<Program> logger)
    {
        try
        {
            var command = new CreateAggregateRootNameCommand();
            await commandBus.SendAsync(command);

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

public record CreateAggregateRootNameRequest();