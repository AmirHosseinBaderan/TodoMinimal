using Application.Todo;

namespace Server.Api.Endpoints.Todo.UpdateTodo;

public record UpdateTodoResponse(bool Success, TodoDto? Todo);
