namespace BeyondNet.Cqrs.Consumers
{
    public interface IEventConsumer
    {
        void Consume(string topic);
    }
}