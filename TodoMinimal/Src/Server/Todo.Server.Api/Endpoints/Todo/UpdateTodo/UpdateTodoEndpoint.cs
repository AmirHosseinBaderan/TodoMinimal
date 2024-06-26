﻿

using Application.Todo.UpdateTodo;
using Microsoft.AspNetCore.Mvc;
using Server.Api.Filters;

namespace Server.Api.Endpoints.Todo.UpdateTodo;

public class UpdateTodoEndpoint : IEndpoint, IEndpointHandler<UpdateTodoRequest, IResponse>
{
    public async Task<IResponse> HandlerAsync(UpdateTodoRequest request, IMapper mapper, IMediator mediator)
    {
        var command = mapper.Map<UpdateTodoCommand>(request);
        var result = await mediator.Send(command);

        return result.Match(Left: (status) => status.Handler(null),
                            Right: (todo) => todo.Success());
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/todo/update", async (
                    [FromBody] UpdateTodoRequest request,
                    IMapper mapper,
                    IMediator mediator) =>
        await HandlerAsync(request,
        mapper,
        mediator))
            .Validator<UpdateTodoRequest>()
            .WithTags(EndpointSchema.TodoTag);
    }
}
