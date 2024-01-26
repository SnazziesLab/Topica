namespace Events.Sdk.Data;

public record Entry(DateTimeOffset DateTimeOffset, string Content)
{
    public Guid EntryId { get; init; } = Guid.NewGuid();
}
