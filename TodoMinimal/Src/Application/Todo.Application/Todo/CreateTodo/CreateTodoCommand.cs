using LanguageExt;
using MediatR;

namespace Application.Todo.CreateTodo;

public record CreateTodoCommand(string Title, string? Description, bool Complete) : IRequest<Either<TodoActionStatus, TodoDto>>;
