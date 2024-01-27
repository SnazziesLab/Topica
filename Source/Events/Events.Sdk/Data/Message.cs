namespace Events.Sdk.Data;

public class Message
{
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

    public required string Content { get; set; }

    public required string TopicId { get; set; }

}
