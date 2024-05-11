

using Server.Api.Filters;
using Todo.Server.Api.Endpoints;

namespace Server.Api.Endpoints.Todo.UpdateTodo;

public class UpdateTodoEndpoint : IEndpoint, IEndpointHandler<UpdateTodoRequest, UpdateTodoResponse>
{
    public async Task<UpdateTodoResponse> HandlerAsync(UpdateTodoRequest request, IMapper mapper, IMediator mediator)
    {
        var command = await mediator.Send(request);
        return new(true, null);
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/todo/update", async (
                    [AsParameters] UpdateTodoRequest request,
                    IMapper mapper,
                    IMediator mediator) =>
        await HandlerAsync(request,
        mapper,
        mediator))
            .Validator<UpdateTodoValidator>()
            .WithTags(EndpointSchema.TodoTag);
    }
}
