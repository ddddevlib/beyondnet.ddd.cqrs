using BeyondNet.Ddd.Interfaces;

namespace BeyondNet.Cqrs.Core.Interfaces
{
    public interface IAggregateRoot
    {
        int Version { get; set; }
        void ApplyChange(IDomainEvent domainEvent, bool isNew);
        IReadOnlyCollection<IDomainEvent> GetUncommittedChanges();
        void LoadFromHistory(IReadOnlyCollection<IDomainEvent> history);
        void MarkChangesAsCommitted();
        void ReplayEvents(IEnumerable<IDomainEvent> domainEvents);
    }
}
