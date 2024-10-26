using BeyondNet.Ddd.Interfaces;

namespace BeyondNet.Cqrs.Events.Interfaces
{
    public interface IEventHandler<TEvent> where TEvent : IDomainEvent
    {
        Task On(TEvent @event);
    }
}
