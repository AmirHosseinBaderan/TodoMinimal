using Application.Todo;
using Application.Todo.GetTodos;
using Todo.Server.Api.Models;

namespace Server.Api.Endpoints.Todo;

public class GetTodosEndpoint : IEndpoint, IEndpointHandler<GetTodosRequest, IEnumerable<GetTodoResponse>>
{
    public Task<User?> GetUserAsync(HttpContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<GetTodoResponse>> HandlerAsync(HttpContext context, GetTodosRequest request, IMapper mapper, IMediator mediator)
    {
        GetTodosQuery command = mapper.Map<GetTodosQuery>(request);
        IEnumerable<TodoDto> result = await mediator.Send(command);
        return mapper.Map<IEnumerable<GetTodoResponse>>(result);
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/todo/todos", HandlerAsync)
            .WithName(nameof(GetTodosRequest))
            .WithTags(EndpointSchema.TodoTag);
    }

}
