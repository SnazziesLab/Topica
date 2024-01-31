using Events.Sdk.Data;
using System.ComponentModel.DataAnnotations;

public class Topic: TopicMeta
{
    public List<Entry> History { get; set; } = [];
}

public class TopicMeta
{
    [Key]
    public required string Id { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
}