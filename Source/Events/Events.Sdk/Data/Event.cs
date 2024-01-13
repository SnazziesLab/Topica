using Events.Sdk.Data;

public class Event
{
    public string Uid { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    public string Description { get; set; } = string.Empty;
    public Dictionary<DateTimeOffset, Message> History { get; set; } = new();

}
