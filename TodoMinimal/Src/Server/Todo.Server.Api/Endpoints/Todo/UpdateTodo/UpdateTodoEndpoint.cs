using Application.Todo.UpdateTodo;
using Server.Api.Filters;
using Todo.Server.Api.Models;

namespace Server.Api.Endpoints.Todo.UpdateTodo;

public class UpdateTodoEndpoint : IEndpoint, IEndpointHandler<UpdateTodoRequest, IResponse>
{
    public Task<User?> GetUserAsync(HttpContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse> HandlerAsync(HttpContext context, UpdateTodoRequest request, IMapper mapper, IMediator mediator)
    {
        var command = mapper.Map<UpdateTodoCommand>(request);
        var result = await mediator.Send(command);

        return result.Match(Left: (status) => status.Handler(null),
                            Right: (todo) => todo.Success());
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/todo/update", HandlerAsync)
            .Validator<UpdateTodoRequest>()
            .WithTags(EndpointSchema.TodoTag);
    }
}
