using Events.Sdk.Data;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class Topic: TopicMeta
{
    public List<Entry> History { get; set; } = [];
}

public class TopicMeta
{
    [Key]
    public required string Id { get; set; }
    [NotNull]
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
}