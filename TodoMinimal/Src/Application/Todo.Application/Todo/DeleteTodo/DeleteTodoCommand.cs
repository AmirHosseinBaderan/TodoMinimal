namespace Application.Todo.DeleteTodo;

public record DeleteTodoCommand(Guid Id) : IRequest<TodoActionStatus>;
