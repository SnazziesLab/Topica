using Events.Sdk.Data;
using System.ComponentModel.DataAnnotations;

public class Event
{
    public required string TopicId { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    public string Description { get; set; } = string.Empty;
    public  Dictionary<DateTimeOffset, Entry> History { get; set; } = new();

}
