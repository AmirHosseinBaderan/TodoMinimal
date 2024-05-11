using Application.Todo;
using Application.Todo.GetTodos;
using MapsterMapper;
using MediatR;
using Server.Api.Abstractions;

namespace Todo.Server.Api.Endpoints.Todo;

public class GetTodosEndpoint : IEndpoint, IEndpointHandler<GetTodosRequest, IEnumerable<GetTodoResponse>>
{
    public async Task<IEnumerable<GetTodoResponse>> HandlerAsync(GetTodosRequest request, IMapper mapper, IMediator mediator)
    {
        GetTodosQuery command = mapper.Map<GetTodosQuery>(request);
        IEnumerable<TodoDto> result = await mediator.Send(command);
        return mapper.Map<IEnumerable<GetTodoResponse>>(result);
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/todo/todos", async (
                  [AsParameters] GetTodosRequest request,
                  IMapper mapper,
                  IMediator mediator) =>
        await HandlerAsync(request, mapper, mediator))
            .WithName(nameof(GetTodosRequest))
            .WithTags(EndpointSchema.TodoTag);
    }

}
