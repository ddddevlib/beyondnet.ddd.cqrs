using BeyondNet.Cqrs.Events.Interfaces;
using BeyondNet.Ddd.Interfaces;

namespace BeyondNet.Cqrs.Events.Impl
{
    public abstract class AbstractEventHandler<TEvent> : IEventHandler<TEvent> where TEvent : IDomainEvent
    {
        public readonly ILogger<AbstractEventHandler<TEvent>> logger;

        public abstract Task HandleOn(TEvent @event);
        
        protected AbstractEventHandler(ILogger<AbstractEventHandler<TEvent>> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task On(TEvent @event)
        {
            logger.LogInformation($"Handling event {@event.GetType().Name}");

            try
            {
                logger.LogInformation($"Handling event {@event.GetType().Name}");

                await HandleOn(@event);

                logger.LogInformation($"Event handled {@event.GetType().Name}");

                return;
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
