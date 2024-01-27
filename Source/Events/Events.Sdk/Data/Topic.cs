using Events.Sdk.Data;
using System.ComponentModel.DataAnnotations;

public class Topic
{
    public required string Name { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    public  List<Entry> History { get; set; } = new();

}


