using Microsoft.EntityFrameworkCore;

namespace Todo.Infrastructure.Presistance;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {

    }

    public DbSet<Domain.Aggregates.Todo> Todo => Set<Domain.Aggregates.Todo>();
}
