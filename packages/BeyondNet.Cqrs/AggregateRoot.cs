using BeyondNet.Ddd.Interfaces;
using IAggregateRoot = BeyondNet.Cqrs.Core.Interfaces.IAggregateRoot;

namespace BeyondNet.Cqrs
{

    /// <summary>
    /// Represents the base class for aggregate roots in the domain-driven design.
    /// </summary>
    /// <typeparam name="TAggegateRoot">The type of the aggregate root.</typeparam>
    /// <typeparam name="TProps">The type of the properties of the aggregate root.</typeparam>
    public abstract class AggregateRoot : IAggregateRoot
    {

        private List<IDomainEvent> _domainEvents;

        public int Version { get; set; }

        protected AggregateRoot()
        {
            Version = -1;
            _domainEvents = new List<IDomainEvent>();
        }

        /// <summary>
        /// Gets the uncommitted changes.
        /// </summary>
        /// <returns>A read-only collection of uncommitted domain events.</returns>
        public IReadOnlyCollection<IDomainEvent> GetUncommittedChanges()
        {
            return _domainEvents.AsReadOnly();
        }

        /// <summary>
        /// Marks all changes as committed.
        /// </summary>
        public void MarkChangesAsCommitted()
        {
            _domainEvents?.Clear();
        }

        /// <summary>
        /// Loads the domain events from history.
        /// </summary>
        /// <param name="history">The history of domain events.</param>
        /// <exception cref="ArgumentNullException">Thrown when history is null.</exception>
        public void LoadFromHistory(IReadOnlyCollection<IDomainEvent> history)
        {
            if (history is null)
            {
                throw new ArgumentNullException(nameof(history));
            }

            foreach (var e in history)
            {
                ApplyChange(e, false);
            }
        }

        /// <summary>
        /// Applies a domain event.
        /// </summary>
        /// <param name="domainEvent">The domain event to apply.</param>
        /// <param name="isNew">Indicates whether the event is new.</param>
        /// <exception cref="ArgumentNullException">Thrown when domainEvent is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the Apply method is missing for the domain event type.</exception>
        public void ApplyChange(IDomainEvent domainEvent, bool isNew)
        {
            if (domainEvent is null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }

            var method = GetType().GetMethod("Apply", new Type[] { domainEvent.GetType() });

            if (method == null)
            {
                throw new InvalidOperationException($"Missing Apply method for {domainEvent.GetType()}");
            }

            method.Invoke(this, new object[] { domainEvent });

            if (isNew)
            {
                _domainEvents.Add(domainEvent);
            }
        }

        /// <summary>
        /// Raises a domain event.
        /// </summary>
        /// <param name="domainEvent">The domain event to raise.</param>
        /// <exception cref="ArgumentNullException">Thrown when domainEvent is null.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1030:Use events where appropriate", Justification = "<Pending>")]
        public void RaiseEvent(IDomainEvent domainEvent)
        {
            if (domainEvent is null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }

            ApplyChange(domainEvent, true);
        }

        /// <summary>
        /// Applies a domain event.
        /// </summary>
        /// <param name="domainEvent">The domain event to apply.</param>
        public void ApplyChange(IDomainEvent domainEvent)
        {
            ApplyChange(domainEvent, true);
        }

        /// <summary>
        /// Replays a collection of domain events.
        /// </summary>
        /// <param name="domainEvents">The domain events to replay.</param>
        /// <exception cref="ArgumentNullException">Thrown when domainEvents is null.</exception>
        public void ReplayEvents(IEnumerable<IDomainEvent> domainEvents)
        {
            if (domainEvents is null)
            {
                throw new ArgumentNullException(nameof(domainEvents));
            }

            foreach (var @event in domainEvents)
            {
                ApplyChange(@event);
            }
        }
    }
}
