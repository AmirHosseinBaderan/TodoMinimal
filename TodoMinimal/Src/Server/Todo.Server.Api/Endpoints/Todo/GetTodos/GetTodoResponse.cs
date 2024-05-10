namespace Todo.Server.Api.Endpoints.Todo;

public record GetTodoResponse(Guid Id, string Title, string? Description, DateTime CreatedOn, DateTime? UpdatedOn, byte Status);

