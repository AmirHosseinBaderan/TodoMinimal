using Application.Todo;
using Application.Todo.DeleteTodo;

namespace Server.Api.Endpoints.Todo.DeleteTodo;

public class DeleteTodoEndpoint : IEndpoint, IEndpointHandler<DeleteTodoRequest, IResponse>
{
    public async Task<IResponse> HandlerAsync(DeleteTodoRequest request, IMapper mapper, IMediator mediator)
    {
        DeleteTodoCommand command = mapper.Map<DeleteTodoCommand>(request);
        TodoActionStatus result = await mediator.Send(command);
        return result.Handler(new());
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/todo/delete", async ([AsParameters] DeleteTodoRequest request,
                                        IMapper mapper,
                                        IMediator mediator) =>
        await HandlerAsync(request,
        mapper,
        mediator))
            .WithTags(EndpointSchema.TodoTag);
    }
}
