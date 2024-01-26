namespace Events.Sdk.Data;

public record Entry(DateTimeOffset CreatedOn, string Content)
{
    public Guid EntryId { get; init; } = Guid.NewGuid();
}
