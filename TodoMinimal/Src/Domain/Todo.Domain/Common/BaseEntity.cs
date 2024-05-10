using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Common;

public record BaseEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    [Required]
    public byte Status { get; set; }
}
