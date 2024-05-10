using Microsoft.EntityFrameworkCore;

namespace Todo.Infrastructure.Presistance;

public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Aggregates.Todo> Todo { get; set; } = null!;
}
