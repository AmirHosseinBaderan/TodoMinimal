using Application.Todo;
using Application.Todo.DeleteTodo;
using Todo.Server.Api.Models;

namespace Server.Api.Endpoints.Todo.DeleteTodo;

public class DeleteTodoEndpoint : IEndpoint, IEndpointHandler<DeleteTodoRequest, IResponse>
{
    public Task<User?> GetUserAsync(HttpContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse> HandlerAsync(HttpContext context, DeleteTodoRequest request, IMapper mapper, IMediator mediator)
    {
        DeleteTodoCommand command = mapper.Map<DeleteTodoCommand>(request);
        TodoActionStatus result = await mediator.Send(command);
        return result.Handler(new());
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/todo/delete", HandlerAsync)
       .WithTags(EndpointSchema.TodoTag);
    }
}
