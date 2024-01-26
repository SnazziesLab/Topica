using Events.Services;

public class QueueIngestService : IHostedService
{
    public IQueueService QueueService { get; }
    private readonly ILogger<QueueIngestService> _logger;
    public InMemoryStore InMemoryDb { get; set; }

    public QueueIngestService(ILogger<QueueIngestService> logger, IQueueService queueService, InMemoryStore inMemoryDb)
    {
        InMemoryDb = inMemoryDb;
        _logger = logger;
        QueueService = queueService;
    }

    Task ProcessQueue()
    {
        var message = QueueService.Peek();
        if (message is null)
            return Task.CompletedTask;

        var newEntry = new Events.Sdk.Data.Entry(message.DateTimeOffset, message.Content);

        if (!InMemoryDb.Events.TryGetValue(message.TopicId, out var @event))
        {
            var newEvent = new Event
            {
                TopicId = message.TopicId,
                History = []
            };

            newEvent.History.Add(message.DateTimeOffset, newEntry);

            var addOk = InMemoryDb.Events.TryAdd(message.TopicId, newEvent);
            if (!addOk)
            {
                QueueService.Pop();
                throw new Exception("Unable to add");
            }

        }
        else
        {
            @event.History.Add(message.DateTimeOffset, newEntry);
        }

        QueueService.Pop();
        _logger.LogTrace("Message Added");
        return Task.CompletedTask;
    }

    async Task Loop(CancellationToken cancellationToken)
    {
        while (true)
            await ProcessQueue();
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("My Hosted Service is starting.");
        Task.Run(() => Loop(cancellationToken), cancellationToken);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("My Hosted Service is stopping.");


        return Task.CompletedTask;
    }
}