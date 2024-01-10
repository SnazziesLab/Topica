using Events.Data;
using Events.Sdk.Data;
using System.Collections.Concurrent;

namespace Events.Services
{
    public class QueueService
    {
        ConcurrentQueue<Message> messageQueue { get; set; } = [];

        public QueueService()
        {
            
        }


        public void Push(string message)
        {
            messageQueue.Enqueue(message);
        }

        public string? Peek()
        {
            return messageQueue.TryPeek(out var message) ? message : null;
        }
        public Task<string> Pop()
        {
            var success = messageQueue.TryDequeue(out var message);

            return message;
        }
    }
}
