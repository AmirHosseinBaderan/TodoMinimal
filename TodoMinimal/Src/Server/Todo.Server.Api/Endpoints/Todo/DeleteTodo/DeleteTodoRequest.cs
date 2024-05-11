using Microsoft.AspNetCore.Mvc;

namespace Server.Api.Endpoints.Todo.DeleteTodo;

public record DeleteTodoRequest([FromQuery] Guid Id);
