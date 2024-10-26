using BeyondNet.Cqrs.Events.Interfaces;
using BeyondNet.Ddd.Interfaces;

namespace BeyondNet.Cqrs.Events.Impl
{
    public abstract class AbstractEventHandler<TEvent> : IEventHandler<TEvent> where TEvent : IDomainEvent
    {
        public readonly ILogger<AbstractEventHandler<TEvent>> logger;

        protected abstract Task Handle(TEvent @event);
        
        protected AbstractEventHandler(ILogger<AbstractEventHandler<TEvent>> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task On(TEvent @event)
        {
            logger.LogInformation($"Handling event {@event.GetType().Name}");

            try
            {
                logger.LogInformation($"Handling event {@event.GetType().Name}");

                Handle(@event);

                logger.LogInformation($"Event handled {@event.GetType().Name}");

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error handling event {@event.GetType().Name}");
                throw;
            }
            finally
            {
                logger.LogInformation($"Event handled {@event.GetType().Name}");

            }
        }
    }
}
