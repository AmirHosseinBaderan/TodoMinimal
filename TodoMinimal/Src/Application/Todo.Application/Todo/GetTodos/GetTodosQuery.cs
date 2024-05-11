namespace Application.Todo.GetTodos;

public record GetTodosQuery(int Page, int Count) : IRequest<IEnumerable<TodoDto>>;
