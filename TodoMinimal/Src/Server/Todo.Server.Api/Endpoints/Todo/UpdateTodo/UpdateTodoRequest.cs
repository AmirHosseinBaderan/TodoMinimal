namespace Server.Api.Endpoints.Todo.UpdateTodo;

public record UpdateTodoRequest(Guid Id, string Title, string? Description, bool Complete);
