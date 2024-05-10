using Domain.Common;

namespace Domain.Aggregates;

public record Todo : BaseEntity
{
    [Required]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    public bool Complete { get; set; }
}
