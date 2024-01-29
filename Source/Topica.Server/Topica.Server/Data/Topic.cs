using Events.Sdk.Data;
using System.ComponentModel.DataAnnotations;

public class Topic
{
    [Key]
    public required string Id { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    public List<Entry> History { get; set; } = [];

}
