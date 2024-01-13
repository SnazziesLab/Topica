using Events.Services;

public class QueueIngestService : IHostedService
{
    public InMemoryQueueService QueueService { get; }
    private readonly ILogger<QueueIngestService> _logger;
    public InMemoryDb InMemoryDb { get; set; }

    public QueueIngestService(ILogger<QueueIngestService> logger, InMemoryQueueService queueService, InMemoryDb inMemoryDb)
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

        var exists = InMemoryDb.Events.ContainsKey(message.EventUid);
        if (!exists)
        {
            var e = new Event
            {
                Uid = message.EventUid,
                History = []
            };

            e.History.Add(message.DateTimeOffset, message);
            var addOk = InMemoryDb.Events.TryAdd(message.EventUid, e);
            if (!addOk)
            {
                _logger.LogError("Unable to add");
                QueueService.Pop();
                throw new Exception();
            }

        }

        var existingEvent = InMemoryDb.Events[message.EventUid];
        existingEvent.History.Add(message.DateTimeOffset, message);

        QueueService.Pop();

        return Task.CompletedTask;
    }

    async Task Loop(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
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