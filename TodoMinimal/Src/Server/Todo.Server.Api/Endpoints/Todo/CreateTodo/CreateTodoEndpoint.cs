using Application.Todo.CreateTodo;
using Microsoft.AspNetCore.Mvc;
using Server.Api.Filters;

namespace Server.Api.Endpoints.Todo.CreateTodo;

public class CreateTodoEndpoint : IEndpoint, IEndpointHandler<CreateTodoRequest, IResponse>
{
    public async Task<IResponse> HandlerAsync(CreateTodoRequest request, IMapper mapper, IMediator mediator)
    {
        CreateTodoCommand commnad = mapper.Map<CreateTodoCommand>(request);
        var result = await mediator.Send(commnad);

        return result
                .Match(Left: (status) => status.Handler(null),
                      Right: (todo) => todo.Success());
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/todo/create", async ([FromBody] CreateTodoRequest request,
                                    IMapper mapper,
                                    IMediator mediator) =>
        await HandlerAsync(request,
                           mapper,
                           mediator))
            .Validator<CreateTodoRequest>()
            .WithTags(EndpointSchema.TodoTag);
    }
}
