namespace Events.Data
{
    public class Event
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        public string Description { get; set; } = string.Empty;
        public Dictionary<DateTimeOffset, string> History { get; set; } = new ();

    }
}
