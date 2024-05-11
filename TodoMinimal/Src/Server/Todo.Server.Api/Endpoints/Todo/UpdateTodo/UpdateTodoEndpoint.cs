

using Server.Api.Filters;
using Todo.Server.Api.Endpoints;

namespace Server.Api.Endpoints.Todo.UpdateTodo;

public class UpdateTodoEndpoint : IEndpoint, IEndpointHandler<UpdateTodoRequest, UpdateTodoResponse>
{
    public Task<UpdateTodoResponse> HandlerAsync(UpdateTodoRequest request, IMapper mapper, IMediator mediator)
    {

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
