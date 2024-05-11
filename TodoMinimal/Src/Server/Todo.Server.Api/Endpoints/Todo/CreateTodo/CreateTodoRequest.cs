namespace Server.Api.Endpoints.Todo.CreateTodo;

public record CreateTodoRequest(string Title, string? Description, bool Complete);
