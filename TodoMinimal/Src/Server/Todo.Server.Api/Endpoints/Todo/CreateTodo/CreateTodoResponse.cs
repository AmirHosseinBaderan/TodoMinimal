using Application.Todo;

namespace Server.Api.Endpoints.Todo.CreateTodo;

public record CreateTodoResponse(bool Success, TodoDto? Todo);
