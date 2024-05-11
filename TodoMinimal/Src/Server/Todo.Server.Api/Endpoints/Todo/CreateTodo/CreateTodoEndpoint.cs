using Application.Todo.CreateTodo;
using Server.Api.Filters;
using Todo.Server.Api.Endpoints;

namespace Server.Api.Endpoints.Todo.CreateTodo;

public class CreateTodoEndpoint : IEndpoint, IEndpointHandler<CreateTodoRequest, CreateTodoResponse>
{
    public async Task<CreateTodoResponse> HandlerAsync(CreateTodoRequest request, IMapper mapper, IMediator mediator)
    {
        CreateTodoCommand commnad = mapper.Map<CreateTodoCommand>(request);
        var result = await mediator.Send(commnad);

        return result
                .Match(Left: (status) =>
                      new CreateTodoResponse(false, null),
                      Right: (todo) =>
                      new CreateTodoResponse(true, todo));
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/todo/create", async ([AsParameters] CreateTodoRequest request,
                                    IMapper mapper,
                                    IMediator mediator) =>
        await HandlerAsync(request,
                           mapper,
                           mediator))
            .Validator<CreateTodoValidator>()
            .WithTags(EndpointSchema.TodoTag);
    }
}
