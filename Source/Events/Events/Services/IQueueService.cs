using Events.Sdk.Data;

namespace Events.Services
{
    public interface IQueueService
    {
        public void Push(Message message);
        public Message? Peek();
        public Message? Pop();
    }
}
