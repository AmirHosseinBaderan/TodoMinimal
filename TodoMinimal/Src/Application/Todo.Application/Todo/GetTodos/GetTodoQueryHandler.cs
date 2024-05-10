using Domain.Common;
using MediatR;

namespace Application.Todo.GetTodos;

public class GetTodoQueryHandler(IBaseQuery<Domain.Aggregates.Todo> query) : IRequestHandler<GetTodosQuery, IEnumerable<TodoDto>>
{
    public async Task<IEnumerable<TodoDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Aggregates.Todo> todos = await query.GetAllAsync();
        return todos.Select(t => (TodoDto)t);
    }
}
