namespace BeyondNet.Cqrs.Commands.Impl
{

    public abstract class AbstractCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
        where TResult : ResultSet
    {
        public readonly ILogger<AbstractCommandHandler<TCommand, TResult>> logger;

        public abstract Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);

        public AbstractCommandHandler(ILogger<AbstractCommandHandler<TCommand, TResult>> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Handling command {command.GetType().Name} with Id {command.Id}");

            try
            {
                logger.LogInformation($"Handling command {command.GetType().Name} with Id {command.Id}");

                var result = await Handle(command, cancellationToken);

                logger.LogInformation($"Command {command.GetType().Name} with Id {command.Id} handled successfully");

                return result;
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
