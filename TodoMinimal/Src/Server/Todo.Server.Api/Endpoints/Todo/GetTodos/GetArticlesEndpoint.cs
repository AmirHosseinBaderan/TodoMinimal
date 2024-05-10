using MapsterMapper;
using MediatR;
using Todo.Server.Api.Abstractions;

namespace Todo.Server.Api.Endpoints.Todo;

public class GetArticlesEndpoint : IEndpoint<GetTodosRequest, GetTodoResponse>
{
    public Task<GetTodoResponse> HandlerAsync([AsParameters] GetTodosRequest request, IMapper mapper, IMediator mediator)
    {
        throw new NotImplementedException();
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
