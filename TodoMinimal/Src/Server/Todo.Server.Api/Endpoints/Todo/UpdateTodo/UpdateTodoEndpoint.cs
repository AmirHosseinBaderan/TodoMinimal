

using Application.Todo.UpdateTodo;
using Server.Api.Filters;
using Todo.Server.Api.Endpoints;

namespace Server.Api.Endpoints.Todo.UpdateTodo;

public class UpdateTodoEndpoint : IEndpoint, IEndpointHandler<UpdateTodoRequest, IResponse>
{
    public async Task<IResponse> HandlerAsync(UpdateTodoRequest request, IMapper mapper, IMediator mediator)
    {
        var command = mapper.Map<UpdateTodoCommand>(request);
        var result = await mediator.Send(command);

        return result.Match(Left: (status) => status.Handler(null),
                            Right: (todo) => todo.Success());
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
