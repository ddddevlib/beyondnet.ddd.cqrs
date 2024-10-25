using BeyondNet.Ddd.Interfaces;

namespace BeyondNet.Cqrs.Producers.Interfaces
{
    public interface IEventProducer
    {
        Task ProduceAsync<T>(string topic, T @event) where T : IDomainEvent;
    }
}
