using Microsoft.AspNetCore.Mvc;

namespace Server.Api.Endpoints.Todo;

public record GetTodosRequest([FromQuery] int Page, [FromQuery] int Count);
