namespace Application.Todo.UpdateTodo;

public record UpdateTodoCommand(Guid Id, string Title, string? Description, bool Complete) : IRequest<Either<TodoDto, TodoActionStatus>>;
