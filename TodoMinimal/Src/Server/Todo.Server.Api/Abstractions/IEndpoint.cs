using Todo.Server.Api.Models;

namespace Server.Api.Abstractions;

public interface IEndpoint
{
    Task<User?> GetUserAsync(HttpContext context);

    void MapEndpoint(IEndpointRouteBuilder app);
}