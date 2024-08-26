using Application.Todo.CreateTodo;
using Server.Api.Filters;
using Todo.Server.Api.Models;

namespace Server.Api.Endpoints.Todo.CreateTodo;

public class CreateTodoEndpoint : IEndpoint, IEndpointHandler<CreateTodoRequest, IResponse>
{
    public Task<User?> GetUserAsync(HttpContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse> HandlerAsync(HttpContext context, CreateTodoRequest request, IMapper mapper, IMediator mediator)
    {
        CreateTodoCommand commnad = mapper.Map<CreateTodoCommand>(request);
        var result = await mediator.Send(commnad);

        return result
                .Match(Left: (status) => status.Handler(null),
                      Right: (todo) => todo.Success());
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/todo/create", HandlerAsync)
            .Validator<CreateTodoRequest>()
            .WithTags(EndpointSchema.TodoTag);
    }
}
