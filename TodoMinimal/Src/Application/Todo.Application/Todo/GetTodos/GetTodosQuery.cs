using MediatR;

namespace Application.Todo.GetTodos;

public record GetTodosQuery(int Page, int Count) : IRequest<IReadOnlyList<TodoDto>>;
