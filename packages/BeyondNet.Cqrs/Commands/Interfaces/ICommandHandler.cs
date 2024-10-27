namespace BeyondNet.Cqrs.Commands.Interfaces
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand
                                                        where TResult: ResultSet
    {
        Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
