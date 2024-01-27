using Events.Sdk.Data;

public class Topic
{
    public required string Id { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    public  List<Entry> History { get; set; } = [];

}
