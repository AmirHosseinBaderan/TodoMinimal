using Domain.Common;
using MediatR;

namespace Application.Todo.UpdateTodo;

public class UpdateTodoCommandHandler(IBaseCud<Domain.Aggregates.Todo> cud, IBaseQuery<Domain.Aggregates.Todo> query) : IRequestHandler<UpdateTodoCommand, TodoDto>
{
    public async Task<TodoDto> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await query.GetAsync(request.Id);
    }

}
