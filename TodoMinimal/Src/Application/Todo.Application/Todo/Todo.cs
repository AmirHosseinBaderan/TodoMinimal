namespace Application.Todo;

public record TodoDto(Guid Id, string Title, string? Description, DateTime CreatedOn, DateTime? UpdatedOn, byte Status)
{
    public static explicit operator TodoDto(Domain.Aggregates.Todo todo)
        => new(Id: todo.Id,
                Title: todo.Title,
                Description: todo.Description,
                CreatedOn: todo.CreatedOn,
                UpdatedOn: todo.UpdatedOn,
                Status: todo.Status);
}
