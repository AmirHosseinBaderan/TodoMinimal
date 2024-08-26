namespace Todo.Server.Api.Models;

public record User
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

}
