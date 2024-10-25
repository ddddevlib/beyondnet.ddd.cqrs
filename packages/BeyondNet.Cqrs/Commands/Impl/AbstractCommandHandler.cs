using BeyondNet.Cqrs.Commands.Interfaces;

namespace BeyondNet.Cqrs.Commands.Impl
{
    public abstract class AbstractCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : AbstractCommand, new()
    {
        public readonly ILogger<AbstractCommandHandler<TCommand>> logger;

        public abstract Task Handle(TCommand command);

        public AbstractCommandHandler(ILogger<AbstractCommandHandler<TCommand>> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task HandleAsync(TCommand command)
        {
            logger.LogInformation($"Handling command {command.GetType().Name} with Id {command.Id}");

            try
            {
                logger.LogInformation($"Handling command {command.GetType().Name} with Id {command.Id}");

                await Handle(command);

                logger.LogInformation($"Command {command.GetType().Name} with Id {command.Id} handled successfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                logger.LogInformation($"Command {command.GetType().Name} with Id {command.Id} handled");

            }
        }
    }
}
