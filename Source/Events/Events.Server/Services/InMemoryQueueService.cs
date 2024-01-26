using Events.Sdk.Data;
using System.Collections.Concurrent;

namespace Events.Services
{
    public class InMemoryQueueService : IQueueService
    {
        ConcurrentQueue<Message> MessageQueue { get; set; } = [];

        public InMemoryQueueService()
        {

        }


        public void Push(Message message)
        {
                MessageQueue.Enqueue(message);
        }

        public Message? Peek()
        {
            return MessageQueue.TryPeek(out var message) ? message : null;
        }
        public Message? Pop()
        {
            return MessageQueue.TryDequeue(out var message) ? message : null;
        }
    }
}
