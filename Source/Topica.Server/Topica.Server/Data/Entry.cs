using System.ComponentModel.DataAnnotations;

namespace Events.Sdk.Data;

public record Entry(DateTimeOffset CreatedOn, string Content)
{
    [Key]
    public Guid EntryId { get; init; } = Guid.NewGuid();
}
