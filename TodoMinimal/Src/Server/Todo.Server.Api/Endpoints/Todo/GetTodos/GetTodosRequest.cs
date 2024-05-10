using Microsoft.AspNetCore.Mvc;

namespace Todo.Server.Api.Endpoints.Todo;

public record GetTodosRequest([FromQuery] int Page, [FromQuery] int Count);
